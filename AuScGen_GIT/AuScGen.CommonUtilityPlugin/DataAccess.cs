using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.CommonUtilityPlugin
{
    /// <summary>
    /// 
    /// </summary>
    public enum DataCategory
    {
        /// <summary>
        /// The SQLDB
        /// </summary>
        SQLDB,
        /// <summary>
        /// The ms excel
        /// </summary>
        MSExcel,
        /// <summary>
        /// The Visual FoxPro
        /// </summary>
        VSFoxPro
    }

    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IContainerPlugin))]
    public class DataAccess : IContainerPlugin
    {
        /// <summary>
        /// The connection
        /// </summary>
        private DbConnection connection;

        /// <summary>
        /// The command
        /// </summary>
        private DbCommand command;

        /// <summary>
        /// The adapter
        /// </summary>
        private DbDataAdapter adapter;

        /// <summary>
        /// Gets or sets the data category.
        /// </summary>
        /// <value>
        /// The data category.
        /// </value>
        public DataCategory DataCategory { get; set; }

        /// <summary>
        /// Gets or sets the conection string.
        /// </summary>
        /// <value>
        /// The conection string.
        /// </value>
        public string ConectionString { get; set; }

        /// <summary>
        /// Gets or sets the query string.
        /// </summary>
        /// <value>
        /// The query string.
        /// </value>
        public string QueryString { get; set; }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetConnection<T>() where T : DbConnection
        {
            CreateConection();
            return (T)connection;
        }

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetCommand<T>() where T : DbCommand
        {
            CreateCommand();
            return (T)command;
        }

        /// <summary>
        /// Gets the adapter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetAdapter<T>() where T : DbDataAdapter
        {
            return (T)adapter;
        }
                
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            DataSet aDataSet = new DataSet();
            try
            {
                switch (DataCategory)
                {
                    case DataCategory.SQLDB:
                        CreateDataAdapter();
                        GetAdapter<SqlDataAdapter>().SelectCommand = GetCommand<SqlCommand>();
                        GetAdapter<SqlDataAdapter>().Fill(aDataSet);
                        break;

                    case DataCategory.MSExcel:
                        CreateDataAdapter();
                        GetAdapter<OleDbDataAdapter>().SelectCommand = GetCommand<OleDbCommand>();
                        GetAdapter<OleDbDataAdapter>().Fill(aDataSet);
                        break;

                    case DataCategory.VSFoxPro:
                        CreateDataAdapter();
                        GetAdapter<OleDbDataAdapter>().SelectCommand = GetCommand<OleDbCommand>();
                        GetAdapter<OleDbDataAdapter>().Fill(aDataSet);
                        break;
                }
            }
            catch (DataException e)
            {
                throw new DataBaseException("Exception occured while fetching the data.", e);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
                adapter = null;
            }
            return aDataSet;
        }

        public List<T> GetData<T>()
        {
            List<T> data = null;
            CreateDataAdapter();
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    using (connection)
                    {
                        SqlDataReader reader = GetCommand<SqlCommand>().ExecuteReader();
                        data = CreateList<T>(reader);
                        return data;
                    }
                    break;

                case DataCategory.MSExcel:
                    using (connection)
                    {
                        OleDbDataReader reader = GetCommand<OleDbCommand>().ExecuteReader();
                        data = CreateList<T>(reader);
                        return data;
                       
                    }
                    break;

            }

            return data;
        }

        public void ExecuteCommand()
        {
            try
            {
                switch (DataCategory)
                {
                    case DataCategory.SQLDB:
                        CreateDataAdapter();
                        GetCommand<SqlCommand>().ExecuteNonQuery();
                        //GetAdapter<SqlDataAdapter>().Fill(aDataSet);
                        break;

                    case DataCategory.MSExcel:
                        CreateDataAdapter();
                        GetCommand<OleDbCommand>().ExecuteNonQuery();
                        //GetAdapter<OleDbDataAdapter>().Fill(aDataSet);
                        break;
                }
            }
            catch (DataException e)
            {
                throw new DataBaseException("Exception occured while updating the data.", e);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
                adapter = null;
            }
        }

        public void ExecuteCommand(Action<DbCommand> command)
        {
            try
            {
                CreateDataAdapter();
                switch (DataCategory)
                {
                    case DataCategory.SQLDB:
                        using (connection)
                        {
                            SqlCommand cmd = GetCommand<SqlCommand>();
                            command(cmd);
                            cmd.ExecuteNonQuery();
                        }

                        break;

                    case DataCategory.MSExcel:
                        using (connection)
                        {
                            OleDbCommand cmd = GetCommand<OleDbCommand>();
                            command(cmd);
                            cmd.ExecuteNonQuery();
                        }

                        break;
                }
            }
            catch (DataException e)
            {
                throw new DataBaseException("Exception occured while updating the data.", e);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
                adapter = null;
            }
        }

        public void ExecuteCommand<TCommand>(Action<TCommand> command) where TCommand : DbCommand
        {
            try
            {
                CreateDataAdapter();

                TCommand cmd = GetCommand<TCommand>();
                command(cmd);
                cmd.ExecuteNonQuery();
                //switch (DataCategory)
                //{
                //    case DataCategory.SQLDB:
                //        using (Connection)
                //        {
                //            TCommand cmd = GetCommand<TCommand>();
                //            command(cmd);
                //            cmd.ExecuteNonQuery();
                //        }

                //        break;

                //    case DataCategory.MSExcel:
                //        using (Connection)
                //        {
                //            OleDbCommand cmd = GetCommand<OleDbCommand>();
                //            command(cmd);
                //            cmd.ExecuteNonQuery();
                //        }

                //        break;
                //}
            }
            catch (DataException e)
            {
                throw new DataBaseException("Exception occured while updating the data.", e);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
                adapter = null;
            }
        }


        public List<T> GetData<T>(Action<DbCommand> command)
        {
            List<T> data = null;
            CreateDataAdapter();
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    using (connection)
                    {
                        SqlCommand cmd = GetCommand<SqlCommand>();
                        command(cmd);
                        SqlDataReader reader = cmd.ExecuteReader();
                        data = CreateList<T>(reader);
                        return data;
                    }
                    break;

                case DataCategory.MSExcel:
                    using (connection)
                    {
                        OleDbCommand cmd = GetCommand<OleDbCommand>();
                        command(cmd);
                        OleDbDataReader reader = cmd.ExecuteReader();
                        data = CreateList<T>(reader);
                        return data;
                    }
                    break;

            }

            return data;
        }

        /// <summary>
        /// Inserts the data.
        /// </summary>
        public bool InsertData()
        {
            try
            {
                switch (DataCategory)
                {
                    case DataCategory.SQLDB:
                        CreateDataAdapter();
                        GetCommand<SqlCommand>().ExecuteNonQuery();
                        //command = new SqlCommand(QueryString, GetConnection<SqlConnection>());
                        //command.ExecuteNonQuery();
                        break;

                    case DataCategory.MSExcel:
                        CreateDataAdapter();
                        GetCommand<OleDbCommand>().ExecuteNonQuery();
                        break;
                }
            }
            catch (DataException e)
            {
                throw new DataBaseException("Exception occured while Inserting the data.", e);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
                adapter = null;
            }
            return true;
        }

        public DataTable GetDataTable()
        {
            DataTable aDataTable = new DataTable();
            try
            {
                switch (DataCategory)
                {
                    case DataCategory.SQLDB:
                        CreateDataAdapter();
                        GetAdapter<SqlDataAdapter>().SelectCommand = GetCommand<SqlCommand>();
                        GetAdapter<SqlDataAdapter>().Fill(aDataTable);
                        break;

                    case DataCategory.MSExcel:
                        CreateDataAdapter();
                        GetAdapter<OleDbDataAdapter>().SelectCommand = GetCommand<OleDbCommand>();
                        GetAdapter<OleDbDataAdapter>().Fill(aDataTable);
                        break;

                    case DataCategory.VSFoxPro:
                        CreateDataAdapter();
                        GetAdapter<OleDbDataAdapter>().SelectCommand = GetCommand<OleDbCommand>();
                        GetAdapter<OleDbDataAdapter>().Fill(aDataTable);
                        break;
                }
            }
            catch (DataException e)
            {
                throw new DataBaseException("Exception occured while fetching the data.", e);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
                adapter = null;
            }
            return aDataTable;
        }
        /// <summary>
        /// Update data in DB
        /// </summary>
        /// <param name="queryString"></param>
        public void UpdateData(string queryString)
        {
            QueryString = queryString;

            try
            {
                switch (DataCategory)
                {
                    case DataCategory.SQLDB:
                        CreateDataAdapter();
                        GetCommand<SqlCommand>().ExecuteNonQuery();
                        //GetAdapter<SqlDataAdapter>().Fill(aDataSet);
                        break;

                    case DataCategory.MSExcel:
                        CreateDataAdapter();
                        GetCommand<OleDbCommand>().ExecuteNonQuery();
                        //GetAdapter<OleDbDataAdapter>().Fill(aDataSet);
                        break;
                }
            }
            catch (DataException e)
            {
                throw new DataBaseException("Exception occured while updating the data.", e);
            }
            finally
            {
                connection.Close();
                connection = null;
                command = null;
                adapter = null;
            }
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="qureryString">The qurery string.</param>
        /// <returns></returns>
        public DataSet GetData(string qureryString)
        {
            QueryString = qureryString;
            return GetData();
        }

        /// <summary>
        /// iNSERTS the data.
        /// </summary>
        /// <param name="qureryString">The qurery string.</param>
        /// <returns></returns>
        public bool InsertData(string qureryString)
        {
            QueryString = qureryString;
            return InsertData();
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <param name="qureryString">The qurery string.</param>
        /// <returns></returns>
        public DataTable GetDataTable(string qureryString)
        {
            QueryString = qureryString;
            return GetDataTable();
        }

        /// <summary>
        /// Datas the rows.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public DataRowCollection DataRows(string queryString)
        {
            return GetData(queryString).Tables[0].Rows;
        }

        /// <summary>
        /// Gets the data record.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Ecolab.TelerikPlugin.DataBaseException"></exception>
        public IEnumerable<IDataRecord> GetDataRecord()
        {
            switch (DataCategory)
            {
                case DataCategory.SQLDB:

                    CreateDataAdapter();
                    SqlDataReader Reader;

                    Reader = GetCommand<SqlCommand>().ExecuteReader();
                    {
                        while (Reader.Read())
                        {
                            yield return Reader;
                        }
                    }
                    break;
                case DataCategory.MSExcel:
                    CreateDataAdapter();
                    using (OleDbDataReader oReader = GetCommand<OleDbCommand>().ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            yield return oReader;
                        }
                    }
                    break;

                case DataCategory.VSFoxPro:
                    CreateDataAdapter();
                    using (OleDbDataReader oReader = GetCommand<OleDbCommand>().ExecuteReader())
                    {
                        while (oReader.Read())
                        {
                            yield return oReader;
                        }
                    }
                    break;
            }

            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection = null;
            }

            if (adapter != null)
            {
                adapter = null;
            }
        }

        /// <summary>
        /// Creates the conection.
        /// </summary>
        /// <exception cref="Ecolab.TelerikPlugin.DataBaseException"></exception>
        private void CreateConection()
        {
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    connection = new SqlConnection(ConectionString);
                    connection.Open();
                    break;

                case DataCategory.MSExcel:
                    connection = new System.Data.OleDb.OleDbConnection(ConectionString);
                    connection.Open();
                    break;

                case DataCategory.VSFoxPro:
                    connection = new System.Data.OleDb.OleDbConnection(ConectionString);
                    connection.Open();
                    break;
            }
        }

        /// <summary>
        /// Creates the data adapter.
        /// </summary>
        private void CreateDataAdapter()
        {
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    adapter = new SqlDataAdapter();
                    break;

                case DataCategory.MSExcel:
                    adapter = new OleDbDataAdapter();
                    break;

                case DataCategory.VSFoxPro:
                    adapter = new OleDbDataAdapter();
                    break;
            }
        }

        /// <summary>
        /// Creates the command.
        /// </summary>
        private void CreateCommand()
        {
            switch (DataCategory)
            {
                case DataCategory.SQLDB:
                    command = new SqlCommand(QueryString, GetConnection<SqlConnection>());
                    break;

                case DataCategory.MSExcel:
                    command = new OleDbCommand(QueryString, GetConnection<OleDbConnection>());
                    break;

                case DataCategory.VSFoxPro:
                    command = new OleDbCommand(QueryString, GetConnection<OleDbConnection>());
                    break;

            }
        }

        private static List<T> CreateList<T>(DbDataReader reader)
        {
            List<T> list = new List<T>();
            Func<object[], T> converter = GetConverter<T>((IDataRecord)reader, 0);
            while (reader.Read())
                list.Add(converter(GetValues((IDataRecord)reader)));
            return list;
        }

        private static Func<object[], T> GetConverter<T>(IDataRecord record, int index)
        {
            Type t = typeof(T);
            if (1 == record.FieldCount - index && record.GetFieldType(index) == t)
                return (Func<object[], T>)(o => (T)o[index]);
            //if (typeof(object[]) == t)
            //{
            //    if (index == 0)
            //        return (Func<object[], T>)(o => (T)o);
            //    return (Func<object[], T>)(o =>
            //    {
            //        object[] objArray = new object[o.Length - index];
            //        Array.Copy((Array)o, index, (Array)objArray, 0, objArray.Length);
            //        return (T)objArray;
            //    });
            //}
            ConstructorInfo ci = GetConstructor(t, record, index);
            if (index == 0)
                return (Func<object[], T>)(o => (T)ci.Invoke(o));
            return (Func<object[], T>)(o =>
            {
                object[] parameters = new object[o.Length - index];
                Array.Copy((Array)o, index, (Array)parameters, 0, parameters.Length);
                return (T)ci.Invoke(parameters);
            });
        }

        private static ConstructorInfo GetConstructor(Type t, IDataRecord record, int index)
        {
            ConstructorInfo constructorInfo = Array.Find<ConstructorInfo>(t.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), (Predicate<ConstructorInfo>)(c =>
            {
                ParameterInfo[] parameters = c.GetParameters();
                if (parameters.Length != record.FieldCount - index)
                    return false;
                for (int index1 = 0; index1 < parameters.Length; ++index1)
                {
                    Type enumType = parameters[index1].ParameterType;
                    Type fieldType = record.GetFieldType(index1 + index);
                    Type[] genericArguments;
                    if (enumType.IsGenericType && typeof(Nullable<>) == enumType.GetGenericTypeDefinition() && ((genericArguments = enumType.GetGenericArguments()) != null && genericArguments.Length > 0))
                        enumType = genericArguments[0];
                    if (!enumType.IsAssignableFrom(fieldType) && (!enumType.IsEnum || !Enum.GetUnderlyingType(enumType).IsAssignableFrom(fieldType)))
                        return false;
                }
                return true;
            }));
            if ((ConstructorInfo)null != constructorInfo)
                return constructorInfo;
            throw new DataException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Unable to find constructor for type {0}. Available constructors do not match source. Source contains fields of type ({1}).", new object[2]
            {
                (object) t.Name,
                (object) string.Join(", ", Enumerable.ToArray<string>(Enumerable.Select<Type, string>((IEnumerable<Type>) GetTypes(record), (Func<Type, string>) (ty => ty.Name))))
            }));
        }

        private static Type[] GetTypes(IDataRecord record)
        {
            Type[] typeArray = new Type[record.FieldCount];
            for (int i = 0; i < record.FieldCount; ++i)
                typeArray[i] = record.GetFieldType(i);
            return typeArray;
        }

        private static object[] GetValues(IDataRecord record)
        {
            object[] values = new object[record.FieldCount];
            record.GetValues(values);
            for (int index = 0; index < values.Length; ++index)
            {
                if (DBNull.Value == values[index])
                    values[index] = (object)null;
            }
            return values;
        }       

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get
            {
                return "DataAccess Plugin";
            }
            set
            {
                Description = value;
            }
        }

    }
}

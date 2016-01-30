using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Data;
using System.Collections;
using log4net;
using Framework;
using System.Data.SqlClient;
using System.Configuration;


namespace AuScGen.CommonUtilityPlugin
{
    /// <summary>
    /// 
    /// </summary>
    [Export(typeof(IContainerPlugin))]
    public class ExcelReader : IContainerPlugin
    {
        /// <summary>
        /// The logger
        /// </summary>
        private log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// The xssfworkbook
        /// </summary>
        static XSSFWorkbook xssfworkbook;
        /// <summary>
        /// The test data set
        /// </summary>
        static DataSet testDataSet;
        /// <summary>
        /// Loads the test data.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="testCaseId">The test case identifier.</param>
        /// <param name="columnNames">The column names.</param>
        /// <returns></returns>
        /// <exception cref="Ecolab.CommonUtilityPlugin.TCDFrameworkException"></exception>
        /// <exception cref="TCDFrameworkException"></exception>
        /// Need to make a singleton object for this everytime it is loading once the excel is readed then
        /// we have to reuse it somewhere....
        public Object[] LoadTestData(string fileName, string sheetName, string testCaseId, string[] columnNames)
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.ThreadContext.Properties["myContext"] = "Logging from ExcelReader class";
            Object[] objectArray = null;
            try
            {
                testDataSet = new DataSet();
                InitializeWorkbook(fileName);
                XlsxToTableData(testCaseId, sheetName, columnNames);
                objectArray = DisplayData(testCaseId, testDataSet.Tables[0]);
            }
            catch(NullReferenceException e)
            {
                string errorMessage = string.Concat("You Have Either Specified  wrong Sheet name"
                        , "or the specified sheet name does not have data for the specified columns");
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new ResourceException(methodName,errorMessage,e);
            }
            return objectArray;
        }

        /// <summary>
        /// Initializes the workbook.
        /// </summary>
        /// <param name="path">The path.</param>
        private void InitializeWorkbook(string path)
        {
            using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    xssfworkbook = new XSSFWorkbook(file);
                }
                catch(NullReferenceException e)
                {
                    string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                    throw new ResourceException(e);
                }
            }
        }

        /// <summary>
        /// XLSXs to table data.
        /// </summary>
        /// <param name="testCaseId">The test case identifier.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="columnNames">The column names.</param>
        /// <exception cref="System.Exception">You Have Either Specified  wrong Sheet name
        /// + or the specified sheet name does not have data for the specified columns</exception>
        private void XlsxToTableData(string testCaseId, string sheetName, string[] columnNames)
        {
            ArrayList list = new ArrayList();
            DataTable dataTable = new DataTable();
            int sheetCount = xssfworkbook.NumberOfSheets;
            Logger.Info(string.Concat("Total Sheets found in the workbook are : [", sheetCount, "]"));
            ISheet sheet = null;
            //Get all sheets and based on passed sheet name get the sheet id
            for (int i = 0; i < sheetCount; i++)
            {
                if (xssfworkbook.GetSheetName(i).Equals(sheetName))
                {
                    sheet = xssfworkbook.GetSheetAt(i);
                    Logger.Info(string.Concat("User had passed Sheetname: [", sheetName, "]"));
                    Logger.Info(string.Concat("Fetching the data for sheet : [", sheetName + "]"));
                    break;
                }
            }
            //Get the column Header
            // sheet = xssfworkbook.GetSheetAt(0);
            Logger.Debug("Fetching the Test Data header information..");
            IRow headerRow = sheet.GetRow(0);
            if (null == headerRow)
            {
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                throw new ResourceException(methodName);
            }
            IEnumerator rows = sheet.GetRowEnumerator();
            //Get the column and row count
            int columnCount = headerRow.LastCellNum;
            int rowCount = sheet.LastRowNum;
            Logger.Info(string.Concat("Total Column count is : [", rowCount + "]"));
            Logger.Info(string.Concat("Total Row count is : [", columnCount + "]"));
            //Add the row data table
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                for (int requiredColumn = 0; requiredColumn < columnNames.Length; requiredColumn++)
                {
                    if (headerRow.GetCell(columnIndex).ToString().Equals(columnNames[requiredColumn]))
                    {
                        
                        list.Add(columnIndex);
                        dataTable.Columns.Add(headerRow.GetCell(columnIndex).ToString());
                                                
                    }
                }
            }

            //Skip reading the Header data
            bool skipReadingHeaderRow = rows.MoveNext();
            while (rows.MoveNext())
            {
                IRow row = (XSSFRow)rows.Current;
                DataRow dataRow = dataTable.NewRow();
                foreach (int i in list)
                {
                    ICell cell = row.GetCell(i);
                    if (cell != null && row.GetCell(0).ToString().Equals(testCaseId))
                    {
                        dataRow[i] = cell.ToString();
                    }
                }
                dataTable.Rows.Add(dataRow);
            }

            xssfworkbook = null;
            sheet = null;
            testDataSet.Tables.Add(dataTable);
        }

        /// <summary>
        /// Displays the data.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns></returns>
        private Object[] DisplayData(string testCaseId, DataTable table)
        {
            ArrayList list;
            ArrayList superList = new ArrayList();
            ArrayList superArray = new ArrayList();
            foreach (DataRow row in table.Rows)
            {
                list = new ArrayList();
                if (row[0].ToString().Equals(testCaseId))
                {
                    for (int count = 0; count < table.Columns.Count; count++)
                    {
                        //if the test case id does not matches with the current TCId
                        //Do not add to list

                        list.Add(row[count].ToString());

                    }
                }
                //If the list is not empty do not add the row
                if (list.Count > 0)
                {
                    superList.Add(list);
                }
            }
            foreach (ArrayList colList in superList)
            {
                Object[] myArr = (Object[])colList.ToArray(typeof(string));
                superArray.Add(myArr);
            }
            Object[] finalArray = (Object[])superArray.ToArray(typeof(object));
            return finalArray;
        }

        public string Description
        {
            get
            {
                return "Excel Reader Plugin";
            }
            set
            {
                Description = value;
            }
        }

        /// Remote the database related Method
        /// <summary>
        /// Gets the data set.
        /// </summary>
        /// <param name="strCommand">The string command.</param>
        /// <returns></returns>
        public DataSet GetData(string strCommand)
        {
            using (SqlConnection con = new SqlConnection("Data Source=HYD-ECOLABDB;Initial Catalog=TCDAutomation;User ID=tcddev;Password=Agstcd@1"))
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                con.Open();
                da = new SqlDataAdapter(strCommand, con);
                da.Fill(ds);
                con.Close();
                con.Dispose();
                return ds;
            }
        }

        /// <summary>
        /// Finds the row exists.
        /// </summary>
        /// <param name="columnValue">The column value.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="strCommand">The string command.</param>
        /// <returns></returns>
        //public bool FindRowExists(string columnName, string columnValue, string strCommand)
        //{
        //    DataView dv = new DataView(GetData(strCommand).Tables[0]);
        //    DataTable dt = new DataTable();
        //    dv.RowFilter = columnName + " = '" + columnValue + "'";
        //    dt = dv.ToTable();
        //    for (int i = 0; i <= dt.Rows.Count; i++)
        //    {

        //    }
        //    if (dt.Rows.Count > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}

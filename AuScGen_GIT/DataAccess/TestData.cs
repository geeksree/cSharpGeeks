using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDMC.DataAccess
{
    public class TestData : BaseTestData
    {
        public TestData(string dataFile)
            :base(dataFile)
        { }

        public List<GenericTestData> GetTestData(string testName)
        {
            DataAccess.QueryString = SQL.Resource.GetTestData;
            return DataAccess.GetData<GenericTestData, OleDbCommand>(command => 
            {
                command.Parameters.AddWithValue("TestName", testName);
            });
        }
        
    }
}

using DataAccess.Entities;
using EDMC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDMC.DataAccess
{
    public class BVTData : BaseTestData
    {
        public BVTData(string dataFile)
            :base(dataFile)
        { }


        public List<EMDCBVT> GetStraightRIFData()
        {
            DataAccess.QueryString = SQL.Resource.GetStrightRIFData;
            return DataAccess.GetData<EMDCBVT>();
        }

        public List<EMDCBVT> GetInvalidRIFData()
        {
            DataAccess.QueryString = SQL.Resource.GetInvalidRIFData;
            return DataAccess.GetData<EMDCBVT>();
        }

        public List<EMDCBVT> GetSourceCodeRIFData()
        {
            DataAccess.QueryString = SQL.Resource.GetSourceCodeData;
            return DataAccess.GetData<EMDCBVT>();
        }
        
    }
}

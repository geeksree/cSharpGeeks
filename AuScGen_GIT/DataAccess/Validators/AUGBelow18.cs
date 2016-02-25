using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDMC.DataAccess.Validators
{
    public class AUGBelow18 : BaseValidator
    {
        public static SampleValidator SampleValidation()
        {
            DataAccess.QueryString = SQL.Resource.SampleValidator;
            return DataAccess.GetData<SampleValidator>().FirstOrDefault();
        }
    }
}

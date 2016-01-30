using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.CommonUtilityPlugin
{
    public class ResponseDataItem
    {
        public ResponseDataItem()
        {
            Data = new Dictionary<string, string>();
        }
        
        public string Name { get; set; }

        public Dictionary<string,string> Data { get; set; }
    }
}

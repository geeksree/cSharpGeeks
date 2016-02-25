using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class GenericTestData : BaseEntity
    {
        public GenericTestData(string name, string data)
        {
            Name = name;
            Data = data;
        }

        public string Name { get; set; }

        public string Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper
{
    public class Keys
    {
        public static string Add 
        { 
            get
            {
                return OpenQA.Selenium.Keys.Add;
            }
        }

        public static string Enter
        {
            get
            {
                return OpenQA.Selenium.Keys.Enter;
            }
        }

        public static string KeyDown
        {
            get
            {
                return OpenQA.Selenium.Keys.ArrowDown;
            }
        }
    }
}

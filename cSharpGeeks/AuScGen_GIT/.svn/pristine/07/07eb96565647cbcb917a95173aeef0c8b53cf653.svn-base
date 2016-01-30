using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.SeleniumTestPage.Config 
{
    public class PageClassSettings : BaseSetings
    {
        private static PageClassSettings defaultInstance = new PageClassSettings();
        private static string settingsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Config");
        private static string settingsFile;

        public static PageClassSettings Default
        {
            get
            {
                settingsFile = Path.Combine(settingsFilePath, "TestSettings.xml");
                return defaultInstance;
            }

        }

        private int maxTimeoutValue = 20000;
        public int MaxTimeoutValue
        {
            get
            {
                string value = GetValue(settingsFile, "MaxTimeoutValue");
                if (null != value)
                {
                    maxTimeoutValue = Convert.ToInt32(value);
                }
                return maxTimeoutValue;
                //return ((int)(this["MaxTimeoutValue"]));
            }
            //set
            //{
            //    this["MaxTimeoutValue"] = value;
            //}
        }   

    }
}

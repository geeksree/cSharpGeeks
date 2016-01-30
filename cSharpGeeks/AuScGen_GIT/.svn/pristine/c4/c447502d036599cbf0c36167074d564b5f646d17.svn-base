using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Xml;
using System.IO;
using System.Diagnostics;

namespace AuScGen
{
    public enum TestType
    {
        functional,
        regression,
        bvt,
        ondemand
    }
    public class TestCategoryAttribute : CategoryAttribute
    {

        private static string ExcludedFilePath 
        { 
            get
            {
                return string.Format(@"{0}\Config\ExcludedTest.xml", Directory.GetCurrentDirectory());
            }
        }
        
        private static List<XmlNode> excludedTestList;
        private static List<XmlNode> ExcludedTestList 
        { 
            get
            {
                if(null == excludedTestList)
                {
                    excludedTestList = new List<XmlNode>();
                    foreach (XmlNode node in GetExcludedTests(ExcludedFilePath))
                    {                        
                        excludedTestList.Add(node);
                    }
                }

                return excludedTestList;

            }
            
        }
        
        public TestCategoryAttribute(TestType type)
            : base(ConvertTestTypeToString(type))
        {}

        public TestCategoryAttribute(TestType type,string testName)
            : base(ConvertTestTypeToString(type, testName))
        { }

        private static string ConvertTestTypeToString(TestType type)
        {
             switch(type)
            {
                 case TestType.functional:
                    return "Functional";
                    
                 case TestType.regression:
                    return "Regression";

                 case TestType.bvt:
                    return "BVT";

                 case TestType.ondemand:
                    return "OnDemand";

                 default:
                    return "Regression";
            }
        }

        private static string ConvertTestTypeToString(TestType type, string testName)
        {
            foreach(XmlNode excludedTestName in ExcludedTestList)
            {
               if (excludedTestName.SelectSingleNode("./TestName").InnerText.Equals(testName))
                {
                    if (null != excludedTestName.SelectSingleNode("./TestSuit"))
                    {
                        return excludedTestName.SelectSingleNode("./TestSuit").InnerText;
                    }
                    else
                    {
                        return "Excluded";
                    }
                   
                }
            }

            return ConvertTestTypeToString(type);
        }

        private static XmlNodeList GetExcludedTests(string XMLPath)
        {
            XmlDocument xmlDoc = GetXmlDoc(XMLPath);

            return xmlDoc.SelectNodes("/TestCases/Test");
        }

        private static XmlDocument GetXmlDoc(string XMLPath)
        {
            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load(XMLPath);
            return XmlDoc;
        }       
    }
}

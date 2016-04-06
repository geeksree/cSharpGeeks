using AuScGen.CommonUtilityPlugin;
using AuScGen.WhiteFramework;
using Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White.UIItems.TabItems;

namespace WhiteTestApp
{
    public abstract class Testbase
    {
        static protected ContainerAccess Container;
        static private WhitePlugin white;
        static protected string GuiMapPath = Directory.GetCurrentDirectory() + @"\GuiMaps\";

        public Testbase()
        {
            Container = new ContainerAccess();
            //White = Container.GetPlugin<WhitePlugin>();
            //white.ProcessName = "calc";
            //white.AppWindowName = "Calculator";


        }

        public WhitePlugin White
        {
            get
            {
                if (null == white)
                {
                    white = Container.GetPlugin<WhitePlugin>();
                    white.ProcessName = "calc";
                    white.AppWindowName = "Calculator";

                    //white.ProcessName = "WinFormsTestApp";
                    //white.AppWindowName = "Form1";
                }
                return white;
            }
        }

        public DataAccess DBAccess
        {
            get
            {
                return Container.GetPlugin<DataAccess>();
            }
        }
    }

    public class Test : Testbase
    {
        public void InvokeTest()
        {
            White.GuiMapPath = GuiMapPath + "GuiMap.xml";

            White.Button("Button9").Click();

            White.Button("AddButton").Click();

            White.Button("Button7").Click();

            //White.Button("EqualButton").Click();
                        
            //Console.WriteLine(White.Label("ResultField").Text);

            
            //List<AuScGen.WhiteFramework.TabPage> test = White.Tab("ControlsTab").Pages();
            //test[3].Select();

            //List<BaseControl> test2 = test.FirstOrDefault().Children.FirstOrDefault().Children.FirstOrDefault().Children;

            //List<AutomationElement> test3 = GetChildren(test2.FirstOrDefault());

            //White.Button("Button9").Click();
            //var test = GetChildren(test1.AutomationElement);
            

            //SearchCriteria aSearch = SearchCriteria.ByAutomationId("buttonInGroupBox");
            //var Test = White.GroupBox("Form1Pane").Get<TestStack.White.UIItems.Button>(aSearch);

            //Rectangle rect = White.Button("").Bounds;

            //White.Hyperlink("").HookEvents()            
        }

        internal static List<AutomationElement> GetChildren(AutomationElement element_in)
        {
            //Trace.TraceInformation(String.Format("{0}: Try to get MSUIA children from AutomationElement...", ""));
            if (null == element_in)
            {
                throw new ArgumentNullException("element_in");
            }
            List<AutomationElement> aList = new List<AutomationElement>(0);
            AutomationElement aChild = TreeWalker.RawViewWalker.GetFirstChild(element_in);

            while (null != aChild)
            {
                aList.Add(aChild);
                aChild = TreeWalker.RawViewWalker.GetNextSibling(aChild);
            }
            //Trace.TraceInformation(String.Format("{0}: MSUIA children from AutomationElement found.", ""));
            return aList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test myTest = new Test();
            myTest.InvokeTest();

            //KeyWordTable keywordTable = new KeyWordTable();
            //keywordTable.KeywordTablePath = Directory.GetCurrentDirectory() + @"\KeyWordTable\" + @"KeywordTable.xml";


            ////TestCase test = new TestCase();
            ////DriverScript.TestDriver testDriver = new TestDriver(keywordTable, test);
            ////testDriver.RunTest();

            //DataDriver testData = new DataDriver();
            //TestCase2 test2 = new TestCase2();
            //testData.Getdata();
            //testData.Getdata();
            //testData.Getdata();
            //DriverScript.TestDriver testDriver2 = new TestDriver(keywordTable, test2, testData);
            //testDriver2.RunDataDrivenTest();

            Console.Read();
        }
    }
}

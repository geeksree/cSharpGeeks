using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Framework;
using NUnit.Framework;
using UIAccess;
using AuScGen.CommonUtilityPlugin;

namespace EDMC.Test
{
    public class TestBase : IDisposable
    {
        private static ContainerAccess container = new ContainerAccess();
        private bool disposed = false;

        public TestBase()
        {
            Console.WriteLine("Test base Constructor");
            //TestFixture();             
        }

        protected static string TestDataPath
        {
            get
            {
                return string.Format(@"{0}\TestData\", Directory.GetCurrentDirectory());
            }
        }

        public static int Timeout 
        {
            get
            {
                return EDMC.Pages.Config.PageClassSettings.Default.MaxTimeoutValue;
            }            
        }

        
        private static WebDriverPlugin aWebDriver;
        public WebDriverPlugin WebDriver
        {
            get
            {
                if (null == aWebDriver)
                {
                    aWebDriver = CreatePlugin<WebDriverPlugin>();
                    aWebDriver.Browser = new WebDriverWrapper.Browser(Utils.BrowserUtil.GetBrowserTypeFromTestSettings);
                    //aWebDriver.Browser = new WebDriverWrapper.Browser(  Utils.BrowserUtil.GetBrowserTypeFromTestSettings
                    //                                                  , Config.TestSettings.Default.BinaryPath);
                }
                return aWebDriver;
            }

            private set
            {
                aWebDriver = value;
            }
        }

        private AuScGen.TestExecutionUtil.TestExecute runner;
        public AuScGen.TestExecutionUtil.TestExecute Runner 
        { 
            get
            {
                if (null == runner)
                {
                    runner = new AuScGen.TestExecutionUtil.TestExecute();
                    runner.Print = new Utils.ScreenShot(WebDriver, Directory.GetCurrentDirectory() + @"\Reports");
                }
                return runner;
            }
        }

        private static AuScGen.CommonUtilityPlugin.ExcelReader myExcel;
        public static AuScGen.CommonUtilityPlugin.ExcelReader Excel
        {
            get
            {
                if (null == myExcel)
                {
                    myExcel = CreatePlugin<AuScGen.CommonUtilityPlugin.ExcelReader>();
                }
                return myExcel;
            }

        }

        private AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator keyBoardSimulator;
        public AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator KeyBoardSimulator
        {
            get
            {
                if (null == keyBoardSimulator)
                {
                    keyBoardSimulator = CreatePlugin<AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator>();
                }
                return keyBoardSimulator;
            }

        }

        private AuScGen.CommonUtilityPlugin.DataAccess dataAccess;
        public AuScGen.CommonUtilityPlugin.DataAccess DBValidation
        {
            get
            {
                dataAccess = CreatePlugin<AuScGen.CommonUtilityPlugin.DataAccess>();
                dataAccess.ConectionString = Config.TestSettings.Default.DBConnection;
                dataAccess.DataCategory = AuScGen.CommonUtilityPlugin.DataCategory.SQLDB;                
                return dataAccess;
            }

        }

        public AuScGen.CommonUtilityPlugin.HttpRestClient ServiceAccess
        {
            get
            {

                return CreatePlugin<AuScGen.CommonUtilityPlugin.HttpRestClient>();
            }

        }

        //private Pages.DialogManager dialogHandler;
        //public Pages.DialogManager DialogHandler 
        //{ 
        //    get
        //    {
        //        if(null == dialogHandler)
        //        {
        //            dialogHandler = new Pages.DialogManager(Telerik);
        //        }
        //        return dialogHandler;
        //    }
        //}

        private Page myPage;
        protected Page Page
        {
            get
            {
                if (null == myPage)
                {
                    myPage = new Page(this);
                }
                return myPage;
            }
        }

        protected string AppUrl
        {
            get
            {
                return Config.TestSettings.Default.Url;
            }
        }
               

        [TestFixtureSetUp]
        public virtual void TestFixtureSetupBase()
        {
            Console.WriteLine("Test Fixture Base");
            WebDriver.Browser.Maximize();
            WebDriver.Browser.Navigate(AppUrl); 
        }

        [TestFixtureTearDown]
        public virtual void TestFixtureTeardownBase()
        {
           WebDriver.Browser.Quit();
           WebDriver = null;
        }
        
        private static T CreatePlugin<T>() where T : IContainerPlugin
        {
            return container.GetPlugin<T>();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                disposed = true;
            }
        }
        public void Dispose()
        {
            //TestFixtureTearDown();
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

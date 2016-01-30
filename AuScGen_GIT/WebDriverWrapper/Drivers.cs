using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using Selenium;
using OpenQA.Selenium.Remote;
using System.Drawing;
using System.IO;

namespace WebDriverWrapper
{
    public enum BrowserType
    {
        Firefox,

        IE,

        Chrome

    }   
    
    public class Browser
    {
        #region Drivers

        private IWebDriver FirefoxDriver 
        { 
            get
            {
                if(null == BinaryPath)
                {
                    Console.WriteLine("null binary path");
                    return new FirefoxDriver();
                }
                else
                {
                    Console.WriteLine(BinaryPath);
                    return new FirefoxDriver(new FirefoxBinary(BinaryPath), new FirefoxProfile());
                }
                
            }
 
        }

        private IWebDriver IEDriver
        {
            get
            {
            	return new InternetExplorerDriver(Config.DriverServerPath);
            }

        }

        private IWebDriver ChromeDriver
        {
            get
            {
                return new ChromeDriver(Config.DriverServerPath);
            }

        }
		
        

        #endregion Drivers 

        #region Private Properties

        private string BinaryPath { get; set; }

        #endregion Private Properties

        #region Internal Properties
        internal WebDriverBackedSelenium BackedSelenium 
	        { 
	        	get
	        	{
	        		WebDriverBackedSelenium aDriverBackedSelenium = new WebDriverBackedSelenium(BrowserHandle,Url);
	        		aDriverBackedSelenium.Start();
	        		return aDriverBackedSelenium;
	        	}         
	        }
		
		internal IWebDriver BrowserHandle;

        internal BrowserType BrowserType;
		        
		#endregion Internal Properties        

        #region ctor

        public Browser(BrowserType aBrowserType)
        {
            GetBrowser(aBrowserType);
        }

        public Browser(BrowserType aBrowserType, string binaryPath)            
        {
            BinaryPath = binaryPath;
            GetBrowser(aBrowserType);
        }

        #endregion ctor

        #region Public Properties

        public string Title 
        {
            get
            {
                return BrowserHandle.Title;
            }

        }

        public string Url 
        {
            get
            {
                return BrowserHandle.Url;
            }
        }                                       

        public string CurrentWindowHandle 
        {
            get
            {
                return BrowserHandle.CurrentWindowHandle;
            }      
           
        }

        #endregion Public Properties

        #region Public  Methods

        public void GetBrowser(BrowserType aBrowserType)
        {
//            ConfigureJava();
//            
//            Environment.SetEnvironmentVariable("JAVA_HOME",@"C:\Program Files\Java\jre7");
//            Environment.SetEnvironmentVariable("JAVA",@"%JAVA_HOME%\bin\java.exe");
//            Environment.SetEnvironmentVariable("JAVA_OPTS",@"%JAVA_TOOL_OPTONS% %_JAVA_OPTIONS%");
//            Environment.SetEnvironmentVariable("JAVA_TOOL_OPTIONS",null);
//            Environment.SetEnvironmentVariable("_JAVA_OPTIONS",null);
            
        	BrowserType = aBrowserType;

            if (aBrowserType == BrowserType.Firefox)
            {
                BrowserHandle = FirefoxDriver;
            }

            if (aBrowserType == BrowserType.IE)
            {
                BrowserHandle = IEDriver;
            }

            if (aBrowserType == BrowserType.Chrome)
            {
                BrowserHandle = ChromeDriver;
            }            
        }

        public void SwitchBrowser(string BrowserTitle)
        {
            string CurrentWindow = CurrentWindowHandle;

            IEnumerable<string> AvailableWindowHandles = BrowserHandle.WindowHandles;

            foreach (string availableWindowHandle in AvailableWindowHandles)
            {
                if (BrowserHandle.SwitchTo().Window(availableWindowHandle).Title.Equals(BrowserTitle))
                {
                    BrowserHandle.SwitchTo().Window(availableWindowHandle);
                }
            }
            //BrowserHandle = BrowserHandle.SwitchTo().Window(BrowserTitle);

        }

        public void Navigate(string Url)
        {
            BrowserHandle.Navigate().GoToUrl(Url);            
        }

        public void Maximize()
        {
            BrowserHandle.Manage().Window.Maximize();
        }

        public void DeleteAllCookies()
        {
            BrowserHandle.Manage().Cookies.DeleteAllCookies();
        }

        public object ExecuteJavaScript(string JavaScript)
        {
            return ((IJavaScriptExecutor)BrowserHandle).ExecuteScript(JavaScript);
        }

        public Bitmap TakeSreenShot()
        {
            var ms = new MemoryStream(((ITakesScreenshot)BrowserHandle).GetScreenshot().AsByteArray);
            return new Bitmap(ms);
        }

        public void GoBack()
        {
            BrowserHandle.Navigate().Back();
        }

        public void GoForward()
        {
            BrowserHandle.Navigate().Forward();
        }

        public void Refresh()
        {
            BrowserHandle.Navigate().Refresh();
        }

        public void Close()
        {
            BrowserHandle.Close();
        }

        public void Quit()
        {
            BrowserHandle.Quit();
        }      
        
        public void WaitForPageLoaded(int Timeout)
        {
            WebDriverBackedSelenium aDriverBackedSelenium = new WebDriverBackedSelenium(BrowserHandle, Url);

            aDriverBackedSelenium.Start();
            aDriverBackedSelenium.WaitForPageToLoad(Timeout.ToString(CultureInfo.InvariantCulture));            
        }

        #endregion Public  Methods

        private IntPtr WinGetHandle(string wName)
        {
            IntPtr hWnd = new IntPtr();

            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains(wName))
                {
                    hWnd = pList.MainWindowHandle;
                }
            }

            return hWnd;
        }
        
        private void ConfigureJava()
        {
        	//Process.Start(Config.IEDriverServerPath + "java.bat");
        	
        	Process p = new Process();

			p.StartInfo.FileName = "cmd.exe";
			
			p.StartInfo.Arguments = @"/C " + Config.DriverServerPath + @"\java.bat";
			
			p.Start();
			
			p.WaitForExit();

        }
    }
}

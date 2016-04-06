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
using System.Net.Sockets;
using System.Collections.ObjectModel;

namespace WebDriverWrapper
{
    public enum BrowserType
    {
        Firefox,

        IE,

        Chrome,

        HTMLUnit

    }

    public class Browser
    {
        #region Drivers

        private IWebDriver FirefoxDriver
        {
            get
            {
                //string downloadDir = string.Format(@"{0}\DownloadedFiles",Directory.GetCurrentDirectory());

                if (!Directory.Exists(DownloadDirectory))
                {
                    Directory.CreateDirectory(DownloadDirectory);
                }

                FirefoxProfile firefoxProfile = new FirefoxProfile();
                firefoxProfile.SetPreference("browser.download.folderList", 2);
                firefoxProfile.SetPreference("browser.download.dir", DownloadDirectory);
                //firefoxProfile.SetPreference("browser.helperApps.alwaysAsk.force", false); 

                firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf");
                firefoxProfile.SetPreference("browser.helperApps.alwaysAsk.force", false);
                firefoxProfile.SetPreference("pdfjs.disabled", true);
                firefoxProfile.SetPreference("plugin.scan.plid.all", false);

                if (null == BinaryPath)
                {
                    Console.WriteLine("null binary path");
                    return new FirefoxDriver(firefoxProfile);
                }
                else
                {
                    Console.WriteLine(BinaryPath);
                    return new FirefoxDriver(new FirefoxBinary(BinaryPath), firefoxProfile, TimeSpan.FromHours(2));
                }

            }

        }

        private IWebDriver IEDriver
        {
            get
            {
                InternetExplorerOptions options = new InternetExplorerOptions();
                options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                options.IgnoreZoomLevel = true;
                return new InternetExplorerDriver(Config.DriverServerPath,options);
            }

        }

        private IWebDriver ChromeDriver
        {
            get
            {
                return new ChromeDriver(Config.DriverServerPath);
            }

        }

        private IWebDriver HTMLUnit
        {
            get
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("java.exe", string.Format(@"-jar {0}\selenium-server-standalone-2.8.0.jar -port {1} -trustAllSSLCertificates", Config.NativeSeleniumDriver, Port));
                //startInfo.FileName = Config.NativeSeleniumDriver;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = false;
                startInfo.RedirectStandardOutput = true;

                //Start the process
                NativeSeleniumProcess = Process.Start(startInfo);

                //NativeSeleniumProcess = Process.Start(Config.NativeSeleniumDriver);

                while (!IsConnected()) ;
                return new RemoteWebDriver(new Uri(string.Format(@"http://127.0.0.1:{0}/wd/hub", Port)), DesiredCapabilities.HtmlUnit(), TimeSpan.FromHours(2));
            }
        }

        #endregion Drivers

        #region Private Properties

        public string BinaryPath { get; set; }

        #endregion Private Properties

        #region Internal Properties
        internal WebDriverBackedSelenium BackedSelenium
        {
            get
            {
                WebDriverBackedSelenium aDriverBackedSelenium = new WebDriverBackedSelenium(BrowserHandle, Url);
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

        public Browser(BrowserType aBrowserType, int port)
        {
            Port = port;
            GetBrowser(aBrowserType);
        }

        public Browser(BrowserType aBrowserType, string binaryPath, string downloadDirectory)
        {
            BinaryPath = binaryPath;
            DownloadDirectory = downloadDirectory;
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

        public ReadOnlyCollection<string> WindowHandles
        {
            get
            {
                return BrowserHandle.WindowHandles;
            }
        }



        public Process NativeSeleniumProcess { get; private set; }
        public int Port { get; private set; }
        public string DownloadDirectory { get; set; }

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

            if (aBrowserType == BrowserType.HTMLUnit)
            {
                BrowserHandle = HTMLUnit;
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

        public void SwitchToFrame(int FrameIndex)
        {
            BrowserHandle.SwitchTo().Frame(FrameIndex);
        }

        //public void SwitchToFrame(IWebElement WebElement)
        //{
        //    BrowserHandle.SwitchTo().Frame(WebElement);
        //}

        public void SwitchToFrame(string FrameName)
        {
            BrowserHandle.SwitchTo().Frame(FrameName);
        }

        public void SwitchToDefaultContent()
        {
            BrowserHandle.SwitchTo().DefaultContent();
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
            BrowserHandle.Dispose();
        }

        public void WaitForPageLoaded(int Timeout)
        {
            WebDriverBackedSelenium aDriverBackedSelenium = new WebDriverBackedSelenium(BrowserHandle, Url);

            aDriverBackedSelenium.Start();
            aDriverBackedSelenium.WaitForPageToLoad(Timeout.ToString(CultureInfo.InvariantCulture));
        }

        #endregion Public  Methods

        private bool IsConnected()
        {
            TcpClient client = new TcpClient();
            Console.WriteLine("Connecting.....");
            try
            {
                client.Connect("127.0.0.1", Port);
                Console.WriteLine("True");
                return true;
            }
            catch
            {
                Console.WriteLine("False");
                return false;
            }
        }

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

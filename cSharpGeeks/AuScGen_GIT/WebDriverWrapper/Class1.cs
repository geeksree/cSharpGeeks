using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace WebDriver_Test
{    
    public class Class1
    {
        private static IWebDriver driver;
        
        //private static ISelenium selenium;

        
        
        public static void setup()
        {
            
            IWebDriver driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"),DesiredCapabilities.HtmlUnit());
                        
            //driver = new FirefoxDriver();
            Selenium.WebDriverBackedSelenium s = new Selenium.WebDriverBackedSelenium(driver, @"http://site4.way2sms.com/content/index.html");
            s.Start();
            driver.Navigate().GoToUrl("http://site4.way2sms.com/content/index.html");
            
            
            WaitForLinkTextPresent(driver, "► click here to go to way2sms.com", 40);
            driver.FindElement(By.Id("username")).SendKeys("9916089888");
            driver.FindElement(By.Id("password")).SendKeys("suprwolf");
            driver.FindElement(By.Id("button")).Click();
            

            if (WaitIdPresent(driver, "quickclose1",40000))
            {
                driver.FindElement(By.Id("quickclose1")).Click();
            }

            driver.FindElement(By.Id("quicksms")).Click();
            driver.SwitchTo().Frame("frame");
            s.WaitForPageToLoad("30000");
            driver.FindElement(By.Id("MobNo")).SendKeys("9916089888");
            WaitIdPresent(driver, "textArea", 400);
            driver.FindElement(By.Id("textArea")).SendKeys("test");

            driver.FindElement(By.Id("Send")).Submit();
            driver.FindElement(By.LinkText("Logout")).Clear();
           
            
        }

        public static bool WaitForLinkTextPresent(IWebDriver myWebDriver, string Locator, int MaxWaitSec)
        {
            int theWaitTime;

            for (theWaitTime = 1; theWaitTime <= MaxWaitSec; theWaitTime++)
            {
                try
                {
                    if (driver.FindElement(By.LinkText(Locator)).Displayed) break;
                    Thread.Sleep(1000);
                }
                catch { }
            }

            if (theWaitTime > MaxWaitSec)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool WaitIdPresent(IWebDriver myWebDriver, string Locator, int MaxWaitSec)
        {
            int theWaitTime;

            for (theWaitTime = 1; theWaitTime <= MaxWaitSec; theWaitTime++)
            {
                try
                {
                    if (driver.FindElement(By.Id(Locator)).Displayed) break;
                    Thread.Sleep(1000);
                }
                catch { }
            }

            if (theWaitTime > MaxWaitSec)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    
//    public class ReusableRemoteWebDriver : RemoteWebDriver
//    {
//    	public ReusableRemoteWebDriver(Uri BaseUri, DesiredCapabilities BrowserCapabilites)
//    		:base(BaseUri,BrowserCapabilites){}
//    	
////    	ReusableRemoteWebDriver(String sessionId, URL remoteUrl) {
////		HttpCommandExecutor executor = new HttpCommandExecutor(remoteUrl);
////		setSessionId(sessionId);
////		setCommandExecutor(executor);
////}
//    	
//		public string Session { get; set; }
//    	
//    	public void StartSession(ICapabilities desiredCapabilities)
//    	{
//    		String sid = Session;
//			if (sid != null) {
//			  setSessionId(sid);
//			  try {
//			    getCurrentUrl();
//			  } catch (WebDriverException e) {
//			    // session is not valid
//			    sid = null;
//			  }
//			}
//			if (sid == null) {
//			  base.StartSession(desiredCapabilities);
//			  //saveSessionIdToSomeStorage(getSessionId().toString());
//			}
//
//    	}
//    	
//    }
}
    
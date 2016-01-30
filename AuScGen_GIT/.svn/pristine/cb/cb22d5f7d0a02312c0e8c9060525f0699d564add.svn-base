using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.Collections.ObjectModel;



namespace WebDriverWrapper
{
    public enum LocatorType
    {
        Id,
        Name,
        PartialLinkText,
        Css,
        Xpath,
        TagName,
        LinkText,
        ClassName
    }

    public enum ControlType
    {
        Button,

        EditBox,
        
        Custom,

        Calender,

        ComboBox,

        CheckBox,

        Dialog,

        Frame,

        Image,

        Label,

        Link,

        ListBox,

        Page,

        RadioButton,

        SpanArea,

        WebTable,

        WebRow,

        WebCell
    }

    public class ControlAccess : IControlAccess
    {
        public Browser Browser { get; set; }

        public string Locator { get; set; }

        public LocatorType LocatorType { get; set; }

        public ControlType ControlType { get; set; }

        //public BrowserType BrowserType { get; set; }
        
        private IWebElement aWebElement;
        private ReadOnlyCollection<IWebElement> aWebElements;
        private IWebDriver aWebDriver;
        private string aLocator;
        private LocatorType aLocatorType;
        private ControlType aControlType;
        private BrowserType aBrowserType;

        public void IntializeControlAccess()
        {
            aBrowserType = Browser.BrowserType;
            aWebDriver = Browser.BrowserHandle;
            aLocatorType = LocatorType;
            aLocator = Locator;
            aControlType = ControlType;            
        }

        private void InitializeWebElement()
        {
            if (LocatorType == LocatorType.Id)
            {
                aWebElement = aWebDriver.FindElement(By.Id(aLocator));
            }

            if (LocatorType == LocatorType.Name)
            {
                aWebElement = aWebDriver.FindElement(By.Name(aLocator));               
            }

            if (LocatorType == LocatorType.Css)
            {
                aWebElement = aWebDriver.FindElement(By.CssSelector(aLocator));
            }

            if (LocatorType == LocatorType.TagName)
            {
                aWebElement = aWebDriver.FindElement(By.TagName(aLocator));
            }

            if (LocatorType == LocatorType.Xpath)
            {
                aWebElement = aWebDriver.FindElement(By.XPath(aLocator));
            } 

			if (LocatorType == LocatorType.LinkText)
            {
				aWebElement = aWebDriver.FindElement(By.LinkText(aLocator));
            }

			if (LocatorType == LocatorType.ClassName)
            {
				aWebElement = aWebDriver.FindElement(By.ClassName(aLocator));
            } 			
			
            
        }

        private void InitializeWebElements()
        {
            if (LocatorType == LocatorType.Id)
            {
                aWebElements = aWebDriver.FindElements(By.Id(aLocator));
            }

            if (LocatorType == LocatorType.Name)
            {
                aWebElements = aWebDriver.FindElements(By.Name(aLocator));
            }

            if (LocatorType == LocatorType.Css)
            {
                aWebElements = aWebDriver.FindElements(By.CssSelector(aLocator));
            }

            if (LocatorType == LocatorType.TagName)
            {
                aWebElements = aWebDriver.FindElements(By.TagName(aLocator));
            }

            if (LocatorType == LocatorType.Xpath)
            {
                aWebElements = aWebDriver.FindElements(By.XPath(aLocator));
            }

            if (LocatorType == LocatorType.LinkText)
            {
                aWebElements = aWebDriver.FindElements(By.LinkText(aLocator));
            }

            if (LocatorType == LocatorType.ClassName)
            {
                aWebElements= aWebDriver.FindElements(By.ClassName(aLocator));
            }


        }               

        public bool IsElementPresent()
        {
            try
            {
                InitializeWebElement();
            }
            catch(NoSuchElementException)
            {
                return false;
            }
            
            return true;
        }

        public Actions Action
        {
            get
            {
                return new Actions(aWebDriver, aWebElement);
            }
        }
        
        public void ClickAt()
        {
        	Browser.BackedSelenium.ClickAt(aLocator,"0,0");
        }

        public IControl GetControl()
        {
            InitializeWebElement();
            return Utility.GetControlFromWebElement(aWebElement, aControlType,this);
        }
        
        public ReadOnlyCollection<IControl> GetControls()
        {
            InitializeWebElements();
            return Utility.GetControlsFromWebElements(aWebElements, aControlType,this).AsReadOnly();
        }
        
        public List<IControl> GetChildren(string Locator, LocatorType aLocatorType, ControlType aControlType)
        {
            return Utility.GetChildren(Locator, aLocatorType, aControlType,aWebElement,this);                        
        } 

    }
}

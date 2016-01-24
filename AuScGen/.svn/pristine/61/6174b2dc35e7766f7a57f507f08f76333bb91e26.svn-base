using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper.IControlHierarchy;

namespace WebDriverWrapper
{
    public class SeleniumWebCalender : SeleniumWebControls, ICalender
    {
        private ControlAccess controlAccess;
        internal SeleniumWebCalender(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : base(aWebElement, aControlType,access)
        {
            controlAccess = access;
        }


        //public ReadOnlyCollection<SeleniumWebButton> MoveToNextMonth()
        //{
        //    return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.TagName("a")), ControlType.Button, controlAccess).Cast<SeleniumWebButton>().ToList().AsReadOnly();
        //}

        public SeleniumWebControls GetCalenderHeader(string locator, LocatorType locatorType)
        {
            switch(locatorType)
            {
                case LocatorType.ClassName:
                    return (SeleniumWebControls)Utility.GetControlFromWebElement(aWebElement.FindElement(By.ClassName(locator)), ControlType.Custom, controlAccess);

                case LocatorType.Css:
                    return (SeleniumWebControls)Utility.GetControlFromWebElement(aWebElement.FindElement(By.CssSelector(locator)), ControlType.Custom, controlAccess);

                case LocatorType.Id:
                    return (SeleniumWebControls)Utility.GetControlFromWebElement(aWebElement.FindElement(By.Id(locator)), ControlType.Custom, controlAccess);

                case LocatorType.LinkText:
                    return (SeleniumWebControls)Utility.GetControlFromWebElement(aWebElement.FindElement(By.LinkText(locator)), ControlType.Custom, controlAccess);

                case LocatorType.Name:
                    return (SeleniumWebControls)Utility.GetControlFromWebElement(aWebElement.FindElement(By.Name(locator)), ControlType.Custom, controlAccess);

                case LocatorType.PartialLinkText:
                    return (SeleniumWebControls)Utility.GetControlFromWebElement(aWebElement.FindElement(By.PartialLinkText(locator)), ControlType.Custom, controlAccess);

                case LocatorType.Xpath:
                    return (SeleniumWebControls)Utility.GetControlFromWebElement(aWebElement.FindElement(By.XPath(locator)), ControlType.Custom, controlAccess);

                default:
                    return (SeleniumWebControls)Utility.GetControlFromWebElement(aWebElement.FindElement(By.TagName(locator)), ControlType.Custom, controlAccess);
                               
            }
        }


        public SeleniumWebControls GetMonthAndYear(string locator, LocatorType locatorType, string headerLocator, LocatorType headerLocatorType)
        {

            return (SeleniumWebControls)Utility.GetControlFromWebElement(GetCalenderHeader(headerLocator, headerLocatorType).aWebElement.FindElement(By.ClassName(locator)), ControlType.Custom, controlAccess);
        }
    }
}

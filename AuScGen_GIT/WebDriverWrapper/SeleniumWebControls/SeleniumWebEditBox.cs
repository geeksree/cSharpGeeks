using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper.IControlHierarchy;

namespace WebDriverWrapper
{
    public class SeleniumWebEditBox : SeleniumWebControls, IEditBox
    {
        internal SeleniumWebEditBox(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : base(aWebElement, aControlType,access)
        { }

        /// <summary>
        /// Works only for Id, Name, ClassName and TagName , for any other locator type default Id is used
        /// </summary>
        /// <param name="aText"></param>
        public void JSSendKeys(string aText)
        {
            switch (aControlAccess.LocatorType)
            {
                case LocatorType.Id:
                    ExecuteJavaScript(aControlAccess.Browser, string.Format("document.getElementById('{0}').value='{1}'", aControlAccess.Locator, aText));
                    break;

                case LocatorType.Name:
                    ExecuteJavaScript(aControlAccess.Browser, string.Format("document.getElementsByName('{0}')[0].value='{0}'", aControlAccess.Locator, aText));
                    break;

                case LocatorType.ClassName:
                    ExecuteJavaScript(aControlAccess.Browser, string.Format("document.getElementsByClassName('{0}')[0].value='{0}'", aControlAccess.Locator, aText));
                    break;

                case LocatorType.PartialLinkText:
                    break;
                case LocatorType.TagName:
                    ExecuteJavaScript(aControlAccess.Browser, string.Format("document.getElementsByTagName('{0}')[0].value='{0}'", aControlAccess.Locator, aText));
                    break;

                default:
                    ExecuteJavaScript(aControlAccess.Browser, string.Format("document.getElementById('{0}').value='{0}'", aControlAccess.Locator, aText));
                    break;
            }

        }


        public void Clear()
        {
            aWebElement.Clear();
        }
    }
}

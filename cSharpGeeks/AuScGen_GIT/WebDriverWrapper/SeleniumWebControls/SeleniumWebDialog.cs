using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper.IControlHierarchy;

namespace WebDriverWrapper
{
    public class SeleniumWebDialog : SeleniumWebControls, IDialog
    {
        internal SeleniumWebDialog(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : base(aWebElement, aControlType,access)
        { }


        public string getTitle()
        {
            throw new NotImplementedException();
        }

        public void AcceptDialog()
        {
            aControlAccess.Action.WebDriver.SwitchTo().Alert().Accept();
        }

        public void CancelDialog()
        {
            aControlAccess.Action.WebDriver.SwitchTo().Alert().Dismiss();
        }
    
        public string GetDialogText()
        {
           return aControlAccess.Action.WebDriver.SwitchTo().Alert().Text;
        }

        public void SendText(string text)
        {
            aControlAccess.Action.WebDriver.SwitchTo().Alert().SendKeys(text);
        }                   

    }
}

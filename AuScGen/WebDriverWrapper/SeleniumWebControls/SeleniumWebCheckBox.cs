using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper.IControlHierarchy;

namespace WebDriverWrapper
{
    public class SeleniumWebCheckBox : SeleniumWebControls, ICheckBox
    {
        internal SeleniumWebCheckBox(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : base(aWebElement, aControlType,access)
        { }

        public void Check()
        {
            if(!IsChecked)
            {
                aWebElement.Click();
            }
        }       
    }
}

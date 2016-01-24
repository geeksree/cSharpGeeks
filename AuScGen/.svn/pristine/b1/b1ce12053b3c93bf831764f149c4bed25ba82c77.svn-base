using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper.IControlHierarchy;

namespace WebDriverWrapper
{
    public class SeleniumWebRadioButton : SeleniumWebControls, IRadioButton
    {
        internal SeleniumWebRadioButton(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : base(aWebElement, aControlType,access)
        { }


        public void check()
        {
            if (!IsChecked)
            {
                aWebElement.Click();
            }
        }
    }
}

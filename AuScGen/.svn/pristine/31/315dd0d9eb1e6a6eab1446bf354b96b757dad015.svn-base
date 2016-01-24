using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using WebDriverWrapper.IControlHierarchy;
using System.Collections.ObjectModel;

namespace WebDriverWrapper
{
    public class SeleniumWebTable : SeleniumWebControls, IWebTable
    {
        private ControlAccess controlAccess;
        internal SeleniumWebTable(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : base(aWebElement, aControlType,access)
        {
            controlAccess = access;
        }

        /// <summary>
        /// Gets all rows.
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<SeleniumWebRow> GetAllRows()
        {
            return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.TagName("tr")), ControlType.WebRow, controlAccess).Cast<SeleniumWebRow>().ToList().AsReadOnly();
        }

    }
}

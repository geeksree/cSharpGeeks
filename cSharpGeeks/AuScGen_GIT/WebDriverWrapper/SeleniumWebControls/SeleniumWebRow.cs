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
    public class SeleniumWebRow : SeleniumWebControls, IWebRow
    {
        private ControlAccess controlAccess;
        
        internal SeleniumWebRow(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : base(aWebElement, aControlType, access)
        {
            controlAccess = access;
        }

        //public ReadOnlyCollection<IWebElement> GetCells()
        //{
        //    return aWebElement.FindElements(By.TagName("td"));
        //}

        

        public ReadOnlyCollection<SeleniumWebCell> GetAllCells()
        {
            return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.TagName("td")), ControlType.WebCell, controlAccess).Cast<SeleniumWebCell>().ToList().AsReadOnly();
        }
    }
}


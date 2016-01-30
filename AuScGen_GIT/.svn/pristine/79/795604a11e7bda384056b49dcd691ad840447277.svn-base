using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebRow : WebControl
    {
        private Browser browser;
        private Locator locator;

        public WebRow(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.WebRow)
        {
            browser = aBrowser;
            locator = aLocator;
        }
        private IWebRow WebRows
        {
            get
            {
                return (IWebRow)Control;
            }
        }
        public ReadOnlyCollection<WebCell> GetCells
        {
            get
            {
                return Utility.GetWebControlsFromIControlList(WebRows.GetAllCells().Cast<IControl>().ToList(), browser, locator, ControlType.WebCell).Cast<WebCell>().ToList().AsReadOnly();
            }
        }
    }
}

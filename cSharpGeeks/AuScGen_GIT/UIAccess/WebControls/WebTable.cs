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
    public class WebTable : WebControl
    {
        private Browser browser;
        private Locator locator;

        public WebTable(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.WebTable)
        {
            browser = aBrowser;
            locator = aLocator;
        }

        private IWebTable WebTables
        {
            get
            {
                return (IWebTable)Control;
            }
        }

        public ReadOnlyCollection<WebRow> GetRows 
        { 
            get
            {
                return Utility.GetWebControlsFromIControlList(WebTables.GetAllRows().Cast<IControl>().ToList(), browser, locator, ControlType.WebRow).Cast<WebRow>().ToList().AsReadOnly();
            }
        }

        public WebRow GetRowWithValue(string value)
        {
            foreach(WebRow row in GetRows)
            {
                if(row.Text.Equals(value))
                {
                    return row;
                }
            }
            return null;
        }
    }
}

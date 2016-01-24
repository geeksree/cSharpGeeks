using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebListBox : WebControl
    {
        public WebListBox(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.ListBox)
        { }

        private IListBox ListBox
        {
            get
            {
                return (IListBox)Control;
            }
        }
    }
}

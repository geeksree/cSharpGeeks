using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebLabel : WebControl
    {
        public WebLabel(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.Label)
        { }

        private ILabel Label
        {
            get
            {
                return (ILabel)Control;
            }
        }
    }
}

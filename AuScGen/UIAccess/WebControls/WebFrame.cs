using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebFrame : WebControl
    {
        public WebFrame(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.Frame)
        { }

        private IFrame Frame
        {
            get
            {
                return (IFrame)Control;
            }
        }
    }
}

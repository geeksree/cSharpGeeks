using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebButton : WebControl
    {
        public WebButton(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.Button)
        { }

        private IButton Button
        {
            get
            {
                return (IButton)Control;
            }
        }

        public new void Click()
        {
            Button.Click();
        }

    }
}

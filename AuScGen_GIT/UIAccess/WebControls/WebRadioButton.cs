using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebRadioButton : WebControl
    {
        public WebRadioButton(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.RadioButton)
        { }

        private IRadioButton RadioButton
        {
            get
            {
                return (IRadioButton)Control;
            }
        }
    }
}

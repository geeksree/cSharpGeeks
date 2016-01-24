using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebCheckBox : WebControl
    {
        public WebCheckBox(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.CheckBox)
        { }

        private ICheckBox CheckBox
        {
            get
            {
                return (ICheckBox)Control;
            }
        }

        public void Check()
        {
            CheckBox.Check();
        }
                
    }
}

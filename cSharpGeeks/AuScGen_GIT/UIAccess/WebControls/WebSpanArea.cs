using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebSpanArea : WebControl
    {
        public WebSpanArea(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.SpanArea)
        { }

        private ISpanArea SpanArea
        {
            get
            {
                return (ISpanArea)Control;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebEditBox : WebControl
    {
        public WebEditBox(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.EditBox)
        { }

        private IEditBox EditBox
        {
            get
            {
                return (IEditBox)Control;
            }
        }

        /// <summary>
        /// Works only for Id, Name, ClassName and TagName , for any other locator type default Id is used
        /// </summary>
        /// <param name="Text"></param>
        public void JSSendKeys(string Text)
        {
            EditBox.JSSendKeys(Text);            
        }

        public void Clear()
        {
            EditBox.Clear();
        }

    } 
}

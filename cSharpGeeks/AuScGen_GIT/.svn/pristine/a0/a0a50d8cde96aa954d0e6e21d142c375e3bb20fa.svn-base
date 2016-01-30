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
    public class WebDialog : WebControl
    {
        public WebDialog(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.Dialog)
        { }
   
        private IDialog Dialog
        {
            get
            {
                return (IDialog)Control;
            }
        }


        public void Test()
        {
            Dialog.getTitle();
        }


        public void AcceptDialog()
        {
            Dialog.AcceptDialog();
        }

        public void CancelDialog()
        {
            Dialog.CancelDialog();
        }

        public string GetDialogText()
        {
            return Dialog.GetDialogText();
        }
        public void SendText(string value)
        {
            Dialog.SendText(value);
        }


    }
}

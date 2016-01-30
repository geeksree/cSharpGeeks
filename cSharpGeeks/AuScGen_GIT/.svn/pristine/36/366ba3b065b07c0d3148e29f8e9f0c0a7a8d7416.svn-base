using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAccess.WebControls;
using WebDriverWrapper;

namespace UIAccess
{
    public class Actions
    {
        private ControlAccess thisControlAccess;

        public Actions(ControlAccess controlAccess)
        {
            thisControlAccess = controlAccess;
        }

        public void MoveToElement(WebControl webElement)
        {
            thisControlAccess.Action.MoveToElement(webElement.Control);            
        }

        public void MoveToElement(int offSetX, int offSetY)
        {
            thisControlAccess.Action.MoveToElement(offSetX, offSetY);
        }

        public void DragDrop(WebControl target)
        {
            thisControlAccess.Action.DragDrop(target.Control);
        }

        public void DragDropToOffset(int offSetX, int offSetY)
        {
            thisControlAccess.Action.DragDropToOffset(offSetX, offSetY);
        }

        public void NativeSelect(WebControl webElement)
        {
            thisControlAccess.Action.NativeSelect(webElement.Control);
        }

        public void SendKeys(string keys)
        {
            thisControlAccess.Action.SendKeys(keys);
        }

        public void SendKeys(WebControl webElement, string keys)
        {
            thisControlAccess.Action.SendKeys(webElement.Control, keys);
        }
    }
}

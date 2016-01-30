using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;


namespace AuScGen
{
    public static class HtmlInputTextExtension
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;

        private static void MouseClick(int x , int y)
        {
            //int x = 100;
            //int y = 100;
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }
        
        public static void TypeText(this HtmlControl control, string text)
        {
            if(control.TagName == "input")
            {
                HtmlInputText ctrl = new HtmlInputText(control.BaseElement);
                ctrl.Text = string.Empty;
                ctrl.Focus();
                ctrl.ExtendedMouseClick();
                ctrl.Text = text;
                ctrl.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
            }
            else
            {
                control.Focus();
                control.ExtendedMouseClick();
                control.OwnerBrowser.Manager.Desktop.KeyBoard.TypeText(text);
                control.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
            }    
        }
        public static void SingleTabClickButton(this HtmlControl control)
        {
            
            control.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Enter);
        }
        public static void MultiTabClickButton(this HtmlButton control)
        {
            control.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
            control.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Enter);
        }
        public static void SetText(this HtmlControl control, string text)
        {
            if (control.TagName == "input")
            {
                HtmlInputText ctrl = new HtmlInputText(control.BaseElement);
                ctrl.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
                ctrl.Text = string.Empty;
                ctrl.Focus();
                ctrl.ExtendedMouseClick();
                ctrl.Text = text;
                ctrl.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Space);
                ctrl.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
            }
            else
            {
                control.Focus();
                control.ExtendedMouseClick();
                control.OwnerBrowser.Manager.Desktop.KeyBoard.TypeText(text);
                control.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
            }
        }

        public static void DeskTopMouseClick(this HtmlControl control)
        {
            
            Rectangle rect = control.GetRectangle();
            int x = rect.X + rect.Width/2;
            int y = rect.Y + rect.Height/2;

            //control.OwnerBrowser.Manager.Desktop.Mouse.HoverOver(new Point(x, y));
            //control.OwnerBrowser.Manager.Desktop.Mouse.Click(MouseClickType.LeftClick, new Point(x, y));
            MouseClick(x, y);
        }

        public static void ExtendedMouseClick(this HtmlControl control)
        {
            if(control.OwnerBrowser.BrowserType != BrowserType.Chrome)
            {
                control.MouseClick();
            }
            else
            {
                control.Focus();
                control.Click();
            }
        }
    }
}

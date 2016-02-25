using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper
{
    public class Win32
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern long SetCursorPos(int x, int y);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int MIDDLEDOWN = 0x00000020;
        private const int MIDDLEUP = 0x00000040;
        private const int MOVE = 0x00000001;
        private const int ABSOLUTE = 0x00008000;

        private static void MouseClick(int x, int y)
        {
            //int x = 100;
            //int y = 100;
            SetCursorPos(x, y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private static void MouseDrag(int startX, int startY, int endX, int endY)
        {
            SetCursorPos(startX, startX);
            mouse_event(MOUSEEVENTF_LEFTDOWN, startX, startY, 0, 0);
            mouse_event(ABSOLUTE, endX, endX, 0, 0);
            //SetCursorPos(endX, endX);
            mouse_event(MOUSEEVENTF_LEFTUP, endX, endY, 0, 0);
        }


        internal static void DeskTopMouseClick(SeleniumWebControls control)
        {

            //Rectangle rect = control.BoundingRectangle;
            //double x = rect.X + rect.Width / 2;
            //double y = rect.Y + rect.Height / 2;

            //control.OwnerBrowser.Manager.Desktop.Mouse.HoverOver(new Point(x, y));
            //control.OwnerBrowser.Manager.Desktop.Mouse.Click(MouseClickType.LeftClick, new Point(x, y));

            MouseClick(control.ClickablePoint.X, control.ClickablePoint.Y);

            //MouseClick((int)x, (int)y);
        }

        internal static void DeskTopMouseClick(SeleniumWebControls control, int offsetX, int offsetY)
        {
            MouseClick(control.ClickablePoint.X + offsetX, control.ClickablePoint.Y + offsetY);
        }

        internal static void DeskTopMouseDrag(SeleniumWebControls control, int offsetX, int offsetY)
        {
            MouseDrag(control.ClickablePoint.X, control.ClickablePoint.Y, control.ClickablePoint.X + offsetX, control.ClickablePoint.Y + offsetY);
        }
    }
}

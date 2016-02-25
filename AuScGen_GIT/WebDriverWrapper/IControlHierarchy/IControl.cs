using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WebDriverWrapper
{
    public interface IControl
    {
        bool Enabled { get; }

        Point ClickablePoint { get; }

        Rectangle BoundingRectangle { get; }

        Image GetControlImage { get; }

        bool Visible { get; }

        string Text { get; }

        bool IsChecked { get; }

        string TagName { get; }

        IControl Parent { get; }

        Point ScrollToElement();

        List<IControl> GetChildren(string Locator, LocatorType aLocatorType, ControlType aControlType, ControlAccess access);

        void Highlight(Browser aBrowser);

        void Click();

        void Submit();

        void SendKeys(string text);

        void DesktopMouseClick();

        void DesktopMouseClick(int offsetX, int offsetY);

        void DesktopMouseDrag(int offsetX, int offsetY);

        string GetAttributeFromNode(string Attribute);

        object ExecuteJavaScript(Browser aBrowser, string JavaScript);

        object InjectJSInBrowser(Browser aBrowser, string JavaScript);

        bool HasChildren();

        bool HasChildrenWithXpath(string xpath);

        List<IControl> WaitForChildren(int maxTimeout);

        List<IControl> WaitForChildren(string xpath, int maxTimeout);

        string InnerHtml(Browser aBrowser);

        string OuterHtml(Browser aBrowser);
    }
}

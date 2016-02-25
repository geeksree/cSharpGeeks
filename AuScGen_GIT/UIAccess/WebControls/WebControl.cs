using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverWrapper;

namespace UIAccess.WebControls
{
    public class WebControl
    {
        private ControlAccess myControlAccess;

        internal IControl Control;

        //private Browser myBrowser;

        //private LocatorType myLocatorType;

        //private string myLocator;

        internal ControlType myControlType;

        #region ctor

        public WebControl(Browser aBrowser, LocatorType aLocatorType, string aLocator, ControlType aControlType)
        {
            myControlAccess = new ControlAccess();
            myControlAccess.Browser = aBrowser;
            myControlAccess.LocatorType = aLocatorType;
            myControlAccess.Locator = aLocator;
            myControlAccess.ControlType = aControlType;
            myControlAccess.IntializeControlAccess();
            //Control = myControlAccess.GetControl();
        }

        public WebControl(Browser aBrowser, Locator aLocator)
        {
            myControlAccess = new ControlAccess();
            myControlAccess.Browser = aBrowser;
            myControlAccess.LocatorType = aLocator.LocatorType;
            myControlAccess.Locator = aLocator.ControlLocator;
            myControlAccess.ControlType = ControlType.Custom;
            myControlAccess.IntializeControlAccess();
            //Control = myControlAccess.GetControl();
        }

        #endregion ctor

        #region Public Properties

        public bool Enabled
        {
            get
            {
                return Control.Enabled;
            }

        }

        public Rectangle BoundingRectangle
        {
            get { return Control.BoundingRectangle; }
        }

        public Image GetScreenImage
        {
            get
            {
                return Control.GetControlImage;
            }
        }

        public Point ClickablePoint
        {
            get { return Control.ClickablePoint; }
        }

        public bool Visible
        {
            get { return Control.Visible; }

        }

        public string Text
        {
            get { return Control.Text; }
        }

        public string InnerHtml
        {
            get
            {
                return Control.InnerHtml(myControlAccess.Browser);
            }
        }

        public string OuterHtml
        {
            get
            {
                return Control.OuterHtml(myControlAccess.Browser);
            }
        }

        public bool IsChecked
        {
            get { return Control.IsChecked; }
        }

        public string TagName
        {
            get { return Control.TagName; }
        }

        public Actions Action
        {
            get
            {
                return new Actions(myControlAccess);
            }

        }

        public IControl SeleniumControl
        {
            get
            {

                return Control;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public Point ScrollToElement()
        {
            return Control.ScrollToElement();
        }

        public bool IsControlPresent()
        {
            return myControlAccess.IsElementPresent();
        }

        public void GetControl()
        {
            Control = myControlAccess.GetControl();
        }

        public ReadOnlyCollection<IControl> GetControls()
        {
            return myControlAccess.GetControls();
        }

        public List<WebControl> GetChildren(Locator aLocator, ControlType aControlType)
        {
            List<IControl> aIControlList = new List<IControl>();
            aIControlList = myControlAccess.GetChildren(aLocator.ControlLocator, aLocator.LocatorType, aControlType);

            return Utility.GetWebControlsFromIControlList(aIControlList, myControlAccess.Browser, aLocator, aControlType);
        }

        public void Highlight()
        {
            Control.Highlight(myControlAccess.Browser);
        }

        public void ClickAt()
        {
            myControlAccess.ClickAt();
        }

        public void Click()
        {
            Control.ExecuteJavaScript(myControlAccess.Browser, "arguments[0].hidden = false");
            Control.Click();
        }

        public void Submit()
        {
            Control.Submit();
        }

        public void SendKeys(string keys)
        {
            Control.SendKeys(keys);
        }


        public void DesktopMouseClick()
        {
            Control.DesktopMouseClick();
        }

        public void DesktopMouseClick(int offsetX, int offsetY)
        {
            Control.DesktopMouseClick(offsetX, offsetY);
        }

        public void DesktopMouseDrag(int offsetX, int offsetY)
        {
            Control.DesktopMouseDrag(offsetX, offsetY);
        }

        public string GetAttribute(string AttributeName)
        {
            return Control.GetAttributeFromNode(AttributeName);
        }

        public Dictionary<string, object> GetAttributes()
        {
            return (Dictionary<string, object>)Executejavascript(@"var items = {}; for (index = 0; index < arguments[0].attributes.length; ++index) { items[arguments[0].attributes[index].name] = arguments[0].attributes[index].value }; return items;");
        }

        public object Executejavascript(string JavaScript)
        {
            return Control.ExecuteJavaScript(myControlAccess.Browser, JavaScript);
        }

        public object InjectJSInBrowser(string JavaScript)
        {
            return Control.InjectJSInBrowser(myControlAccess.Browser, JavaScript);
        }

        public bool HasChildren()
        {
            return Control.HasChildren();
        }

        public bool HasChildrenWithXpath(string xpath)
        {
            return Control.HasChildrenWithXpath(xpath);
        }

        public List<WebControl> WaitForChildren(int maxTimeout)
        {
            List<IControl> aIControlList = new List<IControl>();
            aIControlList = Control.WaitForChildren(maxTimeout);
            return Utility.GetWebControlsFromIControlList(aIControlList, myControlAccess.Browser, new Locator(".//*", LocatorType.Xpath), ControlType.Custom);
        }

        public List<WebControl> WaitForChildren(string xpath, int maxTimeout)
        {
            List<IControl> aIControlList = new List<IControl>();
            aIControlList = Control.WaitForChildren(xpath, maxTimeout);
            return Utility.GetWebControlsFromIControlList(aIControlList, myControlAccess.Browser, new Locator(xpath, LocatorType.Xpath), ControlType.Custom);
        }


        //public WebControl Parent 
        //{ 
        //    get
        //    {
        //        Utility.GetWebControlFromIContol(Parent,myControlAccess.Browser,)
        //        return Parent;
        //    }
        //}
        #endregion Public Methods

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
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
            Control.Click();
        }

        public void DesktopMouseClick()
        {
            Control.DesktopMouseClick();
        }

        public void DesktopMouseClick(int offsetX, int offsetY)
        {
            Control.DesktopMouseClick(offsetX, offsetY);
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

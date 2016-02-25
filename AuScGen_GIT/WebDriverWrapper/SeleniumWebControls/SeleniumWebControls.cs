using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System.Threading;
using Selenium;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using System.IO;

namespace WebDriverWrapper
{
    public class SeleniumWebControls : IControl
    {
        #region Private Members

        protected internal ControlType aControlType;

        #endregion Private Members

        #region Internal Members

        internal IWebElement aWebElement;
        internal ControlAccess aControlAccess;

        #endregion Internal Members

        #region ctor

        internal SeleniumWebControls(IWebElement aWebElement, ControlType aControlType)
        {
            this.aWebElement = aWebElement;
            this.aControlType = aControlType;
        }

        internal SeleniumWebControls(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : this(aWebElement, aControlType)
        {
            this.aControlAccess = access;
        }

        #endregion

        #region Public Properties

        public bool Enabled
        {
            get
            {
                return aWebElement.Enabled;

            }
        }

        public Point ClickablePoint
        {
            get
            {
                int X = BoundingRectangle.X + BoundingRectangle.Width / 2;
                int Y = BoundingRectangle.Y + 60 + BoundingRectangle.Height / 2;

                //System.Windows.Point
                return new Point(X, Y);
            }
        }

        public Rectangle BoundingRectangle
        {
            get
            {
                return new Rectangle(ScrollToElement(), aWebElement.Size);
            }
        }

        public Image GetControlImage
        {
            get
            {

                byte[] imageArray = ((ITakesScreenshot)aControlAccess.Browser.BrowserHandle).GetScreenshot().AsByteArray;
                var ms = new MemoryStream(imageArray);
                return Image.FromStream(ms);
                //Rectangle controlBox = BoundingRectangle;
                //Bitmap bmpScreenCapture = new Bitmap(controlBox.Width, controlBox.Height);
                //using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                //{
                //    g.CopyFromScreen(controlBox.X + controlBox.Width,
                //                     controlBox.Y + controlBox.Height,
                //                     controlBox.X,
                //                     controlBox.Y,
                //                     controlBox.Size
                //                     );
                //}

                // Bitmap bmpScreenCapture = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                //                             Screen.PrimaryScreen.Bounds.Height);

                // using (Graphics g = Graphics.FromImage(bmpScreenCapture))
                // {
                //     g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                //                         Screen.PrimaryScreen.Bounds.Y,
                //                         0, 0,
                //                         bmpScreenCapture.Size,
                //                         CopyPixelOperation.SourceCopy);
                // }

                //return bmpScreenCapture;
            }
        }

        public bool Visible
        {
            get
            {
                return aWebElement.Displayed;
            }
        }

        public string TagName
        {
            get
            {
                return aWebElement.TagName;
            }
        }

        public IControl Parent
        {
            get
            {
                return Utility.GetControlFromWebElement(aWebElement.FindElement(By.XPath("./..")), ControlType.Custom, this.aControlAccess);
            }
        }

        public string Text
        {
            get
            {
                return aWebElement.Text;
            }
        }

        public string OuterHtml(Browser aBrowser)
        {
            return (string)ExecuteJavaScript(aBrowser, @"return arguments[0].outerHTML;");
        }

        public string InnerHtml(Browser aBrowser)
        {
            return (string)ExecuteJavaScript(aBrowser, @"return arguments[0].innerHTML;");
        }

        public bool IsChecked
        {
            get
            {
                return aWebElement.Selected;
            }
        }

        public Point ScrollToElement()
        {
            //return ((ILocatable)aWebElement).Coordinates.LocationOnScreen;
            //ExecuteJavaScript(aControlAccess.Browser, "arguments[0].scrollIntoView(true);");
            return ((RemoteWebElement)aWebElement).LocationOnScreenOnceScrolledIntoView;
        }

        #endregion Public Properties

        #region Public Methods

        public List<IControl> GetChildren(string Locator, LocatorType aLocatorType, ControlType aControlType, ControlAccess access)
        {
            return Utility.GetChildren(Locator, aLocatorType, aControlType, aWebElement, access);
        }

        private void WaitForVisible()
        {
            WebDriverWait wait = new WebDriverWait(aControlAccess.Browser.BrowserHandle, TimeSpan.FromMinutes(2));
            wait.Until(ExpectedConditions.ElementIsVisible(Utility.GetByFromLocator(aControlAccess.LocatorType, aControlAccess.Locator)));
        }

        public void Click()
        {
            WaitForVisible();
            aWebElement.Click();
        }

        public void Submit()
        {
            WaitForVisible();
            aWebElement.Submit();
        }

        public void DesktopMouseClick()
        {
            ScrollToElement();
            Win32.DeskTopMouseClick(this);
        }

        public void DesktopMouseClick(int offsetX, int offsetY)
        {
            ScrollToElement();
            Win32.DeskTopMouseClick(this, offsetX, offsetY);
        }

        public void DesktopMouseDrag(int offsetX, int offsetY)
        {
            //ScrollToElement();
            Win32.DeskTopMouseDrag(this, offsetX, offsetY);
        }

        public void SendKeys(string text)
        {
            WaitForVisible();
            aWebElement.SendKeys(text);
        }

        #endregion Public Methods

        public void Highlight(Browser aBrowser)
        {
            IJavaScriptExecutor aScriptExecutor = (IJavaScriptExecutor)aBrowser.BrowserHandle;

            object aStyle = aScriptExecutor.ExecuteScript("arguments[0].getAttribute('style');", aWebElement);
            aScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", aWebElement,
                                          "border: 4px solid red;");

            //for (int i = 0; i < 5; i++)
            //{
            //    //aScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", aWebElement,"color: red; border: 4px solid red;");

            //    object aStyle = aScriptExecutor.ExecuteScript("arguments[0].getAttribute('style');", aWebElement);
            //    aScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", aWebElement,
            //                                  "border: 4px solid red;");
            //    //Thread.Sleep(50);

            //    //aScriptExecutor.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);",
            //    //    aWebElement, aStyle);
            //}
        }

        public object ExecuteJavaScript(Browser aBrowser, string JavaScript)
        {
            IJavaScriptExecutor aScriptExecutor = (IJavaScriptExecutor)aBrowser.BrowserHandle;

            return aScriptExecutor.ExecuteScript(JavaScript, aWebElement);

        }

        public object InjectJSInBrowser(Browser aBrowser, string JavaScript)
        {
            IJavaScriptExecutor aScriptExecutor = (IJavaScriptExecutor)aBrowser.BrowserHandle;

            return aScriptExecutor.ExecuteScript(JavaScript);
        }

        public string GetAttributeFromNode(string Attribute)
        {
            return aWebElement.GetAttribute(Attribute);
        }


        public bool HasChildren()
        {
            return GetChildren("//*", LocatorType.Xpath, ControlType.Custom, aControlAccess).Count() > 0;
        }

        public bool HasChildrenWithXpath(string xpath)
        {
            return GetChildren(xpath, LocatorType.Xpath, ControlType.Custom, aControlAccess).Count() > 0;
        }

        public List<IControl> WaitForChildren(int maxTimeout)
        {
            DateTime start;
            double timeElapsed = 0;
            SelectElement element = new SelectElement(aWebElement);


            start = DateTime.Now;

            while (!HasChildren() && timeElapsed < maxTimeout)
            {
                timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
            }

            return GetChildren(".//*", LocatorType.Xpath, ControlType.Custom, aControlAccess);
        }

        public List<IControl> WaitForChildren(string xpath, int maxTimeout)
        {
            DateTime start;
            double timeElapsed = 0;
            SelectElement element = new SelectElement(aWebElement);


            start = DateTime.Now;

            while (!HasChildren() && timeElapsed < maxTimeout)
            {
                timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
            }

            return GetChildren(xpath, LocatorType.Xpath, ControlType.Custom, aControlAccess);
        }

    }

}

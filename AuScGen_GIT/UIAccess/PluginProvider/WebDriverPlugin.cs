using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WebDriverWrapper;
using UIAccess;
using UIAccess.WebControls;

namespace UIAccess
{
    /// <summary>
    /// Plugin to add WebDriver to Framework
    /// </summary>
    [Export(typeof(IContainerPlugin))]
    public class WebDriverPlugin : IContainerPlugin
    {
        private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string identifier;

        public WebDriverPlugin()
        {
            log4net.ThreadContext.Properties["myContext"] = "Logging from WebDriverPlugin Class";
            Logger.Debug("Inside WebDriverPlugin Constructor!");            
        }

        private Browser myBrowser;
        public Browser Browser
        {
            get
            {
                return myBrowser;
            }
            set
            {
                myBrowser = value;
            }
        }

        public void SetBrowser(BrowserType aBrowserType)
        {
            myBrowser = new Browser(aBrowserType);
        }

        public WebControl GetControl(Locator aLocator)
        {

            WebControl aWebCustomControl = new WebControl(myBrowser, aLocator);

            if (aWebCustomControl.IsControlPresent())
            {
                aWebCustomControl.GetControl();
            }

            return aWebCustomControl;
        }       

        public WebControl GetControl(Locator aLocator, ControlType aControlType)
        {
            WebControl aWebCustomControl;

            switch (aControlType)
            {
                case ControlType.Button:
                    aWebCustomControl = new WebButton(myBrowser, aLocator);
                    break;
                case ControlType.EditBox:
                    aWebCustomControl = new WebEditBox(myBrowser, aLocator);
                    break;
                default:
                    aWebCustomControl = new WebControl(myBrowser, aLocator);
                    break;
            }

            if (aWebCustomControl.IsControlPresent())
            {
                aWebCustomControl.GetControl();
            }

            return aWebCustomControl;
        }
        
        public T GetControl<T>(string guiMapPath, string logicalName) where T : WebControl
        {
            Logger.Debug(string.Format("Inside GetControl<T> Method", typeof(T).ToString()));
            Dictionary<string, Guimap> guiCollection = guiCollection = GetObjectCollection(guiMapPath);
            return GetElementFromObjectLocator<T>(GuiMapParser.GetInstance().GetElementValue(guiCollection, logicalName));
        }

        public T WaitForControl<T>(string guiMapPath, string logicalName, int maxWaitTime) where T : WebControl
        {
            T control;
            DateTime start; DateTime end;
            double timeElapsed = 0;
            
            control = GetControl<T>(guiMapPath, logicalName);
            start = DateTime.Now;

            if (null == control.SeleniumControl)
            {
                while (null == control.SeleniumControl && timeElapsed < maxWaitTime)
                {
                    end = DateTime.Now;                        
                    control = GetControl<T>(guiMapPath, logicalName);
                    timeElapsed = ((TimeSpan)(end - start)).TotalMilliseconds;
                }
            }
            Logger.Debug(string.Format("Inside WaitForControl , returned control in {0}ms", timeElapsed));
            //control.Highlight();

            return control;
        }

        private Locator GetLocator(XmlNode Node)
        {
            string Locator = ((XmlElement)Node).GetAttribute("Locator");

            return new Locator(Locator, GetLocatorType(Node));

        }

        private LocatorType GetLocatorType(XmlNode Node)
        {
            string aLocatorType = ((XmlElement)Node).GetAttribute("LocatorType");

            switch (aLocatorType)
            {
                case "ClassName":
                    return LocatorType.ClassName;

                case "Css":
                    return LocatorType.Css;

                case "PartialLinkText":
                    return LocatorType.PartialLinkText;

                case "Id":
                    return LocatorType.Id;

                case "LinkText":
                    return LocatorType.LinkText;

                case "Name":
                    return LocatorType.Name;

                case "TagName":
                    return LocatorType.TagName;

                case "Xpath":
                    return LocatorType.Xpath;

                default:
                    return LocatorType.Id;
            }
        }
        
        private static Dictionary<string, Guimap> GetObjectCollection(string filePath)
        {
            return GlobalGuiCollection.GetGuimap(filePath);
        }

        private T GetElementFromObjectLocator<T>(string objectLocator) where T : WebControl
        {
            T SearchControl;
            objectLocator = ExtractObjectLocator(objectLocator);
            switch (identifier)
            {
                case "id":
                    SearchControl = GetControlFromLocator<T>(new Locator(objectLocator, LocatorType.Id));
                    break;
                case "name":
                    SearchControl = GetControlFromLocator<T>(new Locator(objectLocator, LocatorType.Name));
                    break;
                case "tagname":
                    SearchControl = GetControlFromLocator<T>(new Locator(objectLocator, LocatorType.TagName));
                    break;
                case "xpath":
                    SearchControl = GetControlFromLocator<T>(new Locator(objectLocator, LocatorType.Xpath));
                    break;
                case "linktext":
                    SearchControl = GetControlFromLocator<T>(new Locator(objectLocator, LocatorType.LinkText));
                    break;
                case "class":
                    SearchControl = GetControlFromLocator<T>(new Locator(objectLocator, LocatorType.ClassName));
                    break;
                case "partiallinktext":
                    SearchControl = GetControlFromLocator<T>(new Locator(objectLocator, LocatorType.PartialLinkText));
                    break;
                //case "atribute":
                //    SearchControl = Find.ByAttributes(objectLocator.Split(new char[] { ';' }));
                //    break;
                default:
                    SearchControl = GetControlFromLocator<T>(new Locator(objectLocator, LocatorType.Id));
                    break;
            }

            return SearchControl;
        }

        private string ExtractObjectLocator(string objectLocator)
        {
            Logger.Debug("Inside ExtractObjectLocator");

            if (objectLocator.StartsWith("id"))
            {
                identifier = objectLocator.Substring(0, 2);
                objectLocator = objectLocator.Substring(2, objectLocator.Length - 2);
            }
            else if (objectLocator.StartsWith("name"))
            {
                identifier = objectLocator.Substring(0, 4);
                objectLocator = objectLocator.Substring(4, objectLocator.Length - 4);
            }
            else if (objectLocator.StartsWith("xpath"))
            {
                identifier = objectLocator.Substring(0, 5);
                objectLocator = objectLocator.Substring(5, objectLocator.Length - 5);
            }
            else if (objectLocator.StartsWith("tagname"))
            {
                identifier = objectLocator.Substring(0, 7);
                objectLocator = objectLocator.Substring(7, objectLocator.Length - 7);

            }
            else if (objectLocator.StartsWith("linktext"))
            {
                identifier = objectLocator.Substring(0, 8);
                objectLocator = objectLocator.Substring(8, objectLocator.Length - 8);
            }

            else if (objectLocator.StartsWith("partiallinktext"))
            {
                identifier = objectLocator.Substring(0, 15);
                objectLocator = objectLocator.Substring(15, objectLocator.Length - 15);
            }

            else if (objectLocator.StartsWith("class"))
            {
                identifier = objectLocator.Substring(0, 5);
                objectLocator = objectLocator.Substring(5, objectLocator.Length - 5);
            }
            //else if (objectLocator.StartsWith("atribute"))
            //{
            //    identifier = objectLocator.Substring(0, 8);
            //    objectLocator = objectLocator.Substring(8, objectLocator.Length - 8);
            //}

            Logger.Debug(string.Format("ExtractObjectLocator, {0}={1}", identifier, objectLocator));
            return objectLocator;
        }

        private T GetControlFromLocator<T>(Locator aLocator) where T : WebControl
        {
            WebControl aWebCustomControl = null;

            if (typeof(T) == typeof(WebButton))
            {
                aWebCustomControl = new WebButton(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebEditBox))
            {
                aWebCustomControl = new WebEditBox(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebCalender))
            {
                aWebCustomControl = new WebCalender(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebCheckBox))
            {
                aWebCustomControl = new WebCheckBox(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebComboBox))
            {
                aWebCustomControl = new WebComboBox(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebDialog))
            {
                aWebCustomControl = new WebDialog(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebFrame))
            {
                aWebCustomControl = new WebFrame(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebImage))
            {
                aWebCustomControl = new WebImage(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebLabel))
            {
                aWebCustomControl = new WebLabel(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebLink))
            {
                aWebCustomControl = new WebLink(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebListBox))
            {
                aWebCustomControl = new WebListBox(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebPage))
            {
                aWebCustomControl = new WebPage(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebRadioButton))
            {
                aWebCustomControl = new WebRadioButton(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebSpanArea))
            {
                aWebCustomControl = new WebSpanArea(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebTable))
            {
                aWebCustomControl = new WebTable(myBrowser, aLocator);
            }

            if (typeof(T) == typeof(WebControl))
            {
                aWebCustomControl = new WebControl(myBrowser, aLocator);
            }

            if (null == aWebCustomControl)
            {
                aWebCustomControl = new WebControl(myBrowser, aLocator);
            }

            if (aWebCustomControl.IsControlPresent())
            {
                aWebCustomControl.GetControl();
            }

            return (T)aWebCustomControl;
        }

        public string Description
        {
            get
            {
                return "WebDriver Plugin";
            }
            set
            {
                Description = value;
            }
        }
        
    }
}

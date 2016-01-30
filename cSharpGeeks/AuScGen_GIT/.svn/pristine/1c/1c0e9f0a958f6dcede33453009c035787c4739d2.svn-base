using ArtOfTest.WebAii.Controls;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.TestTemplates;
using Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.TestingFramework.Controls.KendoUI;


namespace AuScGen.TelerikPlugin
{
    /// <summary>
    /// Teleframework class
    /// </summary>
    public class TelerikFramework : BaseTest
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private string identifier;

        /// <summary>
        /// The logger
        /// </summary>
        private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Initializes a new instance of the <see cref="TelerikFramework" /> class.
        /// </summary>
        public TelerikFramework()
        {
            log4net.ThreadContext.Properties["myContext"] = "Logging from TelerikFramework Class";
            Logger.Debug("Inside TelerikFramework Constructor!");
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public Element GetControl(string id)
        {
            Logger.Debug("Inside GetControl Method..");
            return Find.ById(id);
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id">The identifier.</param>
        /// <returns></returns>
        public T GetControl<T>(string id) where T : Control, new()
        {
            Logger.Debug(string.Format("Inside GetControl<T> Method", typeof(T).ToString()));
            return Find.ById<T>(id);
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="GuiMapPath">The GUI map path.</param>
        /// <param name="LogicalName">Name of the logical.</param>
        /// <returns></returns>
        public T GetControl<T>(string guiMapPath, string logicalName) where T : Control, new()
        {
            Logger.Debug(string.Format("Inside GetControl<T> Method", typeof(T).ToString()));
            Dictionary<string, Guimap> guiCollection = guiCollection = GetObjectCollection(guiMapPath);
            return GetControlFromObjectLocator<T>(GuiMapParser.GetInstance().GetElementValue(guiCollection, logicalName));
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <param name="GuiMapPath">The GUI map path.</param>
        /// <param name="LogicalName">Name of the logical.</param>
        /// <returns></returns>
        public Element GetControl(string guiMapPath, string logicalName)
        {
            Logger.Debug("Inside GetControl Method..");
            Dictionary<string, Guimap> guiCollection = GetObjectCollection(guiMapPath);
            return GetElementFromObjectLocator(GuiMapParser.GetInstance().GetElementValue(guiCollection, logicalName));
        }

        /// <summary>
        /// Shuts down.
        /// </summary>
        public void Shutdown()
        {
            BaseTest.ShutDown();
        }

        /// <summary>
        /// Extracts the object locator.
        /// </summary>
        /// <param name="objectLocator">The object locator.</param>
        /// <returns></returns>
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
            else if (objectLocator.StartsWith("content"))
            {
                identifier = objectLocator.Substring(0, 7);
                objectLocator = objectLocator.Substring(7, objectLocator.Length - 7);
            }
            else if (objectLocator.StartsWith("class"))
            {
                identifier = objectLocator.Substring(0, 5);
                objectLocator = objectLocator.Substring(5, objectLocator.Length - 5);
            }
            else if (objectLocator.StartsWith("atribute"))
            {
                identifier = objectLocator.Substring(0, 8);
                objectLocator = objectLocator.Substring(8, objectLocator.Length - 8);
            }

            Logger.Debug(string.Format("ExtractObjectLocator, {0}={1}", identifier, objectLocator));
            return objectLocator;
        }

        /// <summary>
        /// Gets the control from object locator.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectLocator">The object locator.</param>
        /// <returns></returns>
        private T GetControlFromObjectLocator<T>(string objectLocator) where T : Control, new()
        {
            T SearchControl;
            objectLocator = ExtractObjectLocator(objectLocator);
            switch (identifier)
            {
                case "id":
                    SearchControl = Find.ById<T>(objectLocator);
                    break;
                case "name":
                    SearchControl = Find.ByName<T>(objectLocator);
                    break;
                case "tagindex":
                    SearchControl = Find.ByTagIndex<T>(objectLocator, 1);
                    break;
                case "xpath":
                    SearchControl = Find.ByXPath<T>(objectLocator);
                    break;
                case "content":
                    SearchControl = Find.ByContent<T>(objectLocator);
                    break;
                case "class":
                    SearchControl = Find.ByAttributes<T>(new string[] { string.Format("class={0}", objectLocator) });
                    break;
                case "atribute":
                    SearchControl = Find.ByAttributes<T>(objectLocator.Split(new char[] { ';' }));
                    break;
                default:
                    SearchControl = Find.ById<T>(objectLocator);
                    break;
            }

            if (null != SearchControl)
            {
                Logger.Debug(string.Format("Inside GetControlFromObjectLocator , return type {0}", SearchControl.GetType().ToString()));
            }

            return SearchControl;
        }

        /// <summary>
        /// Gets the element from object locator.
        /// </summary>
        /// <param name="objectLocator">The object locator.</param>
        /// <returns></returns>
        private Element GetElementFromObjectLocator(string objectLocator)
        {
            Element SearchControl;
            objectLocator = ExtractObjectLocator(objectLocator);
            switch (identifier)
            {
                case "id":
                    SearchControl = Find.ById(objectLocator);
                    break;
                case "name":
                    SearchControl = Find.ByName(objectLocator);
                    break;
                case "tagindex":
                    SearchControl = Find.ByTagIndex(objectLocator, 1);
                    break;
                case "xpath":
                    SearchControl = Find.ByXPath(objectLocator);
                    break;
                case "content":
                    SearchControl = Find.ByXPath(objectLocator);
                    break;
                case "class":
                    SearchControl = Find.ByAttributes(new string[] { string.Format("class={0}", objectLocator) });
                    break;
                case "atribute":
                    SearchControl = Find.ByAttributes(objectLocator.Split(new char[] { ';' }));
                    break;
                default:
                    SearchControl = Find.ByContent(objectLocator);
                    break;
            }

            if (null != SearchControl)
            {
                Logger.Debug(string.Format("Inside GetControlFromObjectLocator , return type {0}", SearchControl.GetType().ToString()));
            }

            return SearchControl;
        }

        /// <summary>
        /// Waits for control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="GuiMapPath">The GUI map path.</param>
        /// <param name="LogicalName">Name of the logical.</param>
        /// <param name="MaxWaitTime">The maximum wait time.</param>
        /// <returns></returns>
        /// <exception cref="Ecolab.TelerikPlugin.GUIException"></exception>
        /// <exception cref="Ecolab.CommonUtilityPlugin.TCDFrameworkException"></exception>
        /// <exception cref="TCDFrameworkException"></exception>
        public T WaitForControl<T>(string guiMapPath, string logicalName, int maxWaitTime) where T : Control, new()
        {
            T control;
            DateTime start; DateTime end;
            double timeElapsed = 0;
            try
            {
                ActiveBrowser.RefreshDomTree();
                control = GetControl<T>(guiMapPath, logicalName);
                start = DateTime.Now;

                if (null == control)
                {
                    while (null == control && timeElapsed < maxWaitTime)
                    {
                        end = DateTime.Now;
                        ActiveBrowser.RefreshDomTree();
                        control = GetControl<T>(guiMapPath, logicalName);
                        timeElapsed = ((TimeSpan)(end - start)).TotalMilliseconds;
                    }
                }
                Logger.Debug(string.Format("Inside WaitForControl , returned control in {0}ms", timeElapsed));

                return control;
            }
            catch (NullReferenceException e)
            {
                throw new GUIException(logicalName, e);
            }
        }

        /// <summary>
        /// Waits for element.
        /// </summary>
        /// <param name="GuiMapPath">The GUI map path.</param>
        /// <param name="LogicalName">Name of the logical.</param>
        /// <param name="MaxWaitTime">The maximum wait time.</param>
        /// <returns></returns>
        public Element WaitForElement(string guiMapPath, string logicalName, int maxWaitTime)
        {
            Element element;
            DateTime start; DateTime end;
            double timeElapsed = 0;
            ActiveBrowser.RefreshDomTree();
            element = GetControl(guiMapPath, logicalName);
            start = DateTime.Now;
            if (null == element)
            {
                while (null == element && timeElapsed < maxWaitTime)
                {
                    end = DateTime.Now;
                    ActiveBrowser.RefreshDomTree();
                    element = GetControl(guiMapPath, logicalName);
                    timeElapsed = ((TimeSpan)(end - start)).TotalMilliseconds;
                }
            }
            Logger.Debug(string.Format("Inside WaitForControl , returned control in {0}ms", timeElapsed));
            return element;
        }

        /// <summary>
        /// Gets the object collection.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private static Dictionary<string, Guimap> GetObjectCollection(string filePath)
        {
            return GlobalGuiCollection.GetGuimap(filePath);
        }

        /// <summary>
        /// Logs the check for collection.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        private static void LogCheckForCollection(string fileName)
        {
            Logger.Debug(string.Concat("There is no existing ", fileName, " Object Collection"));
            Logger.Debug(string.Concat("Creating a new instance for ", fileName, " Object Collection"));
        }

    }
}

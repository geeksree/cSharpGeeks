using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using AuScGen.WhiteFramework.GUIMapParser;

namespace AuScGen.WhiteFramework
{
    public class  WhiteFramework
    {
        private string identifier;

        public string GuiMapPath { get; set; }
        
        public Window AppWindow { get; set; }
        
        public SearchCriteria Search { get; set; }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetControl<T>() where T : IUIItem
        {
            AppWindow.Focus();
            return AppWindow.Get<T>(Search);
        }

        /// <summary>
        /// Gets the control.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="GuiMapPath">The GUI map path.</param>
        /// <param name="LogicalName">Name of the logical.</param>
        /// <returns></returns>
        public T GetControl<T>(string GuiMapPath, string LogicalName) where T : IUIItem
        {
            AppWindow.Focus();
            Dictionary<string, GuiMap> guiCollection = guiCollection = getObjectCollection(GuiMapPath);
            GetIdentificationValues(guiCollection, LogicalName);            
            return AppWindow.Get<T>(Search);
        }

        /// <summary>
        /// Extracts the object locator.
        /// </summary>
        /// <param name="objectLocator">The object locator.</param>
        /// <returns></returns>
        private string ExtractObjectLocator(string objectLocator)
        {
            //string[] ArrLocator = null;
            //string[] temp = null;
            //List<string> ArrObjectLocator = null;

            //if(objectLocator.Contains(":"))
            //{
            //    temp = Regex.Split(objectLocator, ";");
            //    for (int i = 0; i < ArrLocator.Length - 1; i++)
            //    {
            //        ArrLocator = Regex.Split(temp[i], ":");
            //    }                 
            //}
            //if (objectLocator.Contains(";"))
            //{
            //    ArrLocator = Regex.Split(objectLocator, ";");
            //}

            //for (int j = 0; j <ArrLocator.Length-1 ; j++)
            //{
            //    identifier.Add(ArrLocator[j]);
            //    ArrObjectLocator.Add(ArrLocator[j+1]);
            //}
            if (objectLocator.StartsWith("id"))
            {
                identifier = objectLocator.Substring(0, 2);
                objectLocator = objectLocator.Substring(2, objectLocator.Length - 2);
            }
            else if (objectLocator.StartsWith("text"))
            {
                identifier = objectLocator.Substring(0, 4);
                objectLocator = objectLocator.Substring(4, objectLocator.Length - 4);
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
            return objectLocator;
        }

        /// <summary>
        /// Gets the search.
        /// </summary>
        /// <param name="strObjectLocator">The string object locator.</param>
        private void GetSearch(string strObjectLocator) 
        {
            strObjectLocator = ExtractObjectLocator(strObjectLocator);
            switch (FindType(identifier))
            {
                case FindBy.Text:
                    Search = SearchCriteria.ByText(strObjectLocator);
                    break;

                case FindBy.AutomationId:
                    Search = SearchCriteria.ByAutomationId(strObjectLocator);
                    break;

                case FindBy.ClassName:
                    Search = SearchCriteria.ByClassName(strObjectLocator);
                    break;

                case FindBy.ControlType:
                    Search = SearchCriteria.ByControlType(GetControlType(strObjectLocator));
                    break;

                case FindBy.FrameworkId:
                    Search = SearchCriteria.ByFramework(strObjectLocator);
                    break;

                case FindBy.NativeProperty:
                    //Search = SearchCriteria.ByNativeProperty()
                    break;

                default:
                    Search = SearchCriteria.ByText(strObjectLocator);
                    break;
            }
        }

        /// <summary>
        /// Finds the type.
        /// </summary>
        /// <param name="strLocator">The string locator.</param>
        /// <returns></returns>
        private FindBy FindType(string strLocator)
        {
            switch (strLocator)
            {
                case "text":
                    return FindBy.Text;

                case "id":
                    return FindBy.AutomationId;

                default:
                    return FindBy.AutomationId;

            }
        }

        /// <summary>
        /// Gets the type of the control.
        /// </summary>
        /// <param name="Type">The type.</param>
        /// <returns></returns>
        private System.Windows.Automation.ControlType GetControlType(string Type)
        {
            switch(Type.ToLower())
            {
                case "button":
                    return System.Windows.Automation.ControlType.Button;
                case "editbox":
                    return System.Windows.Automation.ControlType.Edit;
                case "custom":
                    return System.Windows.Automation.ControlType.Custom;
            }
            return null;
        }

        /// <summary>
        /// Gets the object collection.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        private Dictionary<string, GuiMap> getObjectCollection(string filePath)
        {
            string originalFilePath = filePath;
            Dictionary<string, Dictionary<string, GuiMap>> collection = new Dictionary<string, Dictionary<string, GuiMap>>();
            String fileName = Path.GetFileName(filePath);
            fileName = fileName.Substring(0, fileName.Length - 4);
            switch (fileName)
            {
                case "GuiMap":
                    collection = GlobalGuiCollection.getInstance().GlobalGuimapCollection;
                    if (collection != null && collection.ContainsKey(fileName))
                    {
                        collection = GlobalGuiCollection.getInstance().GlobalGuimapCollection;
                    }
                    else
                    {
                        GlobalGuiCollection.getInstance().GlobalGuimapCollection
                            .Add(fileName, GuiMapParser.GetInstance().LoadGuiMap(originalFilePath));
                        collection = GlobalGuiCollection.getInstance().GlobalGuimapCollection;
                    }
                    break;
            }
            return collection[fileName];
        }

        /// <summary>
        /// Extracts the locator.
        /// </summary>
        /// <param name="objectLocator">The object locator.</param>
        /// <returns></returns>
        private string ExtractLocator(Dictionary<string,string> objectLocator)
        {
            string LocatorValue = string.Empty;
            if (objectLocator.Keys.Contains("Id"))
            {
                identifier = "Id";
                LocatorValue = objectLocator["Id"];
            }
            if (objectLocator.Keys.Contains("Text"))
            {
                identifier = "Text";
                LocatorValue = objectLocator["Text"];
            }
            if (objectLocator.Keys.Contains("ClassName"))
            {
                identifier = "ClassName";
                LocatorValue = objectLocator["ClassName"];
            }
            if (objectLocator.Keys.Contains("Framework"))
            {
                identifier = "Framework";
                LocatorValue = objectLocator["Framework"];
            }
            if (objectLocator.Keys.Contains("NativeProperty"))
            {
                identifier = "NativeProperty";
                LocatorValue = objectLocator["NativeProperty"];
            }
            if (objectLocator.Keys.Contains("ControlType"))
            {
                identifier = "ControlType";
                LocatorValue = objectLocator["ControlType"];
            }
            return LocatorValue;
        }

        /// <summary>
        /// Gets the identification values.
        /// </summary>
        /// <param name="gMapCollection">The g map collection.</param>
        /// <param name="logicalName">Name of the logical.</param>
        private void GetIdentificationValues(Dictionary<string, GuiMap> gMapCollection, String logicalName)
        {
            GuiMap gMap = null;
            Dictionary<string, string> Identites = new Dictionary<string, string>();
            string LocatorValue = string.Empty;
            if (gMapCollection.ContainsKey(logicalName))
            {
                gMap = gMapCollection[logicalName];
            }
            Identites = gMap.MultIdentities;
            LocatorValue = ExtractLocator(Identites);
            switch (FindType(identifier.ToLower()))
            {
                case FindBy.Text:
                    Search = SearchCriteria.ByText(LocatorValue);
                    break;

                case FindBy.AutomationId:
                    Search = SearchCriteria.ByAutomationId(LocatorValue);
                    break;

                case FindBy.ClassName:
                    Search = SearchCriteria.ByClassName(LocatorValue);
                    break;

                case FindBy.ControlType:
                    Search = SearchCriteria.ByControlType(GetControlType(LocatorValue));
                    break;

                case FindBy.FrameworkId:
                    //Search = SearchCriteria.ByFramework(LocatorValue);
                    break;

                case FindBy.NativeProperty:
                    //Search = SearchCriteria.ByNativeProperty()
                    break;

                default:
                    Search = SearchCriteria.ByText(LocatorValue);
                    break;
            }
            Identites.Remove(identifier);
            foreach(KeyValuePair<string, string> myKeyValues in Identites)
            {           
                LocatorValue = myKeyValues.Key;
                switch (FindType(LocatorValue.ToLower()))
                {
                    case FindBy.Text:
                        Search = Search.AndByText(myKeyValues.Value);
                        break;

                    case FindBy.AutomationId:
                        Search = Search.AndAutomationId(myKeyValues.Value);
                        break;

                    case FindBy.ClassName:
                        Search = Search.AndByClassName(myKeyValues.Value);
                        break;

                    case FindBy.ControlType:
                        Search = Search.AndControlType(GetControlType(myKeyValues.Value));
                        break;

                    case FindBy.FrameworkId:
                        //Search = Search.AndOfFramework((WindowsFramework)myKeyValues.Value);
                        break;

                    case FindBy.NativeProperty:
                        //Search = SearchCriteria.ByNativeProperty()
                        break;

                    default:
                        Search = SearchCriteria.ByText(myKeyValues.Value);
                        break;
                }
            }
        }
    }
}

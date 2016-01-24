using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AuScGen.WhiteFramework.GUIMapParser
{
    class GuiMapParser
    {
        //Identifier constants
        private const String id = "id";
        private const String text = "text";
        private const String classname = "class";
        private const String nativeProperty = "nativeProperty";
        private const String controlType = "controlType";
        private const String framework = "framework";
        private const String multiple = "multiple";
        private const String xmlNodePath = "/ObjectRepository/FeatureSet";
        private static GuiMapParser guiMapParser;

        private GuiMapParser() { }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static GuiMapParser GetInstance()
        {
            if (guiMapParser == null)
            {
                guiMapParser = new GuiMapParser();
                return guiMapParser;
            }
            return guiMapParser;
        }

        /// <summary>
        /// Loads the GUI map.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public Dictionary<String, GuiMap> LoadGuiMap(String filePath)
        {
            XmlDocument doc = new XmlDocument();
            Dictionary<String, GuiMap> guiObjCollection = null;
            try
            {
                List<string> IdentType = new List<string>();
                List<string> Value = new List<string>();
                string logicalName = string.Empty;
                string identificationType = string.Empty;
                string elementValue = string.Empty;

                doc.Load(filePath);
                XmlNodeList rootNode = doc.DocumentElement.SelectNodes(xmlNodePath);
                //Create a dictionary object that can hold key value pairs of string and GUIMap objects
                guiObjCollection = new Dictionary<string, GuiMap>();
                GuiMap guimap = null;
                foreach (XmlNode featureSetNode in rootNode)
                {
                    XmlNodeList elementNodes = featureSetNode.ChildNodes;
                    foreach (XmlNode node in elementNodes)
                    {
                        guimap = new GuiMap();
                        logicalName = node.Attributes["name"].InnerText;
                        guimap.LogicalName = logicalName;
                        XmlNodeList mulNode = node.ChildNodes;
                        if (node.ChildNodes.Count > 0)
                        {
                            foreach (XmlNode nod in mulNode)
                            {
                                for (int i = 0; i <= node.ChildNodes.Count - 1; i++)
                                {
                                    IdentType.Add(node.ChildNodes[i].Name);
                                    Value.Add(node.ChildNodes[i].InnerText);
                                    switch (IdentType[i].ToLower())
                                    {
                                        case id:
                                            guimap.MultIdentities.Add(IdentType[i], Value[i]);
                                            continue;
                                        case text:
                                            guimap.MultIdentities.Add(IdentType[i], Value[i]);
                                            continue;
                                    }
                                }
                                break;
                            }
                        }
                        if (!guiObjCollection.ContainsKey(guimap.LogicalName))
                        {
                            guiObjCollection.Add(guimap.LogicalName, guimap);
                            IdentType.Clear();
                            Value.Clear();                    
                        }
                    }
                }
            }
            catch (FileNotFoundException fne)
            {
            }
            catch (Exception ex)
            {
                string message = "Exception occured while loading the values" +
                    "from Gui map xml" + filePath + "not found";
            }
            return guiObjCollection;
        }

    }
}

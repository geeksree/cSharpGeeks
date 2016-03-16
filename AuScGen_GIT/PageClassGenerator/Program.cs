using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace PageClassGenerator
{
    public class Program
    {
        private static NameValueCollection AppSettings
        {
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }

        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            XmlDocument xmldoc = new XmlDocument();
            string GUIMapPath = AppSettings.Get("GuimapFolder");
            Console.WriteLine("Give the complete name of the file including the extension");
            string fileName = Console.ReadLine();
            GUIMapPath = GUIMapPath + fileName;
            xmldoc.Load(GUIMapPath);
            string[] name = fileName.Split('.');
            string className = name[0];

            sb.Append("using " + AppSettings.Get("Using1") + ";\n");
            sb.Append("using " + AppSettings.Get("Using2") + ";\n");
            sb.Append("using " + AppSettings.Get("Using3") + ";\n");
            sb.Append("using " + AppSettings.Get("Using4") + ";\n");
            sb.Append("using " + AppSettings.Get("Using5") + ";\n");
            sb.Append("using " + AppSettings.Get("Using6") + ";\n\n");
            sb.Append("namespace " + AppSettings.Get("NameSpace") + "\n");
            sb.Append("{\n");
            sb.Append("\tpublic class " + className + " : " + AppSettings.Get("BaseClass") + "\n");
            sb.Append("\t{");
            sb.Append("\n\t\tprivate string guiMap;\n\t\tprivate List<object> utilityList;\n");
            sb.Append("\t\tpublic " + className + "(List<object> utilsList)\n");
            sb.Append("\t\t\t:base(utilsList, \"" + fileName + "\")\n\t\t{\n");
            sb.Append("\t\t\tguiMap = string.Concat(GuiMapPath, \"" + fileName + "\");\n");
            sb.Append("\t\t\tutilityList = utilsList;\n\t\t}\n\n");

            XmlNodeList xmlNodeList = xmldoc.SelectNodes("ObjectRepository/FeatureSet/Element");
            foreach (XmlNode item in xmlNodeList)
            {
               
                sb.Append("\t\tpublic ");
                sb.Append(ControlSelect(item.Attributes["type"].Value));
                sb.Append(" ");
                sb.Append(item.Attributes["name"].Value);
                sb.Append("\n");
                sb.Append("\t\t{");
                sb.Append("\n");
                sb.Append("\t\t\tget");
                sb.Append("\n");
                sb.Append("\t\t\t{");
                sb.Append("\n");           
                sb.Append("\t\t\t\treturn GetHtmlControl<");
                sb.Append(ControlSelect(item.Attributes["type"].Value));
                sb.Append("> (\"");
                sb.Append(item.Attributes["name"].Value);
                sb.Append("\");");
                sb.Append("\n");
                sb.Append("\t\t\t}");
                sb.Append("\n");
                sb.Append("\t\t}");
                sb.Append("\n");
                sb.Append("\n");
            }

            sb.Append("\t}\n");
            sb.Append("}\n");

            //Console.WriteLine(sb.ToString());
            //string xmlready = sb.ToString();
            string outputPath = AppSettings.Get("PageClassFolder") + fileName;
            File.WriteAllText(GetUniqueFileName(outputPath), sb.ToString());
        }

        public static string GetUniqueFileName(string filePath)
        {
            string baseName = Path.Combine(Path.GetDirectoryName(filePath), Path.GetFileNameWithoutExtension(filePath));
            string uniqueName = string.Format("{0}{1}", baseName, ".cs");
            return uniqueName;
        }

        public static string ControlSelect(string text)
        {
            switch (text)
            {
                case "SpanArea" :
                    return "WebSpanArea";
                case "Textbox":
                    return "WebEditBox";
                case "Combobox":
                    return "WebComboBox";
                case "Dialog":
                    return "WebDialog";
                case "Button":
                    return "WebButton";
                case "Label":
                    return "WebLabel";
                case "Calender":
                    return "WebCalender";
                case "Frame":
                    return "WebFrame";
                case "Image":
                    return "WebImage";
                case "Link":
                    return "WebLink";
                case "Listbox":
                    return "WebListBox";
                case "Page":
                    return "WebPage";
                case "Radio Button":
                    return "WebRadioButton";
                case "Web Table":
                    return "WebTable";
                default:
                    return "WebControl";
            }
        }

    }
}

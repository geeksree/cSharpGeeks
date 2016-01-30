using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework
{
    enum FindBy
    {
        Text,
        AutomationId,
        ClassName,
        ControlType,
        FrameworkId,
        NativeProperty,
        Multiple
    }

    class GuiMap
    {
        private string id;
        private string text;
        private string className;
        private string controlType;
        private string framework;
        private string nativeProperty;
        
        private string logicalName;
        private string identificationType;
        private Dictionary<string, string> multIdentities = new Dictionary<string, string>();

        public Dictionary<string,string> MultIdentities
        {
            get { return multIdentities; }
            set { multIdentities = value; }
        }

        public GuiMap() { }

        public string LogicalName
        {
            get { return logicalName; }
            set { logicalName = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        public string ControlType
        {
            get { return controlType; }
            set { controlType = value; }
        }

        public string NativeProperty
        {
            get { return nativeProperty; }
            set { nativeProperty = value; }
        }

        public string Framework
        {
            get { return framework; }
            set { framework = value; }
        }

        public string IdentificationType
        {
            get { return identificationType; }
            set { identificationType = value; }          
        }

        //public string Tagname
        //{
        //    get { return tagname; }
        //    set { tagname = value; }
        //}

        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}

        //public string Xpath
        //{
        //    get { return xpath; }
        //    set { xpath = value; }
        //}

        //public string Content
        //{
        //    get { return content; }
        //    set { content = value; }
        //}

        //public string Atribute
        //{
        //    get { return atribute; }
        //    set { atribute = value; }
        //}


        //public List<string> MultIdentities
        //{
        //    get { return multIdentities; }
        //    set { multIdentities.Add(value); }
        //}

        //private string content;
        //private string atribute;

        //private string tagname;

        //private string name;

        //private string xpath;
    }
}

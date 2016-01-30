using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;

namespace AuScGen.WhiteFramework
{
    public class ControlAccess
    {
        private WhiteFramework aFramework;
        public WhiteFramework Framework 
        { 
            get
            {
                if (null == aFramework)
                {
                    aFramework = new WhiteFramework();
                }
                return aFramework;
            }
        }

        public string ProcessName { get; set; }
        public string AppWindowName { get; set; }

        internal UIItem UIControl { get; set; }

        public List<UIItem> Children 
        { 
            get
            {
                return Framework.AppWindow.ItemsWithin(UIControl);
            }
        }

        public ControlAccess()
        { }

        public void InitializeAppWindow()
        {
            Application aApplication = Application.Attach(ProcessName);
            Framework.AppWindow = aApplication.GetWindow(AppWindowName, InitializeOption.NoCache);
        }

        public void IntitializeControl<T>(string GuiMap,string LogicalName) where T : UIItem
        {  
            UIControl = Framework.GetControl<T>(GuiMap, LogicalName);            
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework
{
    public class ListView : BaseControl , IControl
    {
        public ListView(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.ListView>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;

        }        

        private TestStack.White.UIItems.ListView listview
        {
            get
            {
                return (TestStack.White.UIItems.ListView)Control;
            }
        }  
    }
}

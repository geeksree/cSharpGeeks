using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework
{
    public class ListItem : BaseControl , IControl
    {
        public ListItem(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.ListBoxItems.ListItem>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;

        }

        private TestStack.White.UIItems.ListBoxItems.ListItem listview
        {
            get
            {
                return (TestStack.White.UIItems.ListBoxItems.ListItem)Control;
            }
        }  
    }
}

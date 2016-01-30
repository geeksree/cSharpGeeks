using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework
{
    public class Checkbox : BaseControl , ICheckbox
    {
        public Checkbox(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.CheckBox>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;

        }

        private TestStack.White.UIItems.CheckBox checkbox
        {
            get
            {
                return (TestStack.White.UIItems.CheckBox)Control;
            }
        }        
    }
}

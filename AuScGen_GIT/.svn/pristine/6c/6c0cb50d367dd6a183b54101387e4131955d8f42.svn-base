using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework
{
    public class Label : BaseControl , IControl
    {
        public Label(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.Label>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;
        }        

        protected TestStack.White.UIItems.Label label
        {
            get
            {
                return (TestStack.White.UIItems.Label)Control;
            }
        }

        public string Text 
        { 
            get
            {
                return label.Text;
            }
        }
    }
}

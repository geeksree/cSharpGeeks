using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework
{
    public class RadioButton : BaseControl , IRadioButton
    {
        public RadioButton(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.RadioButton>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;

        }

        private TestStack.White.UIItems.RadioButton radioButton
        {
            get
            {
                return (TestStack.White.UIItems.RadioButton)Control;
            }
        }
    }
}

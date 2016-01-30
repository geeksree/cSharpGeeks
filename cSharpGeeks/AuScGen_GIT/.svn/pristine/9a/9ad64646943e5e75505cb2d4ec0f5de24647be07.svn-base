using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework
{
    public class DateTimePicker : BaseControl , IControl
    {
        public DateTimePicker(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.DateTimePicker>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;
        }

        private TestStack.White.UIItems.DateTimePicker datetimepicker
        {
            get
            {
                return (TestStack.White.UIItems.DateTimePicker)Control;
            }
        }      
    }
}

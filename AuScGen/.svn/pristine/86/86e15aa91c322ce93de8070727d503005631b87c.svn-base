using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.Recording;

namespace AuScGen.WhiteFramework
{
    public class Hyperlink : BaseControl , IControl
    {
        public Hyperlink(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.Hyperlink>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;
        }

        private TestStack.White.UIItems.Hyperlink hyperlink
        {
            get
            {
                return (TestStack.White.UIItems.Hyperlink)Control;
            }
        }
    }
}

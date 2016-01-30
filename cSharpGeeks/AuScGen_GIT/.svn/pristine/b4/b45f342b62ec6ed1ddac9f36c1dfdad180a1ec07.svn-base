using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework
{
    public class ProgressBar : BaseControl , IControl
    {
        public ProgressBar(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.ProgressBar>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;

        }

        private TestStack.White.UIItems.ProgressBar progressbar
        {
            get
            {
                return (TestStack.White.UIItems.ProgressBar)Control;
            }
        }      
    }
}

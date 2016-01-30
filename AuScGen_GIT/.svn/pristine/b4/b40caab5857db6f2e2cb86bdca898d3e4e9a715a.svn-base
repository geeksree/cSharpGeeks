using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework
{
    class Image : BaseControl , IControl
    {
        public Image(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.Image>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;

        }        

        private TestStack.White.UIItems.Image image
        {
            get
            {
                return (TestStack.White.UIItems.Image)Control;
            }
        }
    }
}

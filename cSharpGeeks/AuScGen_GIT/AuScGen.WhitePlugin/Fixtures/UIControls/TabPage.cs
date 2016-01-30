using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.Actions;

namespace AuScGen.WhiteFramework
{
    public class TabPage : BaseControl , IControl
    {
        internal TabPage(TestStack.White.UIItems.TabItems.TabPage control, ControlAccess ControlAccess)
        {
            Control = control;
            myControlAccess = ControlAccess;
        }

        private TestStack.White.UIItems.TabItems.TabPage tabPage
        {
            get
            {
                return (TestStack.White.UIItems.TabItems.TabPage)Control;
            }
        }

        public bool IsSelected 
        { 
            get
            {
                return tabPage.IsSelected;
            }
        }

        public void Select()
        {
            tabPage.Select();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems.TabItems;

namespace AuScGen.WhiteFramework
{
    public class Tab : BaseControl , IControl
    {
        public Tab(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.TabItems.Tab>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;

        }        

        private TestStack.White.UIItems.TabItems.Tab tab
        {
            get
            {
                return (TestStack.White.UIItems.TabItems.Tab)Control;
            }
        }

        public List<TabPage> Pages()
        {
            TabPages pages = tab.Pages;
            List<TabPage> frameWorkPages = new List<TabPage>();

            foreach(TestStack.White.UIItems.TabItems.TabPage page in pages)
            {
                frameWorkPages.Add(new TabPage(page,myControlAccess));
            }
            return frameWorkPages;
        }
    }
}

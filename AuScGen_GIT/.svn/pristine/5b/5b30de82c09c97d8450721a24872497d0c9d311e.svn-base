using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TestStack.White.UIItems;

namespace AuScGen.WhiteFramework
{
    public class Panel : BaseControl , IPanel
    {
        private UIItemContainer controlContainer;

        public Panel(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.Panel>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;
            controlContainer = (UIItemContainer)Control;
        }

        private TestStack.White.UIItems.Panel panel
        {
            get
            {
                return (TestStack.White.UIItems.Panel)Control;
            }
        }

        private TestStack.White.UIItems.Panel panelContainer
        {
            get
            {
                return (TestStack.White.UIItems.Panel)controlContainer;
            }
        }

        public IUIItem Get(TestStack.White.UIItems.Finders.SearchCriteria searchCriteria)
        {
            return panelContainer.Get(searchCriteria);
        }

        public T Get<T>(TestStack.White.UIItems.Finders.SearchCriteria searchCriteria) where T : IUIItem
        {
            return panelContainer.Get<T>(searchCriteria);
        }

        public T Get<T>(string primaryIdentification) where T : IUIItem
        {
            return panelContainer.Get<T>(primaryIdentification);
        }

        public T Get<T>() where T : IUIItem
        {
            return panelContainer.Get<T>();
        }

        public IUIItem[] GetMultiple(TestStack.White.UIItems.Finders.SearchCriteria criteria)
        {
            return panelContainer.GetMultiple(criteria);
        }

        public ToolTip GetToolTipOn(UIItem uiItem)
        {
            return panelContainer.GetToolTipOn(uiItem);
        }

        public ToolTip ToolTip
        {
            get 
            {
                return panelContainer.ToolTip;
            }
        }
    }
}

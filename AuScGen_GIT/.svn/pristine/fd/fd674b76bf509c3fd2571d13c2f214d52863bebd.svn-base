using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White.UIItems;

namespace AuScGen.WhiteFramework
{
    public class GroupBox : BaseControl , IGroupBox
    {
        private UIItemContainer controlContainer;

        public GroupBox(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            : base(GuiMap, LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.GroupBox>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;
            controlContainer = (UIItemContainer)Control;
        }

        private TestStack.White.UIItems.GroupBox groupBox
        {
            get
            {
                return (TestStack.White.UIItems.GroupBox)Control;
            }
        }

        private TestStack.White.UIItems.GroupBox groupBoxContainer
        {
            get
            {
                return (TestStack.White.UIItems.GroupBox)controlContainer;
            }
        }

        public IUIItem Get(TestStack.White.UIItems.Finders.SearchCriteria searchCriteria)
        {
            return groupBoxContainer.Get(searchCriteria);
        }

        public T Get<T>(TestStack.White.UIItems.Finders.SearchCriteria searchCriteria) where T : IUIItem
        {
            return groupBoxContainer.Get<T>(searchCriteria);
        }

        public T Get<T>(string primaryIdentification) where T : IUIItem
        {
            return groupBoxContainer.Get<T>(primaryIdentification);
        }

        public T Get<T>() where T : IUIItem
        {
            return groupBoxContainer.Get<T>();
        }

        public IUIItem[] GetMultiple(TestStack.White.UIItems.Finders.SearchCriteria criteria)
        {
            return groupBoxContainer.GetMultiple(criteria);
        }

        public ToolTip GetToolTipOn(UIItem uiItem)
        {
            return groupBoxContainer.GetToolTipOn(uiItem);
        }

        public ToolTip ToolTip
        {
            get 
            {
                return groupBoxContainer.ToolTip;
            }
        }       
    }
}

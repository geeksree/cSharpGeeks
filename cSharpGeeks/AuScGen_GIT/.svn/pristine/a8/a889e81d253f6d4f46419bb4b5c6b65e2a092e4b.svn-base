using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using System.ComponentModel.Composition;

namespace AuScGen.WhiteFramework
{

    [Export(typeof(IContainerPlugin))]
    public class WhitePlugin : IContainerPlugin
    {
        private ControlAccess aControlAccess;
        internal ControlAccess myControlAccess 
        { 
            get
            {
                if(null == aControlAccess)
                {
                    aControlAccess = new ControlAccess();
                    aControlAccess.ProcessName = ProcessName;
                    aControlAccess.AppWindowName = AppWindowName;
                    aControlAccess.InitializeAppWindow();
                }
                return aControlAccess;
            }
        }
        
        public string ProcessName { get; set; }
        public string AppWindowName { get; set; }
        public string GuiMapPath { get; set; }  

        public BaseControl BaseControl(string LogicalName)
        {
            return new BaseControl(GuiMapPath, LogicalName, myControlAccess);
        }

        public Button Button(string LogicalName)
        {
            return new Button(GuiMapPath, LogicalName, myControlAccess);
        }

        public Checkbox Checkbox(string LogicalName)
        {
            return new Checkbox(GuiMapPath, LogicalName, myControlAccess);
        }

        public RadioButton RadioButton(string LogicalName)
        {
            return new RadioButton(GuiMapPath, LogicalName, myControlAccess);
        }

        public Label Label(string LogicalName)
        {
            return new Label(GuiMapPath, LogicalName, myControlAccess);
        }

        public DateTimePicker DateTimePicker(string LogicalName)
        {
            return new DateTimePicker(GuiMapPath, LogicalName, myControlAccess);
        }

        public GroupBox GroupBox(string LogicalName)
        {
            return new GroupBox(GuiMapPath, LogicalName, myControlAccess);
        }

        public Hyperlink Hyperlink(string LogicalName)
        {
            return new Hyperlink(GuiMapPath, LogicalName, myControlAccess);
        }

        public Panel Panel(string LogicalName)
        {
            return new Panel(GuiMapPath, LogicalName, myControlAccess);
        }

        public ProgressBar ProgressBar(string LogicalName)
        {
            return new ProgressBar(GuiMapPath, LogicalName, myControlAccess);
        }

        public ListItem ListItem(string LogicalName)
        {
            return new ListItem(GuiMapPath, LogicalName, myControlAccess);
        }

        public Tab Tab(string LogicalName)
        {
            return new Tab(GuiMapPath, LogicalName, myControlAccess);
        }

        public string Description
        {
            get
            {
                return "White Plugin";
            }
            set
            {
                Description = value;
            }
        }
    }
}

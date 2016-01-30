using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

using TestStack.White.UIItems;
using TestStack.White.UIItems.Actions;
using TestStack.White.UIItems.Scrolling;

namespace AuScGen.WhiteFramework
{
    public enum SearchType
    {
        AutomationId,
        Name
    }

    public enum ControlType
    {
        UIItem,

        Button,

        EditBox,

        Custom
    }

    public class BaseControl : IControl
    {
        #region Internal Properties

        protected internal ControlAccess myControlAccess { get; set; }
        protected internal UIItem Control { get; set; }
        public List<BaseControl> Children 
        { 
            get
            {
                //return myControlAccess.Children;
                return GetChildren(AutomationElement);
            }
        }
        
        #endregion Internal Properties

        #region Constructor

        public BaseControl(AutomationElement control, ControlAccess ControlAccess) 
        {
            myControlAccess = ControlAccess;
            AutomationElement = control;            
        }

        public BaseControl()
        {

        }

        public BaseControl(string Guimap, string ControlName)
        {
            //myControlAccess = new ControlAccess();
            this.GuimapPath = Guimap;
            this.LogicalName = ControlName;
        }

        public BaseControl(string GuiMap, string LogicalName, ControlAccess ControlAccess)
            :this(GuiMap,LogicalName)
        {
            myControlAccess = ControlAccess;
            myControlAccess.IntitializeControl<TestStack.White.UIItems.UIItem>(GuimapPath, LogicalName);
            Control = myControlAccess.UIControl;
        }

        #endregion Constructor

        #region Public Properties  
      
        protected string GuimapPath { get; set; }

        protected string LogicalName { get; set; }

        public Rectangle Bounds
        {
            get
            {
                Rectangle aRect = new Rectangle();
                aRect.X = (int)Control.Bounds.X;
                aRect.Y = (int)Control.Bounds.Y;
                return aRect;
            }
        }        

        public Point ClickablePoint
        {
            get
            {
                return new Point((int)Control.ClickablePoint.X, (int)Control.ClickablePoint.Y);
            }
        }        

        public virtual AutomationElement AutomationElement
        {
            get 
            {
                return Control.AutomationElement;
            }

            private set
            {
                Control = new UIItem(value, myControlAccess.Framework.AppWindow.ActionListener);
            }
        }

        public virtual bool Enabled
        {
            get 
            {
                return Control.Enabled;
            }
        }

        public virtual WindowsFramework Framework
        {
            get 
            {
                return Control.Framework;
            }
        }

        public virtual string Name
        {
            get 
            {
                return Control.Name;
            }
        }

        public virtual string AccessKey
        {
            get 
            {
                return Control.AccessKey;             
            }
        }

        public virtual string Id
        {
            get 
            {
                return Control.Id;
            }
        }

        public virtual bool Visible
        {
            get 
            {
                return Control.Visible;
            }
        }

        public virtual string PrimaryIdentification
        {
            get 
            {
                return Control.PrimaryIdentification;
            }
        }

        public virtual ActionListener ActionListener
        {
            get 
            {
                return Control.ActionListener;
            }
        }

        public virtual IScrollBars ScrollBars
        {
            get 
            {
                return Control.ScrollBars;
            }
        }

        public virtual bool IsOffScreen
        {
            get 
            {
                return Control.IsOffScreen;
            }
        }

        public virtual bool IsFocussed
        {
            get 
            {
                return Control.IsFocussed;
            }
        }

        public virtual Color BorderColor
        {
            get 
            {
                return Control.BorderColor;
            }
        }

        public virtual Bitmap VisibleImage
        {
            get 
            {
                return Control.VisibleImage;
            }
        }

        public virtual bool ValueOfEquals(AutomationProperty property, object compareTo)
        {
            return Control.ValueOfEquals(property, compareTo);
        }

        public virtual void RightClickAt(System.Windows.Point point)
        {
            Control.RightClickAt(point);
        }

        public virtual void RightClick()
        {
            Control.RightClick();
        }

        public virtual void Focus()
        {
            Control.Focus();
        }

        public virtual void Visit(TestStack.White.WindowControlVisitor windowControlVisitor)
        {
            Control.Visit(windowControlVisitor);
        }          
    
        System.Windows.Rect IUIItem.Bounds
        {
            get 
            {
                return Control.Bounds;
            }
        }

        public void Click()
        {
            Control.Click();
        }

        System.Windows.Point IUIItem.ClickablePoint
        {
            get 
            {
                return Control.ClickablePoint;
            }
        }

        public void DoubleClick()
        {
            Control.DoubleClick();
        }

        public void DrawHighlight()
        {
            Control.DrawHighlight();
        }

        public void Enter(string value)
        {
            Control.Enter(value);
        }

        public string ErrorProviderMessage(TestStack.White.UIItems.WindowItems.Window window)
        {
           return Control.ErrorProviderMessage(window);
        }

        public AutomationElement GetElement(TestStack.White.UIItems.Finders.SearchCriteria searchCriteria)
        {
            return Control.GetElement(searchCriteria);
        }

        public virtual void HookEvents(TestStack.White.Recording.UIItemEventListener eventListener)
        {
            Control.HookEvents(eventListener);
        }

        public void KeyIn(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys key)
        {
            Control.KeyIn(key);
        }

        public System.Windows.Point Location
        {
            get { throw new NotImplementedException(); }
        }

        public void LogStructure()
        {
            Control.LogStructure();
        }

        public bool NameMatches(string text)
        {
            return Control.NameMatches(text);
        }

        public void SetValue(object value)
        {
            Control.SetValue(value);
        }

        public virtual void UnHookEvents()
        {
            Control.UnHookEvents();
        }

        public void ActionPerformed(TestStack.White.UIItems.Actions.Action action)
        {
            Control.ActionPerformed(action);
        }

        public void ActionPerforming(UIItem uiItem)
        {
            Control.ActionPerforming(uiItem);
        }
        
        #endregion Public Properties

        #region Private Methods

        internal List<BaseControl> GetChildren(AutomationElement element_in)
        {
            //Trace.TraceInformation(String.Format("{0}: Try to get MSUIA children from AutomationElement...", ""));
            if (null == element_in)
            {
                throw new ArgumentNullException("element_in");
            }
            List<AutomationElement> aList = new List<AutomationElement>(0);
            AutomationElement aChild = TreeWalker.RawViewWalker.GetFirstChild(element_in);

            while (null != aChild)
            {
                aList.Add(aChild);
                aChild = TreeWalker.RawViewWalker.GetNextSibling(aChild);
            }
            //Trace.TraceInformation(String.Format("{0}: MSUIA children from AutomationElement found.", ""));
            //return aList;

            List<BaseControl> controls = new List<BaseControl>();
            aList.ForEach(auto => 
            {
                controls.Add(new BaseControl(auto, myControlAccess));
            });

            return controls;
        }

        #endregion Private Methods

    }
}

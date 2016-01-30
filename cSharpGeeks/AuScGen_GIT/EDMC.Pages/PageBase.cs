using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using UIAccess.WebControls;
using UIAccess;


namespace EDMC.Pages
{
    public class PageBase
    {
        private string completeGuiMapPath;

        private AuScGen.CommonUtilityPlugin.DataAccess dBAccess;
        protected AuScGen.CommonUtilityPlugin.DataAccess DBAccess
        {
            get
            {
                return dBAccess;
            }
        }

        private WebDriverPlugin webDriver;
        protected WebDriverPlugin WebDriver
        {
            get
            {
                return webDriver;
            }
        }

        //private Utils.Wait wait;
        //public Utils.Wait Wait 
        //{ 
        //    get
        //    {
        //        return new Utils.Wait(Telerik);
        //    }
        //}

        private AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator keyboardSimulator;
        protected AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator KeyBoardSimulator
        {
            get
            {
                return keyboardSimulator;
            }
        }

        protected static string GuiMapPath
        {
            get
            {
                return Directory.GetCurrentDirectory() + @"\GuiMaps\";
            }
        }

        public PageBase(WebDriverPlugin webDriverPlugin)
        {
            webDriver = webDriverPlugin;
        }

        public PageBase(WebDriverPlugin webDriverPlugin, string guiMapName)
            : this(webDriverPlugin)
        {
            completeGuiMapPath = string.Concat(GuiMapPath, guiMapName);
        }

        public PageBase(List<object> utils)
        {
            foreach (object util in utils)
            {
                if (util is WebDriverPlugin)
                {
                    webDriver = (WebDriverPlugin)util;
                }

                if (util is AuScGen.CommonUtilityPlugin.DataAccess)
                {
                    dBAccess = (AuScGen.CommonUtilityPlugin.DataAccess)util;
                }

                if (util is AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator)
                {
                    keyboardSimulator = (AuScGen.CommonUtilityPlugin.MouseKeyBoardSimulator)util;
                }
            }
        }

        public PageBase(List<object> utils, string guiMapName)
            : this(utils)
        {
            completeGuiMapPath = string.Concat(GuiMapPath, guiMapName);
        }

        public bool IsPresent<T>(string logicalName,int waitBeforeCheck) where T : WebControl
        {
            Thread.Sleep(waitBeforeCheck);
            if (null == WebDriver.GetControl<T>(completeGuiMapPath, logicalName).SeleniumControl)
            {
                return false;
            }

            return true;
        }

        public T GetHtmlControl<T>(string GUIMap, string LogicalName) where T : WebControl
        {
            T Ctrl = null;

            Ctrl = WebDriver.WaitForControl<T>(GUIMap, LogicalName,
                                                Config.PageClassSettings.Default.MaxTimeoutValue);
            if (Ctrl == null)
            {
                //throw new GUIException(LogicalName, "Element not found on the Screen");
            }       
            return Ctrl;
        }

        public T GetHtmlControl<T>(string logicalName) where T : WebControl
        {
            return GetHtmlControl<T>(completeGuiMapPath, logicalName);
        }

    }
}

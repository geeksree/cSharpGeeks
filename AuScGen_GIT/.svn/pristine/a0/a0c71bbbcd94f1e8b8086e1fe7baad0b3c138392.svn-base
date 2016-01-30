using ArtOfTest.WebAii.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuScGen.TelerikPlugin;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.Common.Exceptions;
using System.Collections;
using System.Threading;
using ArtOfTest.WebAii.TestTemplates;

namespace AuScGen.Pages
{
    public class PageBase
    {
        private string completeGuiMapPath;

        private AuScGen.TelerikPlugin.TelerikFramework telerik;
        protected AuScGen.TelerikPlugin.TelerikFramework Telerik
        {
            get
            {
                return telerik;
            }
        }

        private AuScGen.CommonUtilityPlugin.DataAccess dBAccess;
        protected AuScGen.CommonUtilityPlugin.DataAccess DBAccess
        {
            get
            {
                return dBAccess;
            }
        }

        private Utils.Wait wait;
        public Utils.Wait Wait 
        { 
            get
            {
                return new Utils.Wait(Telerik);
            }
        }

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

        public PageBase(AuScGen.TelerikPlugin.TelerikFramework TelerikPlugin)
        {
            telerik = TelerikPlugin;
        }

        public PageBase(AuScGen.TelerikPlugin.TelerikFramework TelerikPlugin, string guiMapName)
            : this(TelerikPlugin)
        {
            completeGuiMapPath = string.Concat(GuiMapPath, guiMapName);
        }

        public PageBase(List<object> utils)
        {
            foreach (object util in utils)
            {
                if (util is AuScGen.TelerikPlugin.TelerikFramework)
                {
                    telerik = (AuScGen.TelerikPlugin.TelerikFramework)util;
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

        public bool IsPresent<T>(string logicalName) where T : Control, new()
        {
            Thread.Sleep(3000);
            if (null == Telerik.GetControl<T>(completeGuiMapPath, logicalName))
            {
                return false;
            }

            return true;
        }

        public T GetHtmlControl<T>(string GUIMap, string LogicalName) where T : Control, new()
        {
            T Ctrl = null;

            Ctrl = Telerik.WaitForControl<T>(GUIMap, LogicalName,
                                                Config.PageClassSettings.Default.MaxTimeoutValue);
            if (Ctrl == null)
            {
                throw new GUIException(LogicalName, "Element not found on the Screen");
            }       
            return Ctrl;
        }

        public T GetHtmlControl<T>(string logicalName) where T : Control, new()
        {
            return GetHtmlControl<T>(completeGuiMapPath, logicalName);
        }

    }
}

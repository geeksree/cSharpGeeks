using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.Pages.CommonControls
{
    public class Tray
    {
        private TelerikPlugin.TelerikFramework telerik;
        private string myguiMap;

        public Tray(TelerikPlugin.TelerikFramework telerik, string guiMapPath)
        {
            this.telerik = telerik;
            myguiMap = string.Concat(guiMapPath, "CommonControls.xml");
        }

        private Utils.Wait wait;
        public Utils.Wait Wait 
        {
            get
            {
                if(null == wait)
                {
                    wait = new Utils.Wait(telerik);
                }
                return wait;
            }
        }

        public HtmlButton TrayButton
        {
            get
            {
                return telerik.WaitForControl<HtmlButton>(myguiMap, "btnTrayButton",Config.PageClassSettings.Default.MaxTimeoutValue);
            }
        }

        private ReadOnlyCollection<HtmlControl> TrayOptions 
        { 
            get
            {
                return Wait.WaitforAction<ReadOnlyCollection<HtmlControl>>(() =>
                {
                    return telerik.Find.AllByXPath<HtmlControl>("html/body/div[1]/div[1]/ul/div[1]/div/li");
                }, Config.PageClassSettings.Default.MaxTimeoutValue);         
            }
        }

        public void ClickTrayItem(string itemName)
        {
            foreach(HtmlControl option in TrayOptions)
            {
                if(option.BaseElement.InnerText.ToLower().Trim().Equals(itemName))
                {
                    option.DeskTopMouseClick();
                }
            }
        }
    }
}

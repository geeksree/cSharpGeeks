using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.Pages
{
    public class AccntBalancePage : PageBase
    {
        private string guiMap;

        public AccntBalancePage(List<object> utilsList)
            : base(utilsList, "AccntBalancePage.xml")
        {
            guiMap = string.Concat(GuiMapPath, "AccntBalancePage.xml");
        }

        public HtmlControl AccountBalanceTab
        {
            get
            {
                return GetHtmlControl<HtmlControl>("AccountBalanceTab");
            }
        }

        public bool AccntBalanceTabPresent 
        { 
            get
            {
                return Wait.WaitforAction(() =>
                {

                    return AccountBalanceTab.BaseElement.InnerText.Contains("Account Balance");
                }, Config.PageClassSettings.Default.MaxTimeoutValue);
            }
        }
    }
}

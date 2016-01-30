using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.Pages
{
    public class LandingPage : PageBase
    {
        private string guiMap;

        public LandingPage(List<object> utilsList)
            : base(utilsList,"LandingPage.xml")
        {
            guiMap = string.Concat(GuiMapPath, "LoginPage.xml");

        }

        public HtmlControl MainTray
        {
            get
            {
                return GetHtmlControl<HtmlControl>("MainTray");
            }
        }

        private CommonControls.Tray mainTrayButton;
        public CommonControls.Tray Tray
        {
            get
            {
                if (null == mainTrayButton)
                {
                    mainTrayButton = new CommonControls.Tray(Telerik, GuiMapPath);
                }
                return mainTrayButton;
            }
        }
    }
}

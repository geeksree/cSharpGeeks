using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAccess.WebControls;

namespace AuScGen.SeleniumTestPage
{
    public class HomePage : PageBase
    {
        private string guiMap;

        public HomePage(List<object> utilsList)
            : base(utilsList, "HomePage.xml")
        {
            guiMap = string.Concat(GuiMapPath, "HomePage.xml");
        }

        public WebLink ProductsTab
        {
            get
            {
                return GetHtmlControl<WebLink>("LnkProducts");
            }
        }
        public bool IsPopupPresent
        {
            get
            {
                return IsPresent<WebControl>("PopupClose",3000);
            }
        }

        public WebControl PopupHandleClose
        {
            get
            {
                return GetHtmlControl<WebControl>("PopupClose");
            }
        }

        public WebControl SideTabHandle
        {
            get
            {
                return GetHtmlControl<WebControl>("SideTab");
            }
        }

        public WebButton UserMenu
        {
            get
            {
                return GetHtmlControl<WebButton>("MenuUser");
            }
        }

        public WebLink Logout
        {
            get
            {
                return GetHtmlControl<WebLink>("LnkLogout");
            }
        }
    }
}

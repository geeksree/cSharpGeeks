using ArtOfTest.WebAii.Controls.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.Pages
{
    public class LoginPage : PageBase
    {
        private string guiMap;

        public LoginPage(List<object> utilsList)
            : base(utilsList, "LoginPage.xml")
        {
            guiMap = string.Concat(GuiMapPath, "LoginPage.xml");
        }

        public HtmlControl UserName
        {
            get
            {
                return GetHtmlControl<HtmlControl>("txtUserName");
            }
        }

        public HtmlInputPassword Password
        {
            get
            {
                return GetHtmlControl<HtmlInputPassword>("txtPassword");
            }
        }

        public HtmlControl LoginButton
        {
            get
            {
                return GetHtmlControl<HtmlControl>("btnLogin");
            }
        }
    }
}

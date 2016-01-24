using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAccess.WebControls;

namespace AuScGen.SeleniumTestPage
{
    public class LoginPage : PageBase
    {
        private string guiMap;

        public LoginPage(List<object> utilsList)
            : base(utilsList, "LoginPage.xml")
        {
            guiMap = string.Concat(GuiMapPath, "LoginPage.xml");
        }

        //public WebEditBox Username
        //{ 
        //    get
        //    {
        //        return GetHtmlControl<WebEditBox>("TxtUserName");
        //    }
        //}

        //public WebEditBox Password
        //{
        //    get
        //    {
        //        return GetHtmlControl<WebEditBox>("TxtPassword");
        //    }
        //}

        //public WebButton LoginButton
        //{
        //    get
        //    {
        //        return GetHtmlControl<WebButton>("BtnLogin");
        //    }
        //}
        //public WebControl ITChoice
        //{
        //    get
        //    {
        //        return GetHtmlControl<WebControl>("ITChoice");
        //    }
        //}

        //public bool IsChoicePresent
        //{
        //    get
        //    {
        //        return IsPresent<WebButton>("ITChoice", 3000);
        //    }
        //}

        public WebButton LogInPageLink
        {
            get
            {
                return GetHtmlControl<WebButton>("loginPageLink");
            }
        }
        
        public WebEditBox Username
        {
            get
            {
                return GetHtmlControl<WebEditBox>("userName");
            }
        }

        public WebEditBox Password
        {
            get
            {
                return GetHtmlControl<WebEditBox>("password");
            }
        }

        public WebButton LogInButton
        {
            get
            {
                return GetHtmlControl<WebButton>("logInButton");
            }
        }


        public WebControl ITChoice
        {
            get
            {
                return GetHtmlControl<WebControl>("SearchBox");
            }
        }

        public bool IsChoicePresent
        {
            get
            {
                return IsPresent<WebLabel>("SearchBox", 3000);
            }
        }

    }
}

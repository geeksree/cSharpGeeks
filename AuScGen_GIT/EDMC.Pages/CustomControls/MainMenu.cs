using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAccess;
using UIAccess.WebControls;

namespace EDMC.Pages.CustomControls
{    

   public class MainMenu : PageBase
    {
        private string thisGuiMap;

        public MainMenu(List<object> utilsList, string guimap)
            : base(utilsList, guimap)
        {
            thisGuiMap = string.Concat(GuiMapPath, guimap);
        }

        public enum MainMenuItems
        {
            AboutEDMC, Locations, InvestorRelations, Newsroom, Careers
        }
                

        // EDMC Common Navigation bar

        //public WebControl NavAbout
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("menu"), "li").Where(control => control.Text.Equals("About EDMC")).FirstOrDefault();
        //    }
        //}


        //public WebControl NavLocations
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("menu"), "li").Where(control => control.Text.Equals("Locations")).FirstOrDefault();
        //    }
        //}


        //public WebControl NavInvestorRelations
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("menu"), "li").Where(control => control.Text.Equals("Investor Relations")).FirstOrDefault();
        //    }
        //}

        
        //public WebControl NavCareers
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("menu"), "li").Where(control => control.Text.Equals("Careers")).FirstOrDefault();
        //    }
        //}

        //// EDMC About page side Navigation bar

        //public WebControl SideNavSchools
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("Schools")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavCommunityService
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("Community Service")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavOurStrategicFocus
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("Our Strategic Focus")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavHistory
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("History")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavExecutiveOfficers
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("Executive Officers")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavBoardOfDirectors
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("Board of Directors")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavCorporatePartnership
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("Corporate Partnership")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavMilitaryEducation
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("Military Education")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavGovernmentRelations
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("Government Relations")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavComplianceAndEthics
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("Compliance and Ethics")).FirstOrDefault();
        //    }
        //}

        //public WebControl SideNavEDMCComplianceHotlineReporting
        //{
        //    get
        //    {
        //        return GetChildren(ControllerName("aboutEDMCSideNavigation"), "li").Where(control => control.Text.Equals("EDMC Compliance Hotline & Reporting")).FirstOrDefault();
        //    }
        //}

        // Common Navigation Menu bar

        //public WebControl CommonMenu
        //{
        //    get
        //    {
        //        return GetHtmlControl<WebControl>("menu");
        //    }
        //}

        //// About EDMC page side Navigation bar

        //public WebControl AboutEDMCPageSideMenu
        //{
        //    get
        //    {
        //        return GetHtmlControl<WebControl>("aboutEDMCSideNavigation");
        //    }
        //}



        // Getting list members

        //private List<WebControl> GetMainMenuItems
        //{
        //    get
        //    {
        //        return CommonMenu.GetChildren(new Locator(@"./li", WebDriverWrapper.LocatorType.Xpath), WebDriverWrapper.ControlType.Custom);
        //    }
        //}

        public WebControl ControllerName(String guiMapLogicalNameOfController)
        {
            return GetHtmlControl<WebControl>(guiMapLogicalNameOfController); 
        }

        private WebControl MainMenuControl 
        { 
            get
            {
                return ControllerName("menu");
            }
        }

        // Ex. "li"
        public List<WebControl> GetChildren()
        {
            return MainMenuControl.GetChildren(new Locator(@"./li", WebDriverWrapper.LocatorType.Xpath), WebDriverWrapper.ControlType.Custom);
        }

        public WebControl SpecificNavListItems(MainMenuItems item) {
            return GetChildren().Where(control => control.Text.Equals(ResolveItemLabel(item))).FirstOrDefault();
        }

        private string ResolveItemLabel(MainMenuItems item)
        {
            switch(item)
            {
                case MainMenuItems.AboutEDMC:
                    return "About EDMC";

                default:
                    return "About EDMC";
            }
        }
    }
}

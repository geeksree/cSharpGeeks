using EDMC.Pages.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAccess;
using UIAccess.WebControls;

namespace EDMC.Pages
{
    public class HomePage : PageBase
    {
        private string guiMap;
        private List<object> utilityList;

        public HomePage(List<object> utilsList)
            : base(utilsList, "CommonControls.xml")
        {
            guiMap = string.Concat(GuiMapPath, "CommonControls.xml");
            utilityList = utilsList;
        }
      
        public MainMenu MainMenuControl 
        { 
            get
            {
                return new MainMenu(utilityList, "CommonControls.xml");
            }
        }

       
    }
}

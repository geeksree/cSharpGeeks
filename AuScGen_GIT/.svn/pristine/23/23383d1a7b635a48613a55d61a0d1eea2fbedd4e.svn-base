using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Windows.Forms;


namespace AuScGen
{
    public static class HtmlButtonExtension
    {
        private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static HtmlButtonExtension()
        {
            log4net.ThreadContext.Properties["myContext"] = "Logging from HtmlSelectExtension Class";
            Logger.Debug("Inside HtmlButtonExtension Constructor!");
        }

        public static void TypeEnterKey(this HtmlButton control)
        {
            control.Focus();
            control.OwnerBrowser.Manager.Desktop.KeyBoard.KeyPress(Keys.Enter);
        }
    }
}

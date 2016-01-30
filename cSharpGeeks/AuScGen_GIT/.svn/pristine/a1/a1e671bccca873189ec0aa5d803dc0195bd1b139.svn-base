using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ArtOfTest.WebAii.Exceptions;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.TestTemplates;


namespace AuScGen
{
    public static class HtmlSelectExtension
    {
        private static log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static HtmlSelectExtension()
        {
            log4net.ThreadContext.Properties["myContext"] = "Logging from HtmlSelectExtension Class";
            Logger.Debug("Inside HtmlSelectExtension Constructor!");
        }
        
        public static void SelectByText(this HtmlSelect control, string text, int maxTimeout)
        {
            DateTime start;
            double timeElapsed = 0;
                        
            start = DateTime.Now;

            while (control.Options.Where(option => option.Text.Equals(text)).Count() == 0 && timeElapsed < maxTimeout)
            {
                control.Refresh();                
                timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
            }

            if (control.Options.Where(option => option.Text.Equals(text)).Count() != 0)
            {
                control.SelectByText(text,true);
                Logger.Debug(string.Format("Inside HtmlSelectExtension , option available in {0}ms", timeElapsed));
            }
            else
            {
                Logger.Debug(string.Format("Inside HtmlSelectExtension , option not available in {0}ms", timeElapsed));
            }                                               
        }

        public static void SelectByIndex(this HtmlSelect control, int index, int maxTimeout)
        {
           try
           {
               DateTime start;
               double timeElapsed = 0;

               start = DateTime.Now;

               while (control.Options.Count <= 1 && timeElapsed < maxTimeout)
               {
                   control.Refresh();
                   timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
               }

               if (control.Options.Count() >= 1)
               {
                   control.SelectByIndex(index, true);
                   Logger.Debug(string.Format("Inside HtmlSelectExtension , option available in {0}ms", timeElapsed));
               }
               else
               {
                   Logger.Debug(string.Format("Inside HtmlSelectExtension , option not available in {0}ms", timeElapsed));
               }
           }
           catch(InvalidOperationException e)
           {
               throw new GUIException(string.Format("InvalidOperationException exception, check if the items are within range :{0}", e.Message));
           }

           catch (ExecuteCommandException e)
           {
               throw new GUIException(string.Format("WebAii ExecuteCommand exception, check if the items are within range :{0}",e.Message));
           }            
        }
    }
}

using AuScGen.FunctionalTest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIAccess;
using UIAccess.WebControls;

namespace GoogleTestWithWebDriver
{
    class Program : TestBase
    {
        static void Main(string[] args)
        {
            //string guiMap = Directory.GetCurrentDirectory() + @"\Guimaps\DemoCalender.xml";
            //WebDriver.Browser.Maximize();
            //WebDriver.Browser.Navigate("http://jqueryui.com/resources/demos/datepicker/other-months.html");
            //WebEditBox editbox = WebDriver.WaitForControl<WebEditBox>(guiMap, "CalTextBox", 20000);
            //editbox.Click();
            //WebCalender calender = WebDriver.WaitForControl<WebCalender>(guiMap, "CalenderControl", 20000);
            ////Locator cal = calender.CalenderHeaderLocator;
            //Console.Write(calender.GetMonthAndYear.Text);

            SampleEDMC();
            
        }

        static void SampleEDMC()
        {
            string guiMap = Directory.GetCurrentDirectory() + @"\Guimaps\EDMCSample.xml";
            WebDriver.Browser.Maximize();
            WebDriver.Browser.Navigate("http://www.edmc.edu/");

            WebControl menu = WebDriver.WaitForControl<WebControl>(guiMap, "menu", 20000);
            var test = menu.GetChildren(new Locator(@"./li", WebDriverWrapper.LocatorType.Xpath),WebDriverWrapper.ControlType.Custom);
            test.FirstOrDefault().Click();

            test.Where(control => control.Text.Equals("About EDMC")).FirstOrDefault();

            WebControl aboutEDMC = WebDriver.WaitForControl<WebControl>(guiMap, "aboutEDMC", 20000);
            var aboutEDMCOptions = aboutEDMC.GetChildren(new Locator(@"./li", WebDriverWrapper.LocatorType.Xpath), WebDriverWrapper.ControlType.Custom);
            aboutEDMCOptions.FirstOrDefault().Click();

            var schoolsOptions = WebDriver.WaitForControl<WebControl>(guiMap, "options", 20000);
            var schools = schoolsOptions.GetChildren(new Locator(@"./li", WebDriverWrapper.LocatorType.Xpath), WebDriverWrapper.ControlType.Custom);
            schools.FirstOrDefault().Click();

            var image = WebDriver.WaitForControl<WebControl>(guiMap, "image", 20000);
            string imagesource = image.GetAttribute("src");

            if(imagesource.Contains("artinstitutes_logo.png"))
            {
                Console.WriteLine("Validtion Successful");
            }
            else
            {
                Console.WriteLine("Validtion Not Successful");
            }

            Console.Read();
            

            //List<WebControl> table = WebDriver.WaitForControl<WebTable>(guiMap, "sampleHtmlTable", 20000).GetRows.FirstOrDefault().GetChildren(new Locator() { ControlLocator="",LocatorType = WebD}, WebDriverWrapper.ControlType.WebCell);
        }


        static void SampleTable()
        {
            string guiMap = Directory.GetCurrentDirectory() + @"\Guimaps\GoogleTestMap.xml";
            WebDriver.Browser.Maximize();
            WebDriver.Browser.Navigate("http://www.w3schools.com/html/html_tables.asp");
                       
            ReadOnlyCollection<WebRow> table = WebDriver.WaitForControl<WebTable>(guiMap, "sampleHtmlTable", 20000).GetRows;
            table[3].DesktopMouseClick();
            

             //List<WebControl> table = WebDriver.WaitForControl<WebTable>(guiMap, "sampleHtmlTable", 20000).GetRows.FirstOrDefault().GetChildren(new Locator() { ControlLocator="",LocatorType = WebD}, WebDriverWrapper.ControlType.WebCell);
        }

        static void SampleBrowseTest()
        {
            string guiMap = Directory.GetCurrentDirectory() + @"\Guimaps\GoogleTestMap.xml";
            WebDriver.Browser.Maximize();
            WebDriver.Browser.Navigate("http://www.google.co.in");
            WebEditBox control = WebDriver.WaitForControl<WebEditBox>(guiMap, "txtSearchEditBox", 20000);

            control.Highlight();
            control.DesktopMouseClick();
            var test = control.GetAttributes()["role"];

            control.SendKeys("test");
            //control.Action.DragDrop(control.SeleniumControl);
            //WebDriver.WaitForControl<WebButton>(guiMap, "btnSearch", 20000).DesktopMouseClick();

            WebDriver.WaitForControl<WebCheckBox>(guiMap, "btnSearch", 20000).Check();            

            WebDriver.WaitForControl<WebButton>(guiMap, "btnSearch", 20000).Click();

            //WebRow row = WebDriver.WaitForControl<WebWebTable>(guiMap, "btnSearch", 20000).GetRowWithValue("");

        }
    }
}

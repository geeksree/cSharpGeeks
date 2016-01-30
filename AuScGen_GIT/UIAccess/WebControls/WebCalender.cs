using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebCalender : WebControl
    {
        private Browser browser;
        private Locator locator;

        public WebCalender(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.Calender)
        {
            browser = aBrowser;
            locator = aLocator;
        }

        private ICalender Calender
        {
            get
            {
                return (ICalender)Control;
            }
        }

        private Locator calenderHeader;
        public Locator CalenderHeaderLocator 
        { 
            get
            {
                if(null == calenderHeader)
                {
                    return new Locator(string.Format("{0}/div", locator), LocatorType.Xpath);
                }
                else
                {
                    return calenderHeader;
                }
               
            }
            set
            {
                calenderHeader = value;
            }
        }

        private Locator calenderMonthYear;
        public Locator CalenderMonthYearLocator
        {
            get
            {
                if (null == calenderMonthYear)
                {
                    return new Locator(string.Format("{0}/div", CalenderHeaderLocator), LocatorType.Xpath);
                }
                else
                {
                    return calenderMonthYear;
                }

            }
            set
            {
                calenderMonthYear = value;
            }
        }
                
        public WebControl CalenderHeader
        {
            get
            {
                return new WebControl(browser, locator);
            }
        }
                

        public WebControl GetMonthAndYear
        {
            get
            {
                return Utility.GetWebControlFromIContol(Calender.GetMonthAndYear(CalenderMonthYearLocator.ControlLocator, CalenderMonthYearLocator.LocatorType, CalenderHeaderLocator.ControlLocator, CalenderHeaderLocator.LocatorType), browser, locator, ControlType.Custom);
            }
        }

        //public WebControl NextMonth 
        //{ 
        //    get
        //    {
        //        return Utility.GetWebControlFromIContol(Calender.GetMonthAndYear,browser)
        //    }
        //}

        public WebControl GetCalenderHeader
        {
            get
            {
                return Utility.GetWebControlFromIContol(Calender.GetCalenderHeader(CalenderHeaderLocator.ControlLocator, CalenderHeaderLocator.LocatorType), browser, locator, ControlType.Custom);
            }
        }

        //public void NextMonth()
        //{
        //    GetButtons[1].Click();
        //}

        

    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using WebDriverWrapper.IControlHierarchy;
using System.Collections.ObjectModel;

namespace WebDriverWrapper
{
    public class SeleniumWebCombobox : SeleniumWebControls, ICombobox
    {
        internal SeleniumWebCombobox(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : base(aWebElement, aControlType, access)
        { }

        public ReadOnlyCollection<string> GetAllOptions()
        {
            SelectElement element = new SelectElement(aWebElement);
            IList<IWebElement> options = element.Options;
            List<string> optionsToReturn = new List<string>();

            foreach (IWebElement option in options)
            {
                optionsToReturn.Add(option.Text);
            }
            return optionsToReturn.AsReadOnly();

        }

        public void SelectByText(string textOption)
        {
            SelectElement element = new SelectElement(aWebElement);
            element.SelectByText(textOption);
        }

        public void SelectByIndex(int index)
        {
            SelectElement element = new SelectElement(aWebElement);
            element.SelectByIndex(index);
        }

        public void SelectByValue(string value)
        {
            SelectElement element = new SelectElement(aWebElement);
            element.SelectByValue(value);
        }

        public void DeselectAll()
        {
            SelectElement element = new SelectElement(aWebElement);
            element.DeselectAll();
        }

        public void DeselectByIndex(int index)
        {
            SelectElement element = new SelectElement(aWebElement);
            element.DeselectByIndex(index);
        }

        public void DeselectByText(string text)
        {
            SelectElement element = new SelectElement(aWebElement);
            element.DeselectByText(text);
        }

        public void DeselectByValue(string value)
        {
            SelectElement element = new SelectElement(aWebElement);
            element.DeselectByValue(value);
        }

        public void SelectByIndex(int index, int maxTimeout)
        {
            DateTime start;
            double timeElapsed = 0;
            SelectElement element = new SelectElement(aWebElement);


            start = DateTime.Now;

            while (element.Options.Count <= 1 && timeElapsed < maxTimeout)
            {
                timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
            }

            if (element.Options.Count() >= 1)
            {
                SelectByIndex(index);
                //Logger.Debug(string.Format("Inside HtmlSelectExtension , option available in {0}ms", timeElapsed));
            }
            else
            {
                //Logger.Debug(string.Format("Inside HtmlSelectExtension , option not available in {0}ms", timeElapsed));
            }
        }

        public void SelectByText(string text, int maxTimeout)
        {
            DateTime start;
            double timeElapsed = 0;
            SelectElement element = new SelectElement(aWebElement);

            start = DateTime.Now;

            try
            {
                while (element.Options.Where(option => option.Text.Equals(text)).Count() == 0 && timeElapsed < maxTimeout)
                {
                    timeElapsed = ((TimeSpan)(DateTime.Now - start)).TotalMilliseconds;
                    aControlAccess.IntializeControlAccess();
                    element = new SelectElement(aWebElement);
                }
            }
            catch (StaleElementReferenceException)
            {

            }

            if (element.Options.Where(option => option.Text.Equals(text)).Count() != 0)
            {
                SelectByText(text);
                //Logger.Debug(string.Format("Inside HtmlSelectExtension , option available in {0}ms", timeElapsed));
            }
            else
            {
                // Logger.Debug(string.Format("Inside HtmlSelectExtension , option not available in {0}ms", timeElapsed));
            }
        }

    }
}

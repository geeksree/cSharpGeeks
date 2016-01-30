using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace WebDriverWrapper
{
    public class Actions
    {
        internal IWebDriver WebDriver { get; set; }
        internal IWebElement WebElement { get; set; }
        private OpenQA.Selenium.Interactions.Actions SeleniumActions 
        {
            get
            {
                return new OpenQA.Selenium.Interactions.Actions(WebDriver);
            }             
        }

        public Actions( Browser browser, SeleniumWebControls control)
        {
            WebDriver = browser.BrowserHandle;
            WebElement = control.aWebElement;
        }

        public Actions(IWebDriver webdriver, IWebElement webElement)
        {
            WebDriver = webdriver;
            WebElement  = webElement;
        }

        public void MoveToElement(IControl WebElement)
        {
            SeleniumActions.MoveToElement(((SeleniumWebControls)WebElement).aWebElement).Build().Perform();
        }

        public void MoveToElement(int offSetX, int offSetY)
        {
            SeleniumActions.MoveToElement(WebElement, offSetX, offSetY).Build().Perform();
        }

        public void DragDrop(IControl target)
        {
            SeleniumActions.DragAndDrop(WebElement, ((SeleniumWebControls)target).aWebElement).Build().Perform();
        }

        public void DragDropToOffset(int offSetX, int offSetY)
        {
            SeleniumActions.DragAndDropToOffset(WebElement, offSetX, offSetY).Build().Perform();
        }

        public void NativeSelect(IControl WebElement)
        {
            SeleniumActions.MoveToElement(((SeleniumWebControls)WebElement).aWebElement).Click().Build().Perform();
        }

        public void SendKeys(string keys)
        {
            SeleniumActions.SendKeys(keys);

        }

        public void SendKeys(IControl WebElement, string keys)
        {
            SeleniumActions.SendKeys(((SeleniumWebControls)WebElement).aWebElement, keys);
        }
    }
}

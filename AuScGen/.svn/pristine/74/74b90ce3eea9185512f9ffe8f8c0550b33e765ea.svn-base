using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace WebDriverWrapper
{
    public class Utility
    {
        internal static IControl GetControlFromWebElement(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
        {
            if (aControlType == ControlType.Button)
            {
                return new SeleniumWebButton(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.EditBox)
            {
                return new SeleniumWebEditBox(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.Calender)
            {
                return new SeleniumWebCalender(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.Custom)
            {
                return new SeleniumWebControls(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.ComboBox)
            {
                return new SeleniumWebCombobox(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.CheckBox)
            {
                return new SeleniumWebCheckBox(aWebElement, aControlType,access);
            }

            if (aControlType == ControlType.Dialog)
            {
                return new SeleniumWebDialog(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.Frame)
            {
                return new SeleniumWebFrame(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.Image)
            {
                return new SeleniumWebImage(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.Label)
            {
                return new SeleniumWebLabel(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.Link)
            {
                return new SeleniumWebLink(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.ListBox)
            {
                return new SeleniumWebListBox(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.Page)
            {
                return new SeleniumWebPage(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.RadioButton)
            {
                return new SeleniumWebRadioButton(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.SpanArea)
            {
                return new SeleniumWebSpanArea(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.WebTable)
            {
                return new SeleniumWebTable(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.WebRow)
            {
                return new SeleniumWebRow(aWebElement, aControlType, access);
            }

            if (aControlType == ControlType.WebCell)
            {
                return new SeleniumWebCell(aWebElement, aControlType, access);
            }

            else return null;
        }

        internal static List<IControl> GetChildren(string Locator, LocatorType aLocatorType, ControlType aControlType, IWebElement aWebElement, ControlAccess access)
        {
            if (aLocatorType == LocatorType.Id)
            {
                return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.Id(Locator)), aControlType, access);
            }

            if (aLocatorType == LocatorType.Name)
            {
                return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.Name(Locator)), aControlType, access);
            }

            if (aLocatorType == LocatorType.TagName)
            {
                return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.TagName(Locator)), aControlType, access);
            }

            if (aLocatorType == LocatorType.Xpath)
            {
                return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.XPath(Locator)), aControlType, access);
            }

            if (aLocatorType == LocatorType.ClassName)
            {
                return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.ClassName(Locator)), aControlType, access);
            }

            if (aLocatorType == LocatorType.Css)
            {
                return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.CssSelector(Locator)), aControlType, access);
            }

            if (aLocatorType == LocatorType.LinkText)
            {
                return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.LinkText(Locator)), aControlType, access);
            }

            if (aLocatorType == LocatorType.PartialLinkText)
            {
                return Utility.GetControlsFromWebElements(aWebElement.FindElements(By.PartialLinkText(Locator)), aControlType, access);
            }

            else return null;
        }

        internal static List<IControl> GetControlsFromWebElements(IEnumerable<IWebElement> aWebElements, ControlType aControlType, ControlAccess access)
        {
            List<IControl> aControl = new List<IControl>();

            foreach (IWebElement aWebElement in aWebElements)
            {
                if (aControlType == ControlType.Button)
                {
                    aControl.Add(new SeleniumWebButton(aWebElement, aControlType,access));
                }

                if (aControlType == ControlType.EditBox)
                {
                    aControl.Add(new SeleniumWebEditBox(aWebElement, aControlType, access));
                }
                
                 if (aControlType == ControlType.Custom)
                {
                    aControl.Add(new SeleniumWebControls(aWebElement, aControlType, access));
                }

                 if (aControlType == ControlType.Calender)
                 {
                     aControl.Add(new SeleniumWebCalender(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.ComboBox)
                 {
                     aControl.Add(new SeleniumWebCombobox(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.CheckBox)
                 {
                     aControl.Add(new SeleniumWebCheckBox(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.Dialog)
                 {
                     aControl.Add(new SeleniumWebDialog(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.Frame)
                 {
                     aControl.Add(new SeleniumWebFrame(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.Image)
                 {
                     aControl.Add(new SeleniumWebImage(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.Label)
                 {
                     aControl.Add(new SeleniumWebLabel(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.Link)
                 {
                     aControl.Add(new SeleniumWebLink(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.ListBox)
                 {
                     aControl.Add(new SeleniumWebListBox(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.Page)
                 {
                     aControl.Add(new SeleniumWebPage(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.RadioButton)
                 {
                     aControl.Add(new SeleniumWebRadioButton(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.SpanArea)
                 {
                     aControl.Add(new SeleniumWebSpanArea(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.WebTable)
                 {
                     aControl.Add(new SeleniumWebTable(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.WebRow)
                 {
                     aControl.Add(new SeleniumWebRow(aWebElement, aControlType, access));
                 }

                 if (aControlType == ControlType.WebCell)
                 {
                     aControl.Add(new SeleniumWebCell(aWebElement, aControlType, access));
                 }

            }

            return aControl;
        }
        
    }
}

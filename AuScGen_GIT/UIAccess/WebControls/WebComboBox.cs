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
    public class WebComboBox : WebControl
    {
        public WebComboBox(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.ComboBox)
        { }

        private ICombobox ComboBox
        {
            get
            {
                return (ICombobox)Control;
            }
        }

        public ReadOnlyCollection<string> GetAllOptions()
        {
            return ComboBox.GetAllOptions();
        }

        public void SelectByText(string textOption)
        {
            ComboBox.SelectByText(textOption);
        }

        public void SelectByText(string textOption, int timeOut)
        {
            ComboBox.SelectByText(textOption, timeOut);
        }

        public void SelectByIndex(int index)
        {
            ComboBox.SelectByIndex(index);
        }

        public void SelectByIndex(int index, int timeOut)
        {
            ComboBox.SelectByIndex(index, timeOut);
        }

        public void SelectByValue(string value)
        {
            ComboBox.SelectByValue(value);
        }

        public void DeselectAll()
        {
            ComboBox.DeselectAll();
        }

        public void DeselectByIndex(int index)
        {
            ComboBox.DeselectByIndex(index);
        }

        public void DeselectByText(string text)
        {
            ComboBox.DeselectByText(text);
        }

        public void DeselectByValue(string value)
        {
            ComboBox.DeselectByValue(value);
        }

        public void NativeSelect(string text, string childrenXpath, int timeOut)
        {
            ComboBox.Click();

            var test = ComboBox.WaitForChildren(childrenXpath, timeOut);

            foreach (IControl option in ComboBox.WaitForChildren(childrenXpath, timeOut))
            {
                if (!option.Text.Equals(text))
                {
                    ComboBox.SendKeys(WebDriverWrapper.Keys.KeyDown);
                }
                else
                {
                    break;
                }
            }
            if (childrenXpath.Contains("optgroup"))
            {
                ComboBox.SendKeys(WebDriverWrapper.Keys.KeyDown);
                ComboBox.SendKeys(WebDriverWrapper.Keys.Enter);
            }
            else
            {
                ComboBox.SendKeys(WebDriverWrapper.Keys.Enter);
            }
        }
    }
}

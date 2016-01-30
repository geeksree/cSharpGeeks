using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper.IControlHierarchy
{
    public interface ICombobox : IControl
    {
        ReadOnlyCollection<string> GetAllOptions();
        void SelectByText(string option);
        void SelectByIndex(int index);
        void SelectByValue(string value);
        void DeselectAll();
        void DeselectByIndex(int index);
        void DeselectByText(string text);
        void DeselectByValue(string value);
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper.IControlHierarchy
{
    public interface IWebRow : IControl
    {
        ReadOnlyCollection<SeleniumWebCell> GetAllCells();
    }
}

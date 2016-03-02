using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverWrapper.IControlHierarchy
{
    public interface IEditBox : IControl
    {
        void JSSendKeys(string aText);
        void Clear();
    }
}

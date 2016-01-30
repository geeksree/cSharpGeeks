﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper.IControlHierarchy;

namespace WebDriverWrapper
{
    public class SeleniumWebCell : SeleniumWebControls, IWebCell
    {
        internal SeleniumWebCell(IWebElement aWebElement, ControlType aControlType, ControlAccess access)
            : base(aWebElement, aControlType, access)
        { }
       
    }
}

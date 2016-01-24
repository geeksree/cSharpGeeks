﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverWrapper;
using WebDriverWrapper.IControlHierarchy;

namespace UIAccess.WebControls
{
    public class WebImage : WebControl
    {
        public WebImage(Browser aBrowser, Locator aLocator)
            : base(aBrowser, aLocator.LocatorType, aLocator.ControlLocator, ControlType.Image)
        { }

        private IImage Image
        {
            get
            {
                return (IImage)Control;
            }
        }
    }
}

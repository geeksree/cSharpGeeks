using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

using Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.TestTemplates;
using ArtOfTest.WebAii.Controls;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Telerik.TestingFramework.Controls.KendoUI;

namespace AuScGen.TelerikPlugin
{
    [Export(typeof(IContainerPlugin))]
    public class TelerikPlugin : IContainerPlugin
    {
        private TelerikFramework telerikFramework;
        public TelerikFramework TelerikFramework 
        { 
            get
            {
                if (null == telerikFramework)
                {
                    telerikFramework = new TelerikFramework();
                }
                return telerikFramework;
            }
        }


        public string Description
        {
            get
            {
                return "Telerik Plugin";
            }
            set
            {
                Description = value;
            }
        }
    }
}

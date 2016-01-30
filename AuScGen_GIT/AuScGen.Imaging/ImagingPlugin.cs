using Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.Imaging
{
    [Export(typeof(IContainerPlugin))]
    class ImagingPlugin : IContainerPlugin
    {
        public ImageProcessor ImageProcessor 
        { 
            get
            {
                return new ImageProcessor();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

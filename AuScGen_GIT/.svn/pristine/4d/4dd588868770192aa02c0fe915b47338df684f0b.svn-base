using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuScGen.WhiteFramework.GUIMapParser
{
    class GlobalGuiCollection
    {
        private Dictionary<string, Dictionary<string, GuiMap>>
           globalGuimapCollection = new Dictionary<string, Dictionary<string, GuiMap>>();

        internal Dictionary<string, Dictionary<string, GuiMap>> GlobalGuimapCollection
        {
            get { return globalGuimapCollection; }
            set { globalGuimapCollection = value; }
        }

        /// <summary>
        /// The global collection
        /// </summary>
        private static GlobalGuiCollection globalCollection;

        /// <summary>
        /// Gets or sets the global collection.
        /// </summary>
        /// <value>
        /// The global collection.
        /// </value>
        public static GlobalGuiCollection GlobalCollection
        {
            get { return GlobalGuiCollection.globalCollection; }
            set { GlobalGuiCollection.globalCollection = value; }
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static GlobalGuiCollection getInstance()
        {
            if (null == globalCollection)
            {
                globalCollection = new GlobalGuiCollection();
                return globalCollection;
            }
            return globalCollection;
        }
    }
}

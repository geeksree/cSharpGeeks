using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class ContainerAccess
    {
        private ComponentContainer compContainer;

        private List<IContainerPlugin> Plugins
        {
            get
            {
                if (compContainer == null)
                {
                    compContainer = new ComponentContainer();                    
                }

                compContainer.AssembleComponents();
                return compContainer.GetObjects();
            }
        }

        public IContainerPlugin GetPlugin(string Description)
        {
            foreach (IContainerPlugin plugin in Plugins)
            {
                if (string.Equals(plugin.Description, Description))
                {
                    return plugin;
                }
            }

            return null;
        }

        public T GetPlugin<T>(string Description) where T : IContainerPlugin
        {
            foreach (IContainerPlugin plugin in Plugins)
            {
                if(plugin.GetType().Equals(typeof(T)))
                {
                    if (string.Equals(plugin.Description, Description))
                    {
                        return (T)plugin;
                    }                    
                }
            }

            return default(T);
        }

        public T GetPlugin<T>() where T : IContainerPlugin
        {
            foreach (IContainerPlugin plugin in Plugins)
            {
                if (plugin.GetType().Equals(typeof(T)))
                {
                    return (T)plugin;
                }
            }

            return default(T);
        }

        public void SetPluginDesc(string Desc, string NewDesc)
        {
            GetPlugin(Desc).Description = NewDesc;
        }
    }
}

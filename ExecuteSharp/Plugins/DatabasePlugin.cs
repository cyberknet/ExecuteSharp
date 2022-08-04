using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Plugins
{
    public abstract class DatabasePlugin
    {
        public abstract string Name { get; }
        public abstract string ShortName { get; }
        public abstract bool HasPluginConfiguration { get; }
        public abstract IPluginInstance GetInstance(string connectionString);
        public abstract IPluginConfiguration PluginConfiguration { get; set; }
        public abstract UserControl GetConnectControlInstance();
        public override string ToString() => Name;
        public abstract IPluginConfiguration DeserializeConfiguration(string configuration);
        public abstract string SerializeConfiguration();
    }
}

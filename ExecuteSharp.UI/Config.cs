using ExecuteSharp.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.UI
{
    public class Config
    {
        public string? LastConnectedPluginType { get; set; }
        public Dictionary<string, string> PluginConfigurations { get; set; } = new Dictionary<string, string>();
    }
}

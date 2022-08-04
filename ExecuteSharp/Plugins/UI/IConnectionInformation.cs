using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Plugins.UI
{
    public interface IConnectionInformation
    {
        string ConnectionString { get; }
        public bool IsValid { get; }
        event EventHandler<ValidationChangedEventArgs>? ValidationChanged;
        void LoadPluginConfiguration(IPluginConfiguration configuration);
        StringBuilder ValidationErrors { get; set; }
        IPluginConfiguration GetPluginConfiguration();
        void Revalidate();
    }
}

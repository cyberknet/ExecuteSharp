using ExecuteSharp.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle.Configuration
{
    public class OraclePluginConfiguration : IPluginConfiguration
    {
        public LdapSettings LdapSettings { get; set; } = new LdapSettings();
        public TnsnamesSettings TnsnamesSettings { get; set; } = new TnsnamesSettings();
        public List<OracleConnectionDetails> Recent { get; set; } = new List<OracleConnectionDetails>();
    }
}

using ExecuteSharp.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.SqlServer.Configuration
{
    public class SqlServerPluginConfiguration : IPluginConfiguration
    {
        public List<SqlServerConnectionDetails> Recent { get; set; } = new List<SqlServerConnectionDetails>();
    }
}

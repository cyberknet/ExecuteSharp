using Microsoft.Data.SqlClient;
using ExecuteSharp;
using ExecuteSharp.Plugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExecuteSharp.Databases.SqlServer.UI;
using ExecuteSharp.Databases.SqlServer.Configuration;

namespace ExecuteSharp.Databases.SqlServer
{
    public class SqlServerPlugin : DatabasePlugin
    {
        public override string Name { get => "SQL Server Database"; }
        public override string ShortName { get => "SQL"; }
        public override bool HasPluginConfiguration { get => false; }
        public override IPluginConfiguration PluginConfiguration { get; set; } = new SqlServerPluginConfiguration();

        public override UserControl GetConnectControlInstance()
        {
            return new SqlServerConnectControl();
        }

        public override IPluginInstance GetInstance(string connectionString)
        {
            return new SqlServerPluginInstance(this, connectionString);
        }

        public override IPluginConfiguration DeserializeConfiguration(string configuration)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(configuration))
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<SqlServerPluginConfiguration>(configuration);
                    if (result != null)
                        return result;
                }
            }
            catch (Exception) { } // no valid config to load
            return new SqlServerPluginConfiguration();
        }
        public override string SerializeConfiguration()
        {
            var jsonWriteOptions = new System.Text.Json.JsonSerializerOptions() { WriteIndented = false };
            if (PluginConfiguration is SqlServerPluginConfiguration config)
            {
                var newJson = System.Text.Json.JsonSerializer.Serialize(config, jsonWriteOptions);
                return newJson;
            }
            return "{}";
        }
    }
}

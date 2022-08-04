using ExecuteSharp;
using ExecuteSharp.Databases.Oracle.Configuration;
using ExecuteSharp.Databases.Oracle.UI;
using ExecuteSharp.Plugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle
{
    public class OraclePlugin : DatabasePlugin
    {
        public override string Name { get => "Oracle Database"; }
        public override string ShortName { get => "Oracle"; }
        public override bool HasPluginConfiguration { get => false; }
        public override IPluginConfiguration PluginConfiguration { get; set; } = new OraclePluginConfiguration();

        public override UserControl GetConnectControlInstance()
        {
            return new OracleConnectControl();
        }
        public override IPluginInstance GetInstance(string connectionString)
        {
            return new OraclePluginInstance(this, connectionString);
        }
        public override IPluginConfiguration DeserializeConfiguration(string configuration)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(configuration))
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<OraclePluginConfiguration>(configuration);
                    if (result != null)
                        return result;
                }
            }
            catch (Exception) { } // no valid config to load
            return new OraclePluginConfiguration();
        }
        public override string SerializeConfiguration()
        {
            var jsonWriteOptions = new System.Text.Json.JsonSerializerOptions() { WriteIndented = false };

            var newJson = System.Text.Json.JsonSerializer.Serialize(PluginConfiguration, jsonWriteOptions);
            return newJson;
        }
    }
}

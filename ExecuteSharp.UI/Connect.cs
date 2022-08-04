using ExecuteSharp.Plugins;
using ExecuteSharp.Plugins.UI;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExecuteSharp.UI
{
    public partial class Connect : Form
    {
        private Config Configuration { get; set; } = new Config();
        private UserControl? ConnectionControl { get; set; } = null;
        public IConnectionInformation? ConnectionInformation { get; set; } = null;
        private List<DatabasePlugin> DatabasePlugins { get; set; } = new();
        public DatabasePlugin? SelectedDatabasePlugin { get; set; } = null;
        public Connect()
        {
            InitializeComponent();
            Configuration = LoadConfiguration();
        }

        public void SetDatabasePlugins(params DatabasePlugin[] databasePlugins)
        {
            DatabasePlugins.Clear();
            PluginList.Items.Clear();
            DatabasePlugins.AddRange(databasePlugins);
            if (DatabasePlugins.Count > 0)
            {
                PluginList.Items.AddRange(DatabasePlugins.ToArray());
                for (int i = 0; i < PluginList.Items.Count; i++)
                {
                    var plugin = PluginList.Items[i];
                    if (plugin != null)
                    {
                        var pluginType = plugin.GetType();
                        if (pluginType != null)
                        {
                            string pluginTypeName = pluginType.FullName ?? string.Empty;
                            if (pluginTypeName == Configuration.LastConnectedPluginType)
                            {
                                PluginList.SelectedIndex = i;
                                break;
                            }
                        }
                    }
                }
            }

        }

        private void PluginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ConnectionControl != null)
            {
                ConnectionInfoGroupBox.Controls.Remove(ConnectionControl);
                ConnectionControl.Dispose();
            }

            if (PluginList.SelectedIndex >= 0)
            {
                var plugin = (DatabasePlugin)(PluginList.SelectedItem);
                if (plugin != null)
                {
                    ConnectionControl = plugin.GetConnectControlInstance();
                    if (ConnectionControl is IConnectionInformation connInfo)
                    {
                        ConnectionInformation = connInfo;
                        SelectedDatabasePlugin = plugin;
                        ConnectionControl.Dock = DockStyle.Fill;
                        ConnectionInfoGroupBox.Controls.Add(ConnectionControl);
                        ConnectionInformation.ValidationChanged += ConnectionInfo_ValidationChanged;
                        string config = LoadSerializedConfiguration(plugin);
                        var configuration = plugin.DeserializeConfiguration(config);
                        ConnectionInformation.LoadPluginConfiguration(configuration);
                        ConnectionInformation.Revalidate();
                    }
                }
            }
        }

        private void ConnectionInfo_ValidationChanged(object? sender, ValidationChangedEventArgs e)
        {
            OK.Enabled = e.IsValid;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if ((SelectedDatabasePlugin != null) && (ConnectionInformation != null))
            {
                if (!ConnectionInformation.IsValid)
                {
                    string messages = ConnectionInformation.ValidationErrors.ToString();
                    MessageBox.Show(this, messages, "Invalid Connection...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var config = ConnectionInformation.GetPluginConfiguration();
                    SelectedDatabasePlugin.PluginConfiguration = config;
                    string serializedConfiguration = SelectedDatabasePlugin.SerializeConfiguration();
                    Configuration.LastConnectedPluginType = SelectedDatabasePlugin.GetType().FullName;
                    SaveSerializedConfiguration(SelectedDatabasePlugin, serializedConfiguration);
                    DialogResult = DialogResult.OK;
                    Hide();
                }
            }
        }

        private Config LoadConfiguration()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            var configuration = config.Get<Config>();
            if (configuration != null)
                return configuration;
            else
            {
                configuration = new Config();
            }
            return new Config();
        }

        private string LoadSerializedConfiguration(DatabasePlugin plugin)
        {

            if (plugin != null)
            {
                var pluginType = plugin.GetType();
                if (pluginType != null && !string.IsNullOrEmpty(pluginType.FullName))
                {
                    return LoadSerializedConfiguration(pluginType.FullName);
                }
            }
            return string.Empty;
            //return "{\"RecentServers\":[\"FENTON\"],\"LastAuthenticationType\":0,\"Username\":\"\",\"Password\":\"\"}"; 
        }

        private string LoadSerializedConfiguration(string plugInFullName)
        {
            if (Configuration != null && Configuration.PluginConfigurations != null && !string.IsNullOrWhiteSpace(plugInFullName))
            {
                var pluginConfiguration = Configuration.PluginConfigurations;

                if (pluginConfiguration.TryGetValue(plugInFullName, out string? configValue))
                {
                    if (!string.IsNullOrWhiteSpace(configValue))
                        return configValue;
                }
            }
            return string.Empty;
        }

        private void SaveSerializedConfiguration(DatabasePlugin plugin, string serializedConfiguration)
        {
            var pluginType = plugin.GetType();
            if (pluginType != null && ! string.IsNullOrEmpty(pluginType.FullName))
            {
                Configuration.PluginConfigurations[pluginType.FullName] = serializedConfiguration;

                var jsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };
                var newJson = System.Text.Json.JsonSerializer.Serialize(Configuration, jsonSerializerOptions);
                var appSettingsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
                File.WriteAllText(appSettingsPath, newJson);
            }
        }
    }
}

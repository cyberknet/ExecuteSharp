using ExecuteSharp.Databases.Oracle.Configuration;
using ExecuteSharp.Plugins;
using ExecuteSharp.Plugins.UI;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExecuteSharp.Databases.Oracle.UI
{
    public partial class OracleConnectControl : UserControl, IConnectionInformation
    {
        protected OraclePluginConfiguration PluginConfiguration { get; set; } = new OraclePluginConfiguration();
       
        private OracleConnectionStringBuilder connectionStringBuilder = new OracleConnectionStringBuilder();
        public bool IsValid { get; protected set; }
        public StringBuilder ValidationErrors { get; set; } = new StringBuilder();
        public string ConnectionString { get; protected set; } = string.Empty;

        public event EventHandler<ValidationChangedEventArgs>? ValidationChanged;

        public OracleConnectControl()
        {
            InitializeComponent();
        }

        public IPluginConfiguration GetPluginConfiguration()
        {
            string password = string.Empty;

            if (RecentConnections.SelectedIndex <= 0)
            {
                OracleConnectionDetails? current = null;
                if (ResolutionTabControl.SelectedTab == TnsTabPage)
                    current = GetTnsOracleConnectionDetails();
                else if (ResolutionTabControl.SelectedTab == DirectTabPage)
                    current = GetDirectConnectionDetails();
                else if (ResolutionTabControl.SelectedTab == LdapTabPage)
                    current = GetLdapOracleConnectionDetails();
                if (current != null)
                    PluginConfiguration.Recent.Insert(0, current);
            }
            if (RecentConnections.SelectedIndex > 1)
            {
                var item = PluginConfiguration.Recent[RecentConnections.SelectedIndex - 1];
                if (PluginConfiguration.Recent.Remove(item))
                    PluginConfiguration.Recent.Insert(0, item);
            }

            return PluginConfiguration;
        }

        private OracleConnectionDetails GetDirectConnectionDetails()
        {

            string service = string.Empty;
            string sid = string.Empty;
            if (BySid.Checked)
                sid = ServiceSid.Text;
            else if (ByService.Checked)
                service = ServiceSid.Text;
            var ocd = new OracleConnectionDetails()
            {
                ResolutionMethod = ResolutionMethod.Direct,
                Hostname = Hostname.Text,
                Port = Port.Text,
                InstanceName = InstanceName.Text,
                Service = service,
                Sid = sid,
                Protocol = Protocol.SelectedItem.ToString()
            };
            return ocd;
        }
        private OracleConnectionDetails GetLdapOracleConnectionDetails()
        {
            var ocd = new OracleConnectionDetails()
            {
                ResolutionMethod = ResolutionMethod.Ldap,
                InstanceName = LdapDatabase.Text
            };
            return ocd;
        }

        private OracleConnectionDetails GetTnsOracleConnectionDetails()
        {
            var ocd = new OracleConnectionDetails()
            {
                ResolutionMethod = ResolutionMethod.Ldap,
                InstanceName = LdapDatabase.Text
            };
            return ocd;
        }

        public void LoadPluginConfiguration(IPluginConfiguration configuration)
        {
            if (configuration is OraclePluginConfiguration config)
            {

                PluginConfiguration = config;
            }
        }
        public void Revalidate()
        {
            EntryIsValid();
        }

        protected virtual void OnValidationChanged(ValidationChangedEventArgs e)
        {
            var handler = ValidationChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void EntryIsValid()
        {
            bool isValid = false;
            var messages = new StringBuilder();

            connectionStringBuilder.Clear();
            if (ResolutionTabControl.SelectedTab == TnsTabPage)
            {
                connectionStringBuilder.DataSource = LdapDatabase.Text;
            }
            else if (ResolutionTabControl.SelectedTab == DirectTabPage)
            {
                string dataSource = GetDirectConnectDataSource(ref isValid, messages);

                if (isValid)
                {
                    connectionStringBuilder.DataSource = dataSource;
                }
            }
            else if (ResolutionTabControl.SelectedTab == LdapTabPage)
            {
                connectionStringBuilder.DataSource = LdapDatabase.Text;
            }

            if (isValid)
            {
                connectionStringBuilder.UserID = Username.Text;
                connectionStringBuilder.Password = Password.Text;
                ConnectionString = connectionStringBuilder.ToString();
            }
            else
            {

            }
            

            OnValidationChanged(new ValidationChangedEventArgs { IsValid = isValid });
        }

        private string GetDirectConnectDataSource(ref bool isValid, StringBuilder messages)
        {
            string host = Hostname.Text;
            string port = Port.Text;
            string service_sid = string.Empty;
            string protocol = Protocol.SelectedItem?.ToString() ?? "TCP";
            string instance = string.Empty;
            int portNumber = 1521;

            if (string.IsNullOrEmpty(host))
            {
                isValid = false;
                messages.AppendLine("Hostname must be specified.");
            }
            if (string.IsNullOrEmpty(port))
            {
                isValid = false;
                messages.AppendLine("Port must be specified.");
            }
            else if (Int32.TryParse(Port.Text, out portNumber))
            {
                isValid = false;
                messages.AppendLine("Port must be a valid number.");
            }
            else if (portNumber < 1 || portNumber > 65535)
            {
                isValid = false;
                messages.AppendLine("Port must be a valid number between 1 and 65535.");
            }
            if (!ByService.Checked && !BySid.Checked)
            {
                isValid = false;
                messages.AppendLine("By Service or By SID must be selected.");
            }

            if (string.IsNullOrEmpty(ServiceSid.Text))
            {
                string field = BySid.Checked ? "SID" : "Sevice name";

                isValid = false;
                messages.AppendLine($"{field} must be specified.");
            }
            else
            {
                if (ByService.Checked)
                    service_sid = $"(SERVICE_NAME={ServiceSid.Text})";
                else if (BySid.Checked)
                    service_sid = $"(SID={ServiceSid.Text})";
            }

            if (!string.IsNullOrWhiteSpace(InstanceName.Text))
            {
                instance = $"(INSTANCE_NAME={InstanceName.Text})";
            }

            if (string.IsNullOrEmpty(instance) && string.IsNullOrEmpty(service_sid))
            {
                isValid = false;
                messages.AppendLine("Either SID, Service Name, or Instance must be specified");
            }
            string dataSource = $"(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL={protocol})(HOST={host})(PORT={portNumber})))(CONNECT_DATA=(SERVER=DEDICATED){service_sid}{instance}))";
            return dataSource;
        }

        private void ServerName_TextChanged(object sender, EventArgs e)
        {
            EntryIsValid();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            EntryIsValid();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            OracleConnectionSettings settings = new OracleConnectionSettings();
            settings.SetSettings(PluginConfiguration);
            var result = settings.ShowDialog(this);
            if (result == DialogResult.OK)
            {

            }
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            EntryIsValid();
        }
    }
}

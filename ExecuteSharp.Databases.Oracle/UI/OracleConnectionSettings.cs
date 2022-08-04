using ExecuteSharp.Databases.Oracle.Configuration;
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
    public partial class OracleConnectionSettings : Form
    {
        public OraclePluginConfiguration PluginConfiguration { get; set; } = new OraclePluginConfiguration();
        public OracleConnectionSettings()
        {
            InitializeComponent();
        }

        private void InitializeLdapSettings()
        {
            var ldapSettings = PluginConfiguration.LdapSettings;
            DefaultAdminContext.Text = ldapSettings.DefaultAdminContext;
            DirectoryServers.Text = ldapSettings.DirectoryServers;
            switch((ldapSettings.DirectoryServers ?? String.Empty).ToUpper().Trim())
            {
                case "OID":
                    DirectoryServerType.SelectedIndex = 1;
                    break;
                case "AD":
                    DirectoryServerType.SelectedIndex = 2;
                    break;
                default:
                    DirectoryServerType.SelectedIndex = 2;
                    break;
            }
            LdapTimeout.Value = ldapSettings.Timeout ?? -1;
            AuthenticateBind.Checked = ldapSettings.AuthenticateBind ?? false;
            AuthenticationWalletLocation.Text = ldapSettings.AuthenticationWalletLocation;
        }
        private void OK_Click(object sender, EventArgs e)
        {
            var isValid = true;
            StringBuilder messages = new StringBuilder();
            DialogResult = DialogResult.OK;
            if (AuthenticateBind.Checked)
            {
                if (string.IsNullOrWhiteSpace(AuthenticationWalletLocation.Text))
                {
                    isValid = false;
                    messages.AppendLine("Authentication wallet must be provided when Authenticate Bind is checked.");
                }
                else if (!File.Exists(AuthenticationWalletLocation.Text))
                {
                    isValid = false;
                    messages.AppendLine("Authentication wallet provided is not a readable file.");
                }

                if (!string.IsNullOrWhiteSpace(AuthenticationWalletLocation.Text) && !File.Exists(AuthenticationWalletLocation.Text))
                {
                    isValid = false;
                    messages.AppendLine("Location to TNSNames.ora provided is not a readable file.");
                }

            }
            if (isValid)
            {
                DialogResult = DialogResult.OK;
                PluginConfiguration.LdapSettings = GetLdapSettings();
                PluginConfiguration.TnsnamesSettings = GetTnsnamesSettings();
                Hide();
            }
            else
            {
                MessageBox.Show(this, messages.ToString(), "Selected values are not valid...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void SetSettings(OraclePluginConfiguration configuration)
        {
            PluginConfiguration = configuration;
            // load LDAP settings
            var ldapSettings = configuration.LdapSettings;
            var type = ldapSettings.DirectoryServerType ?? String.Empty;
            DefaultAdminContext.Text = ldapSettings.DefaultAdminContext ?? String.Empty;
            DirectoryServers.Text = ldapSettings.DirectoryServers ?? String.Empty;
            DirectoryServerType.SelectedIndex =  type.ToUpper().Trim() switch
            {
                "OID" => 1,
                "AD" => 2,
                _ => 0
            };
            LdapTimeout.Value = ldapSettings.Timeout ?? -1;
            AuthenticateBind.Checked = ldapSettings.AuthenticateBind ?? false;
            AuthenticationWalletLocation.Text = ldapSettings.AuthenticationWalletLocation ?? String.Empty;

            // load TNS settings
            var tnsnamesSettings = PluginConfiguration.TnsnamesSettings;
            TnsnamesLocation.Text = tnsnamesSettings.TnsnamesLocation ?? String.Empty;
        }

        private LdapSettings GetLdapSettings()
        {
            return new LdapSettings
            {
                DefaultAdminContext = GetNullableValue(DefaultAdminContext.Text),
                DirectoryServers = GetNullableValue(DirectoryServers.Text),
                DirectoryServerType = DirectoryServerType.SelectedIndex switch { 0 => null, 1 => "OID", 2=>"AD", _ => null},
                Timeout = LdapTimeout.Value != -1 ? (int)LdapTimeout.Value : null,
                AuthenticateBind = AuthenticateBind.Checked ? true : null,
                AuthenticationWalletLocation = GetNullableValue(AuthenticationWalletLocation.Text )
            };

        }

        private TnsnamesSettings GetTnsnamesSettings()
        {
            return new TnsnamesSettings { TnsnamesLocation = GetNullableValue(TnsnamesLocation.Text) };
        }

        private string? GetNullableValue(string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return null;
            return value;
        }
    }
}

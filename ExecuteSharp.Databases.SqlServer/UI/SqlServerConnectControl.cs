using ExecuteSharp.Databases.SqlServer.Configuration;
using ExecuteSharp.Plugins;
using ExecuteSharp.Plugins.UI;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExecuteSharp.Databases.SqlServer.UI
{
    public partial class SqlServerConnectControl : UserControl, IConnectionInformation
    {
        protected SqlServerPluginConfiguration? PluginConfiguration { get; set; }

        private SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
        public StringBuilder ValidationErrors { get; set; } = new StringBuilder();
        public bool IsValid { get; set; } = false;

        public string ConnectionString { get; protected set; } = string.Empty;

        public event EventHandler<ValidationChangedEventArgs>? ValidationChanged;

        public SqlServerConnectControl()
        {
            InitializeComponent();
            RecentConnections.SelectedIndex = 0;
            AuthenticationType.SelectedIndex = (int)SqlAuthenticationType.SqlServer;
        }

        public void LoadPluginConfiguration(IPluginConfiguration configuration)
        {
            if (configuration is SqlServerPluginConfiguration config)
            {
                PluginConfiguration = config;
                if (config.Recent != null)
                {
                    RecentConnections.Items.AddRange(config.Recent.ToArray());
                }
            }
        }
        public IPluginConfiguration GetPluginConfiguration()
        {
            string password = string.Empty;
            if (PluginConfiguration != null && RecentConnections.SelectedIndex <= 0)
            {
                SqlServerConnectionDetails? current = new SqlServerConnectionDetails();
                current.SqlAuthenticationType = (SqlAuthenticationType)AuthenticationType.SelectedIndex;
                current.Hostname = ServerName.Text;
                switch (AuthenticationType.SelectedIndex)
                {
                    case (int)SqlAuthenticationType.SqlServer:
                    case (int)SqlAuthenticationType.AzurePassword:
                        if (!string.IsNullOrWhiteSpace(Username.Text) && !string.IsNullOrWhiteSpace(Password.Text))
                        {
                            current.UserId = Username.Text;
                            current.Password = Password.Text;
                        }
                        break;
                    case (int)SqlAuthenticationType.AzureMFA:
                        if (!string.IsNullOrWhiteSpace(Username.Text))
                        {
                            current.UserId = Username.Text;
                        }
                        break;
                }
                if (current != null)
                {
                    bool found = false;
                    foreach (var recent in PluginConfiguration.Recent)
                    {
                        // if the hostname doesn't match, then it's not the same
                        if (recent.Hostname.ToLower().Trim() != current.Hostname.ToLower().Trim())
                            continue;
                        // if the authentication type doesn't match, then it's not the same
                        if (recent.SqlAuthenticationType != current.SqlAuthenticationType)
                            continue;
                        switch(current.SqlAuthenticationType)
                        {
                            // For SQL Server authentication
                            case SqlAuthenticationType.SqlServer:
                            case SqlAuthenticationType.AzurePassword:
                                // if the user id doesn't match, then it's not the same
                                if (current.UserId != recent.UserId)
                                    continue;
                                // if the password doesn't match, then update the password
                                // and treat it as if it was the same
                                if (current.Password != recent.Password)
                                    recent.Password = current.Password;
                                // mark as found, they are the same
                                found = true;
                                break;
                            // for Windows authentication
                            case SqlAuthenticationType.Windows:
                            case SqlAuthenticationType.AzureIntegrated:
                                // mark as found, they are the same
                                found = true;
                                break;
                            case SqlAuthenticationType.AzureMFA:
                                // if the user id doesn't match, then it's not the same
                                if (current.UserId != recent.UserId)
                                    continue;
                                // mark as found, they are the same
                                found = true;
                                break;
                        }
                        if (found)
                            break;
                    }
                    if (!found)
                        PluginConfiguration?.Recent.Insert(0, current);
                }
            }
            else if (RecentConnections.SelectedIndex > 1)
            {
                var item = PluginConfiguration?.Recent[RecentConnections.SelectedIndex - 1];
                if (PluginConfiguration != null && item != null)
                {
                    if (PluginConfiguration.Recent.Remove(item))
                        PluginConfiguration.Recent.Insert(0, item);
                }

            }


            return PluginConfiguration;
        }

        public void LoadRecentUsedSettings(string settings)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(settings))
                {
                    var result = System.Text.Json.JsonSerializer.Deserialize<SqlServerPluginConfiguration>(settings);
                    if (result != null && result.Recent != null)
                    {
                        RecentConnections.Items.Clear();
                        RecentConnections.Items.AddRange(result.Recent.ToArray());
                    }
                }
            }
            catch (Exception) { } // no valid config to load
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

            connectionStringBuilder.Clear();
            connectionStringBuilder.IntegratedSecurity = false;
            connectionStringBuilder.ApplicationName = "ExecuteSharp";
            connectionStringBuilder.MultipleActiveResultSets = true;
            ValidationErrors.Clear();
            if (String.IsNullOrWhiteSpace(ServerName.Text))
            {
                isValid = false;
                ValidationErrors.AppendLine("Server name must be specified.");
            }
            else
            {
                isValid = true;
                connectionStringBuilder.DataSource = ServerName.Text;
            }

            if (isValid)
            {
                switch (AuthenticationType.SelectedIndex)
                {
                    case (int)SqlAuthenticationType.Windows:
                        connectionStringBuilder.IntegratedSecurity = true;
                        isValid = true;
                        break;
                    case (int)SqlAuthenticationType.SqlServer:
                        if (!string.IsNullOrWhiteSpace(Username.Text) && !string.IsNullOrWhiteSpace(Password.Text))
                        {
                            connectionStringBuilder.Authentication = SqlAuthenticationMethod.SqlPassword;
                            connectionStringBuilder.UserID = Username.Text;
                            connectionStringBuilder.Password = Password.Text;
                            isValid = true;
                        }
                        else
                        {
                            ValidationErrors.AppendLine("Username and password must both be specified.");
                            isValid = false;
                        }
                        break;
                    case (int)SqlAuthenticationType.AzureMFA:
                        if (!string.IsNullOrWhiteSpace(Username.Text))
                        {
                            connectionStringBuilder.Authentication = SqlAuthenticationMethod.ActiveDirectoryInteractive;
                            connectionStringBuilder.UserID = Username.Text;
                            isValid = true;
                        }
                        else
                        {
                            ValidationErrors.AppendLine("Username must be specified.");
                            isValid = false;
                        }
                        break;
                    case (int)SqlAuthenticationType.AzurePassword:
                        if (!string.IsNullOrWhiteSpace(Username.Text) && !string.IsNullOrWhiteSpace(Password.Text))
                        {
                            connectionStringBuilder.Authentication = SqlAuthenticationMethod.ActiveDirectoryPassword;
                            connectionStringBuilder.UserID = Username.Text;
                            connectionStringBuilder.Password = Password.Text;
                            isValid = true;
                        }
                        else
                        {
                            ValidationErrors.AppendLine("Username and password must both be specified.");
                            isValid = false;
                        }
                        break;
                    case (int)SqlAuthenticationType.AzureIntegrated:
                        connectionStringBuilder.IntegratedSecurity = true;
                        connectionStringBuilder.Authentication = SqlAuthenticationMethod.ActiveDirectoryIntegrated;
                        break;
                }
                if (isValid)
                {
                    connectionStringBuilder.TrustServerCertificate = true;
                    ConnectionString = connectionStringBuilder.ToString();
                }
            }
            IsValid = isValid;
            OnValidationChanged(new ValidationChangedEventArgs { IsValid = isValid });
        }

        private void AuthenticationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool usernameVisible = false;
            bool passwordVisible = false;
            switch (AuthenticationType.SelectedIndex)
            {
                case (int)SqlAuthenticationType.SqlServer:
                    usernameVisible = true;
                    passwordVisible = true;
                    break;
                case (int)SqlAuthenticationType.AzureMFA:
                    usernameVisible = true;
                    break;
                case (int)SqlAuthenticationType.AzurePassword:
                    usernameVisible = true;
                    passwordVisible = true;
                    break;
            }
            UsernameLabel.Visible = usernameVisible;
            Username.Visible = usernameVisible;
            PasswordLabel.Visible = passwordVisible;
            Password.Visible = passwordVisible;
            RememberPassword.Visible = passwordVisible;
            EntryIsValid();
        }

        private void ServerName_TextChanged(object sender, EventArgs e)
        {
            EntryIsValid();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {
            EntryIsValid();
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            EntryIsValid();
        }

        private void RecentConnections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RecentConnections.SelectedItem is SqlServerConnectionDetails details)
            {
                ServerName.Text = details.Hostname;
                Username.Text = details.UserId;
                Password.Text = details.Password;
                AuthenticationType.SelectedIndex = (int)details.SqlAuthenticationType;
            }
            else
            {
                ServerName.Text = String.Empty;
                Username.Text = String.Empty;
                Password.Text = String.Empty;
                AuthenticationType.SelectedIndex = 0;
            }
        }
    }
}

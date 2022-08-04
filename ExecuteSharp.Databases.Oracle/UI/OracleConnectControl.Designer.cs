namespace ExecuteSharp.Databases.Oracle.UI
{
    partial class OracleConnectControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.RememberPassword = new System.Windows.Forms.CheckBox();
            this.ResolutionTabControl = new System.Windows.Forms.TabControl();
            this.TnsTabPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.TnsDatabase = new System.Windows.Forms.ComboBox();
            this.DirectTabPage = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.Protocol = new System.Windows.Forms.ComboBox();
            this.InstanceName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ServiceSid = new System.Windows.Forms.TextBox();
            this.BySid = new System.Windows.Forms.RadioButton();
            this.ByService = new System.Windows.Forms.RadioButton();
            this.Port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Hostname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LdapTabPage = new System.Windows.Forms.TabPage();
            this.LdapDatabase = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RecentConnections = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Settings = new System.Windows.Forms.Button();
            this.ResolutionTabControl.SuspendLayout();
            this.TnsTabPage.SuspendLayout();
            this.DirectTabPage.SuspendLayout();
            this.LdapTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(3, 34);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(86, 15);
            this.UsernameLabel.TabIndex = 3;
            this.UsernameLabel.Text = "User / Schema:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(3, 63);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(60, 15);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password:";
            // 
            // Username
            // 
            this.Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Username.Location = new System.Drawing.Point(98, 31);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(169, 23);
            this.Username.TabIndex = 5;
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.Location = new System.Drawing.Point(98, 60);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(169, 23);
            this.Password.TabIndex = 6;
            this.Password.UseSystemPasswordChar = true;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // RememberPassword
            // 
            this.RememberPassword.AutoSize = true;
            this.RememberPassword.Location = new System.Drawing.Point(98, 89);
            this.RememberPassword.Name = "RememberPassword";
            this.RememberPassword.Size = new System.Drawing.Size(137, 19);
            this.RememberPassword.TabIndex = 7;
            this.RememberPassword.Text = "Remember password";
            this.RememberPassword.UseVisualStyleBackColor = true;
            // 
            // ResolutionTabControl
            // 
            this.ResolutionTabControl.Controls.Add(this.TnsTabPage);
            this.ResolutionTabControl.Controls.Add(this.DirectTabPage);
            this.ResolutionTabControl.Controls.Add(this.LdapTabPage);
            this.ResolutionTabControl.Location = new System.Drawing.Point(3, 114);
            this.ResolutionTabControl.Name = "ResolutionTabControl";
            this.ResolutionTabControl.SelectedIndex = 0;
            this.ResolutionTabControl.Size = new System.Drawing.Size(267, 222);
            this.ResolutionTabControl.TabIndex = 9;
            // 
            // TnsTabPage
            // 
            this.TnsTabPage.Controls.Add(this.label2);
            this.TnsTabPage.Controls.Add(this.TnsDatabase);
            this.TnsTabPage.Location = new System.Drawing.Point(4, 24);
            this.TnsTabPage.Name = "TnsTabPage";
            this.TnsTabPage.Size = new System.Drawing.Size(259, 194);
            this.TnsTabPage.TabIndex = 2;
            this.TnsTabPage.Text = "TNS";
            this.TnsTabPage.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database:";
            // 
            // TnsDatabase
            // 
            this.TnsDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TnsDatabase.FormattingEnabled = true;
            this.TnsDatabase.Location = new System.Drawing.Point(6, 21);
            this.TnsDatabase.Name = "TnsDatabase";
            this.TnsDatabase.Size = new System.Drawing.Size(250, 23);
            this.TnsDatabase.TabIndex = 1;
            // 
            // DirectTabPage
            // 
            this.DirectTabPage.Controls.Add(this.label6);
            this.DirectTabPage.Controls.Add(this.Protocol);
            this.DirectTabPage.Controls.Add(this.InstanceName);
            this.DirectTabPage.Controls.Add(this.label5);
            this.DirectTabPage.Controls.Add(this.ServiceSid);
            this.DirectTabPage.Controls.Add(this.BySid);
            this.DirectTabPage.Controls.Add(this.ByService);
            this.DirectTabPage.Controls.Add(this.Port);
            this.DirectTabPage.Controls.Add(this.label4);
            this.DirectTabPage.Controls.Add(this.Hostname);
            this.DirectTabPage.Controls.Add(this.label3);
            this.DirectTabPage.Location = new System.Drawing.Point(4, 24);
            this.DirectTabPage.Name = "DirectTabPage";
            this.DirectTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DirectTabPage.Size = new System.Drawing.Size(259, 194);
            this.DirectTabPage.TabIndex = 0;
            this.DirectTabPage.Text = "Direct";
            this.DirectTabPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Protocol:";
            // 
            // Protocol
            // 
            this.Protocol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Protocol.FormattingEnabled = true;
            this.Protocol.Items.AddRange(new object[] {
            "TCP",
            "TCPS"});
            this.Protocol.Location = new System.Drawing.Point(6, 163);
            this.Protocol.Name = "Protocol";
            this.Protocol.Size = new System.Drawing.Size(247, 23);
            this.Protocol.TabIndex = 9;
            // 
            // InstanceName
            // 
            this.InstanceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InstanceName.Location = new System.Drawing.Point(6, 119);
            this.InstanceName.Name = "InstanceName";
            this.InstanceName.Size = new System.Drawing.Size(247, 23);
            this.InstanceName.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Instance Name:";
            // 
            // ServiceSid
            // 
            this.ServiceSid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiceSid.Location = new System.Drawing.Point(6, 75);
            this.ServiceSid.Name = "ServiceSid";
            this.ServiceSid.Size = new System.Drawing.Size(247, 23);
            this.ServiceSid.TabIndex = 6;
            // 
            // BySid
            // 
            this.BySid.AutoSize = true;
            this.BySid.Location = new System.Drawing.Point(109, 50);
            this.BySid.Name = "BySid";
            this.BySid.Size = new System.Drawing.Size(42, 19);
            this.BySid.TabIndex = 5;
            this.BySid.Text = "SID";
            this.BySid.UseVisualStyleBackColor = true;
            // 
            // ByService
            // 
            this.ByService.AutoSize = true;
            this.ByService.Checked = true;
            this.ByService.Location = new System.Drawing.Point(6, 50);
            this.ByService.Name = "ByService";
            this.ByService.Size = new System.Drawing.Size(97, 19);
            this.ByService.TabIndex = 4;
            this.ByService.TabStop = true;
            this.ByService.Text = "Service Name";
            this.ByService.UseVisualStyleBackColor = true;
            // 
            // Port
            // 
            this.Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Port.Location = new System.Drawing.Point(161, 21);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(92, 23);
            this.Port.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(161, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Port:";
            // 
            // Hostname
            // 
            this.Hostname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Hostname.Location = new System.Drawing.Point(6, 21);
            this.Hostname.Name = "Hostname";
            this.Hostname.Size = new System.Drawing.Size(149, 23);
            this.Hostname.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Host:";
            // 
            // LdapTabPage
            // 
            this.LdapTabPage.Controls.Add(this.LdapDatabase);
            this.LdapTabPage.Controls.Add(this.label7);
            this.LdapTabPage.Location = new System.Drawing.Point(4, 24);
            this.LdapTabPage.Name = "LdapTabPage";
            this.LdapTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LdapTabPage.Size = new System.Drawing.Size(259, 194);
            this.LdapTabPage.TabIndex = 1;
            this.LdapTabPage.Text = "LDAP";
            this.LdapTabPage.UseVisualStyleBackColor = true;
            // 
            // LdapDatabase
            // 
            this.LdapDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LdapDatabase.FormattingEnabled = true;
            this.LdapDatabase.Location = new System.Drawing.Point(6, 21);
            this.LdapDatabase.Name = "LdapDatabase";
            this.LdapDatabase.Size = new System.Drawing.Size(250, 23);
            this.LdapDatabase.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Database:";
            // 
            // RecentConnections
            // 
            this.RecentConnections.FormattingEnabled = true;
            this.RecentConnections.Items.AddRange(new object[] {
            "[New]"});
            this.RecentConnections.Location = new System.Drawing.Point(98, 3);
            this.RecentConnections.Name = "RecentConnections";
            this.RecentConnections.Size = new System.Drawing.Size(168, 23);
            this.RecentConnections.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Recent:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Settings
            // 
            this.Settings.Location = new System.Drawing.Point(7, 338);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(75, 23);
            this.Settings.TabIndex = 13;
            this.Settings.Text = "&Settings";
            this.Settings.UseVisualStyleBackColor = true;
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // OracleConnectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.RecentConnections);
            this.Controls.Add(this.ResolutionTabControl);
            this.Controls.Add(this.RememberPassword);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Name = "OracleConnectControl";
            this.Size = new System.Drawing.Size(270, 368);
            this.ResolutionTabControl.ResumeLayout(false);
            this.TnsTabPage.ResumeLayout(false);
            this.TnsTabPage.PerformLayout();
            this.DirectTabPage.ResumeLayout(false);
            this.DirectTabPage.PerformLayout();
            this.LdapTabPage.ResumeLayout(false);
            this.LdapTabPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label UsernameLabel;
        private Label PasswordLabel;
        private TextBox Username;
        private TextBox Password;
        private CheckBox RememberPassword;
        private TabControl ResolutionTabControl;
        private TabPage TnsTabPage;
        private ComboBox TnsDatabase;
        private TabPage DirectTabPage;
        private Label label6;
        private ComboBox Protocol;
        private TextBox InstanceName;
        private Label label5;
        private TextBox ServiceSid;
        private RadioButton BySid;
        private RadioButton ByService;
        private TextBox Port;
        private Label label4;
        private TextBox Hostname;
        private Label label3;
        private TabPage LdapTabPage;
        private ComboBox RecentConnections;
        private Label label11;
        private Label label7;
        private OpenFileDialog openFileDialog1;
        private Label label2;
        private ComboBox LdapDatabase;
        private Button Settings;
    }
}

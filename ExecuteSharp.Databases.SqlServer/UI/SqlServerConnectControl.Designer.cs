namespace ExecuteSharp.Databases.SqlServer.UI
{
    partial class SqlServerConnectControl
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
            this.ServerNameLabel = new System.Windows.Forms.Label();
            this.AuthenticationType = new System.Windows.Forms.ComboBox();
            this.AuthenticationLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.RememberPassword = new System.Windows.Forms.CheckBox();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.RecentConnections = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServerNameLabel
            // 
            this.ServerNameLabel.AutoSize = true;
            this.ServerNameLabel.Location = new System.Drawing.Point(3, 34);
            this.ServerNameLabel.Name = "ServerNameLabel";
            this.ServerNameLabel.Size = new System.Drawing.Size(75, 15);
            this.ServerNameLabel.TabIndex = 0;
            this.ServerNameLabel.Text = "Server name:";
            // 
            // AuthenticationType
            // 
            this.AuthenticationType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthenticationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AuthenticationType.FormattingEnabled = true;
            this.AuthenticationType.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication",
            "Azure Active Directory - Universal with MFA",
            "Azure Active Directory - Password",
            "Azure Active Directory - Integrated"});
            this.AuthenticationType.Location = new System.Drawing.Point(98, 58);
            this.AuthenticationType.Name = "AuthenticationType";
            this.AuthenticationType.Size = new System.Drawing.Size(169, 23);
            this.AuthenticationType.TabIndex = 1;
            this.AuthenticationType.SelectedIndexChanged += new System.EventHandler(this.AuthenticationType_SelectedIndexChanged);
            // 
            // AuthenticationLabel
            // 
            this.AuthenticationLabel.AutoSize = true;
            this.AuthenticationLabel.Location = new System.Drawing.Point(3, 61);
            this.AuthenticationLabel.Name = "AuthenticationLabel";
            this.AuthenticationLabel.Size = new System.Drawing.Size(89, 15);
            this.AuthenticationLabel.TabIndex = 2;
            this.AuthenticationLabel.Text = "Authentication:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(26, 90);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(66, 15);
            this.UsernameLabel.TabIndex = 3;
            this.UsernameLabel.Text = "User name:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(26, 119);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(60, 15);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password:";
            // 
            // Username
            // 
            this.Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Username.Location = new System.Drawing.Point(115, 87);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(152, 23);
            this.Username.TabIndex = 5;
            this.Username.TextChanged += new System.EventHandler(this.Username_TextChanged);
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.Location = new System.Drawing.Point(115, 116);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(152, 23);
            this.Password.TabIndex = 6;
            this.Password.UseSystemPasswordChar = true;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // RememberPassword
            // 
            this.RememberPassword.AutoSize = true;
            this.RememberPassword.Location = new System.Drawing.Point(115, 145);
            this.RememberPassword.Name = "RememberPassword";
            this.RememberPassword.Size = new System.Drawing.Size(137, 19);
            this.RememberPassword.TabIndex = 7;
            this.RememberPassword.Text = "Remember password";
            this.RememberPassword.UseVisualStyleBackColor = true;
            // 
            // ServerName
            // 
            this.ServerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerName.Location = new System.Drawing.Point(98, 32);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(169, 23);
            this.ServerName.TabIndex = 8;
            // 
            // RecentConnections
            // 
            this.RecentConnections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RecentConnections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RecentConnections.FormattingEnabled = true;
            this.RecentConnections.Items.AddRange(new object[] {
            "New..."});
            this.RecentConnections.Location = new System.Drawing.Point(98, 3);
            this.RecentConnections.Name = "RecentConnections";
            this.RecentConnections.Size = new System.Drawing.Size(169, 23);
            this.RecentConnections.TabIndex = 9;
            this.RecentConnections.SelectedIndexChanged += new System.EventHandler(this.RecentConnections_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Recent:";
            // 
            // SqlServerConnectControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RecentConnections);
            this.Controls.Add(this.ServerName);
            this.Controls.Add(this.RememberPassword);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.AuthenticationLabel);
            this.Controls.Add(this.AuthenticationType);
            this.Controls.Add(this.ServerNameLabel);
            this.Name = "SqlServerConnectControl";
            this.Size = new System.Drawing.Size(270, 165);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label ServerNameLabel;
        private ComboBox AuthenticationType;
        private Label AuthenticationLabel;
        private Label UsernameLabel;
        private Label PasswordLabel;
        private TextBox Username;
        private TextBox Password;
        private CheckBox RememberPassword;
        private TextBox ServerName;
        private ComboBox RecentConnections;
        private Label label1;
    }
}

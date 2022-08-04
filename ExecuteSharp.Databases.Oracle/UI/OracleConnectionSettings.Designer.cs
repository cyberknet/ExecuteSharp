namespace ExecuteSharp.Databases.Oracle.UI
{
    partial class OracleConnectionSettings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.LdapPage = new System.Windows.Forms.TabPage();
            this.TnsPage = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.TnsnamesLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowseWallet = new System.Windows.Forms.Button();
            this.AuthenticationWalletLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LdapTimeout = new System.Windows.Forms.NumericUpDown();
            this.AuthenticateBind = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.DirectoryServerType = new System.Windows.Forms.ComboBox();
            this.DirectoryServers = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.DefaultAdminContext = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.LdapPage.SuspendLayout();
            this.TnsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LdapTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(116, 306);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 28;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(197, 306);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 27;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TnsPage);
            this.tabControl1.Controls.Add(this.LdapPage);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(268, 292);
            this.tabControl1.TabIndex = 32;
            // 
            // LdapPage
            // 
            this.LdapPage.Controls.Add(this.BrowseWallet);
            this.LdapPage.Controls.Add(this.AuthenticationWalletLocation);
            this.LdapPage.Controls.Add(this.label1);
            this.LdapPage.Controls.Add(this.label10);
            this.LdapPage.Controls.Add(this.LdapTimeout);
            this.LdapPage.Controls.Add(this.AuthenticateBind);
            this.LdapPage.Controls.Add(this.label9);
            this.LdapPage.Controls.Add(this.DirectoryServerType);
            this.LdapPage.Controls.Add(this.DirectoryServers);
            this.LdapPage.Controls.Add(this.label8);
            this.LdapPage.Controls.Add(this.DefaultAdminContext);
            this.LdapPage.Controls.Add(this.label7);
            this.LdapPage.Location = new System.Drawing.Point(4, 24);
            this.LdapPage.Name = "LdapPage";
            this.LdapPage.Padding = new System.Windows.Forms.Padding(3);
            this.LdapPage.Size = new System.Drawing.Size(260, 264);
            this.LdapPage.TabIndex = 1;
            this.LdapPage.Text = "LDAP";
            this.LdapPage.UseVisualStyleBackColor = true;
            // 
            // TnsPage
            // 
            this.TnsPage.Controls.Add(this.button1);
            this.TnsPage.Controls.Add(this.TnsnamesLocation);
            this.TnsPage.Controls.Add(this.label2);
            this.TnsPage.Location = new System.Drawing.Point(4, 24);
            this.TnsPage.Name = "TnsPage";
            this.TnsPage.Padding = new System.Windows.Forms.Padding(3);
            this.TnsPage.Size = new System.Drawing.Size(260, 264);
            this.TnsPage.TabIndex = 0;
            this.TnsPage.Text = "TNS";
            this.TnsPage.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 50);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Browse..";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TnsnamesLocation
            // 
            this.TnsnamesLocation.Location = new System.Drawing.Point(6, 21);
            this.TnsnamesLocation.Name = "TnsnamesLocation";
            this.TnsnamesLocation.Size = new System.Drawing.Size(247, 23);
            this.TnsnamesLocation.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 15);
            this.label2.TabIndex = 47;
            this.label2.Text = "Tnsnames.ora Location:";
            // 
            // BrowseWallet
            // 
            this.BrowseWallet.Location = new System.Drawing.Point(179, 237);
            this.BrowseWallet.Name = "BrowseWallet";
            this.BrowseWallet.Size = new System.Drawing.Size(75, 23);
            this.BrowseWallet.TabIndex = 67;
            this.BrowseWallet.Text = "Browse..";
            this.BrowseWallet.UseVisualStyleBackColor = true;
            // 
            // AuthenticationWalletLocation
            // 
            this.AuthenticationWalletLocation.Location = new System.Drawing.Point(7, 208);
            this.AuthenticationWalletLocation.Name = "AuthenticationWalletLocation";
            this.AuthenticationWalletLocation.Size = new System.Drawing.Size(247, 23);
            this.AuthenticationWalletLocation.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 15);
            this.label1.TabIndex = 65;
            this.label1.Text = "Authentication Wallet Location:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 141);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 15);
            this.label10.TabIndex = 64;
            this.label10.Text = "Timeout (s):";
            // 
            // LdapTimeout
            // 
            this.LdapTimeout.Location = new System.Drawing.Point(83, 139);
            this.LdapTimeout.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.LdapTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.LdapTimeout.Name = "LdapTimeout";
            this.LdapTimeout.Size = new System.Drawing.Size(171, 23);
            this.LdapTimeout.TabIndex = 63;
            // 
            // AuthenticateBind
            // 
            this.AuthenticateBind.AutoSize = true;
            this.AuthenticateBind.Location = new System.Drawing.Point(7, 168);
            this.AuthenticateBind.Name = "AuthenticateBind";
            this.AuthenticateBind.Size = new System.Drawing.Size(121, 19);
            this.AuthenticateBind.TabIndex = 62;
            this.AuthenticateBind.Text = "Authenticate Bind";
            this.AuthenticateBind.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 15);
            this.label9.TabIndex = 61;
            this.label9.Text = "Directory Server Type:";
            // 
            // DirectoryServerType
            // 
            this.DirectoryServerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DirectoryServerType.FormattingEnabled = true;
            this.DirectoryServerType.Items.AddRange(new object[] {
            "None",
            "Oracle Internet Directory (OID)",
            "Active Directory (AD)"});
            this.DirectoryServerType.Location = new System.Drawing.Point(7, 110);
            this.DirectoryServerType.Name = "DirectoryServerType";
            this.DirectoryServerType.Size = new System.Drawing.Size(247, 23);
            this.DirectoryServerType.TabIndex = 60;
            // 
            // DirectoryServers
            // 
            this.DirectoryServers.Location = new System.Drawing.Point(7, 66);
            this.DirectoryServers.Name = "DirectoryServers";
            this.DirectoryServers.Size = new System.Drawing.Size(247, 23);
            this.DirectoryServers.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 15);
            this.label8.TabIndex = 58;
            this.label8.Text = "Directory Servers:";
            // 
            // DefaultAdminContext
            // 
            this.DefaultAdminContext.Location = new System.Drawing.Point(7, 22);
            this.DefaultAdminContext.Name = "DefaultAdminContext";
            this.DefaultAdminContext.Size = new System.Drawing.Size(247, 23);
            this.DefaultAdminContext.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 15);
            this.label7.TabIndex = 56;
            this.label7.Text = "Default Admin Context:";
            // 
            // OracleConnectionSettings
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel;
            this.ClientSize = new System.Drawing.Size(283, 337);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OracleConnectionSettings";
            this.Text = "Oracle Connection Settings";
            this.tabControl1.ResumeLayout(false);
            this.LdapPage.ResumeLayout(false);
            this.LdapPage.PerformLayout();
            this.TnsPage.ResumeLayout(false);
            this.TnsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LdapTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button OK;
        private Button Cancel;
        private TabControl tabControl1;
        private TabPage TnsPage;
        private Button button1;
        private TextBox TnsnamesLocation;
        private Label label2;
        private TabPage LdapPage;
        private Button BrowseWallet;
        private TextBox AuthenticationWalletLocation;
        private Label label1;
        private Label label10;
        private NumericUpDown LdapTimeout;
        private CheckBox AuthenticateBind;
        private Label label9;
        private ComboBox DirectoryServerType;
        private TextBox DirectoryServers;
        private Label label8;
        private TextBox DefaultAdminContext;
        private Label label7;
    }
}
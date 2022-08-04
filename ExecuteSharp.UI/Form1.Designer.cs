namespace ExecuteSharp.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.PluginTabControl = new System.Windows.Forms.TabControl();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.Execute = new System.Windows.Forms.ToolStripButton();
            this.Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Commit = new System.Windows.Forms.ToolStripButton();
            this.Rollback = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NewInstance = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.NewQuery = new System.Windows.Forms.ToolStripButton();
            this.NewBrowser = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1027, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.PluginTabControl);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1027, 523);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1027, 548);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // PluginTabControl
            // 
            this.PluginTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PluginTabControl.Location = new System.Drawing.Point(0, 0);
            this.PluginTabControl.Name = "PluginTabControl";
            this.PluginTabControl.SelectedIndex = 0;
            this.PluginTabControl.Size = new System.Drawing.Size(1027, 523);
            this.PluginTabControl.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewInstance,
            this.toolStripSeparator3,
            this.Execute,
            this.Stop,
            this.toolStripSeparator1,
            this.Commit,
            this.Rollback,
            this.toolStripSeparator2,
            this.NewQuery,
            this.NewBrowser});
            this.toolStrip2.Location = new System.Drawing.Point(3, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(191, 25);
            this.toolStrip2.TabIndex = 6;
            // 
            // Execute
            // 
            this.Execute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Execute.Enabled = false;
            this.Execute.Image = global::ExecuteSharp.UI.Properties.Resources.icons8_play_16;
            this.Execute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(23, 22);
            this.Execute.Text = "toolStripButton1";
            // 
            // Stop
            // 
            this.Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Stop.Enabled = false;
            this.Stop.Image = global::ExecuteSharp.UI.Properties.Resources.icons8_stop_16;
            this.Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(23, 22);
            this.Stop.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Commit
            // 
            this.Commit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Commit.Enabled = false;
            this.Commit.Image = global::ExecuteSharp.UI.Properties.Resources.icons8_done_16;
            this.Commit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Commit.Name = "Commit";
            this.Commit.Size = new System.Drawing.Size(23, 22);
            this.Commit.Text = "toolStripButton3";
            // 
            // Rollback
            // 
            this.Rollback.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Rollback.Enabled = false;
            this.Rollback.Image = global::ExecuteSharp.UI.Properties.Resources.icons8_undo_16;
            this.Rollback.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Rollback.Name = "Rollback";
            this.Rollback.Size = new System.Drawing.Size(23, 22);
            this.Rollback.Text = "toolStripButton4";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NewInstance
            // 
            this.NewInstance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewInstance.Enabled = false;
            this.NewInstance.Image = global::ExecuteSharp.UI.Properties.Resources.icons8_connected_16;
            this.NewInstance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewInstance.Name = "NewInstance";
            this.NewInstance.Size = new System.Drawing.Size(23, 22);
            this.NewInstance.Text = "Create Instance";
            this.NewInstance.Click += new System.EventHandler(this.NewInstance_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // NewQuery
            // 
            this.NewQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewQuery.Enabled = false;
            this.NewQuery.Image = global::ExecuteSharp.UI.Properties.Resources.icons8_search_database_16;
            this.NewQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewQuery.Name = "NewQuery";
            this.NewQuery.Size = new System.Drawing.Size(23, 22);
            this.NewQuery.Text = "New Query";
            this.NewQuery.Click += new System.EventHandler(this.NewQueryButton_Click);
            // 
            // NewBrowser
            // 
            this.NewBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewBrowser.Enabled = false;
            this.NewBrowser.Image = global::ExecuteSharp.UI.Properties.Resources.icons8_add_node_16;
            this.NewBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewBrowser.Name = "NewBrowser";
            this.NewBrowser.Size = new System.Drawing.Size(23, 22);
            this.NewBrowser.Text = "New Browser";
            this.NewBrowser.Click += new System.EventHandler(this.NewBrowserButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 572);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ExecuteSharp";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripContainer toolStripContainer1;
        private TabControl PluginTabControl;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStrip toolStrip2;
        private ToolStripButton Execute;
        private ToolStripButton Stop;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton Commit;
        private ToolStripButton Rollback;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton NewInstance;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton NewQuery;
        private ToolStripButton NewBrowser;
    }
}
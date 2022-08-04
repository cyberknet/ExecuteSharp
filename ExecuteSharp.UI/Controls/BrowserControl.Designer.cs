namespace ExecuteSharp.UI.Controls
{
    partial class BrowserControl
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
            this.ExplorerTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.browserSplit = new System.Windows.Forms.SplitContainer();
            this.ExplorerTree = new System.Windows.Forms.TreeView();
            this.ExplorerTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.browserSplit)).BeginInit();
            this.browserSplit.Panel1.SuspendLayout();
            this.browserSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExplorerTabs
            // 
            this.ExplorerTabs.Controls.Add(this.tabPage1);
            this.ExplorerTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExplorerTabs.Location = new System.Drawing.Point(0, 0);
            this.ExplorerTabs.Name = "ExplorerTabs";
            this.ExplorerTabs.SelectedIndex = 0;
            this.ExplorerTabs.ShowToolTips = true;
            this.ExplorerTabs.Size = new System.Drawing.Size(473, 355);
            this.ExplorerTabs.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.browserSplit);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(465, 327);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Explorer";
            this.tabPage1.ToolTipText = "Browser (FENTON)";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // browserSplit
            // 
            this.browserSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserSplit.Location = new System.Drawing.Point(3, 3);
            this.browserSplit.Name = "browserSplit";
            // 
            // browserSplit.Panel1
            // 
            this.browserSplit.Panel1.Controls.Add(this.ExplorerTree);
            this.browserSplit.Size = new System.Drawing.Size(459, 321);
            this.browserSplit.SplitterDistance = 153;
            this.browserSplit.TabIndex = 1;
            // 
            // ExplorerTree
            // 
            this.ExplorerTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExplorerTree.Location = new System.Drawing.Point(0, 0);
            this.ExplorerTree.Name = "ExplorerTree";
            this.ExplorerTree.Size = new System.Drawing.Size(153, 321);
            this.ExplorerTree.TabIndex = 0;
            // 
            // BrowserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ExplorerTabs);
            this.Name = "BrowserControl";
            this.Size = new System.Drawing.Size(473, 355);
            this.ExplorerTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.browserSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.browserSplit)).EndInit();
            this.browserSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl ExplorerTabs;
        private TabPage tabPage1;
        private SplitContainer browserSplit;
        private TreeView ExplorerTree;
    }
}

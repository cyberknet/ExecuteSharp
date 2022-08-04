namespace ExecuteSharp.UI.Controls
{
    partial class PluginInstanceView
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
            this.PluginInstanceTabs = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // PluginInstanceTabs
            // 
            this.PluginInstanceTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PluginInstanceTabs.Location = new System.Drawing.Point(0, 0);
            this.PluginInstanceTabs.Name = "PluginInstanceTabs";
            this.PluginInstanceTabs.SelectedIndex = 0;
            this.PluginInstanceTabs.ShowToolTips = true;
            this.PluginInstanceTabs.Size = new System.Drawing.Size(684, 398);
            this.PluginInstanceTabs.TabIndex = 3;
            this.PluginInstanceTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.PluginInstanceTabs_Selected);
            // 
            // PluginInstanceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PluginInstanceTabs);
            this.Name = "PluginInstanceView";
            this.Size = new System.Drawing.Size(684, 398);
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl PluginInstanceTabs;
    }
}

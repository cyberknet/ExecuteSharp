namespace ExecuteSharp.UI.Controls
{
    partial class QueryControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.QueryText = new System.Windows.Forms.TextBox();
            this.ResultsTabControl = new System.Windows.Forms.TabControl();
            this.ResultsPage = new System.Windows.Forms.TabPage();
            this.MessagesPage = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ResultsTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.QueryText);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ResultsTabControl);
            this.splitContainer1.Size = new System.Drawing.Size(782, 337);
            this.splitContainer1.SplitterDistance = 182;
            this.splitContainer1.TabIndex = 0;
            // 
            // QueryText
            // 
            this.QueryText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QueryText.Location = new System.Drawing.Point(0, 0);
            this.QueryText.Multiline = true;
            this.QueryText.Name = "QueryText";
            this.QueryText.Size = new System.Drawing.Size(782, 182);
            this.QueryText.TabIndex = 0;
            // 
            // ResultsTabControl
            // 
            this.ResultsTabControl.Controls.Add(this.ResultsPage);
            this.ResultsTabControl.Controls.Add(this.MessagesPage);
            this.ResultsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsTabControl.Location = new System.Drawing.Point(0, 0);
            this.ResultsTabControl.Name = "ResultsTabControl";
            this.ResultsTabControl.SelectedIndex = 0;
            this.ResultsTabControl.Size = new System.Drawing.Size(782, 151);
            this.ResultsTabControl.TabIndex = 0;
            // 
            // ResultsPage
            // 
            this.ResultsPage.Location = new System.Drawing.Point(4, 24);
            this.ResultsPage.Name = "ResultsPage";
            this.ResultsPage.Padding = new System.Windows.Forms.Padding(3);
            this.ResultsPage.Size = new System.Drawing.Size(774, 123);
            this.ResultsPage.TabIndex = 0;
            this.ResultsPage.Text = "Results";
            this.ResultsPage.UseVisualStyleBackColor = true;
            // 
            // MessagesPage
            // 
            this.MessagesPage.Location = new System.Drawing.Point(4, 24);
            this.MessagesPage.Name = "MessagesPage";
            this.MessagesPage.Padding = new System.Windows.Forms.Padding(3);
            this.MessagesPage.Size = new System.Drawing.Size(774, 123);
            this.MessagesPage.TabIndex = 1;
            this.MessagesPage.Text = "Messages";
            this.MessagesPage.UseVisualStyleBackColor = true;
            // 
            // QueryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "QueryControl";
            this.Size = new System.Drawing.Size(782, 337);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResultsTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private TabControl ResultsTabControl;
        private TabPage ResultsPage;
        private TabPage MessagesPage;
        private TextBox QueryText;
    }
}

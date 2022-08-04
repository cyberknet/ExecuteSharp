using ExecuteSharp.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExecuteSharp.UI.Controls
{
    public partial class QueryControl : UserControl
    {
        IPluginInstance? _pluginInstance = null;
        public QueryControl()
        {
            InitializeComponent();
        }

        public void SetPluginInstance(IPluginInstance pluginInstance)
        {
            _pluginInstance = pluginInstance;
        }

        private void ExecuteQueryButton_Click(object sender, EventArgs e)
        {
            
        }

        internal void SetTextboxFocus()
        {
            QueryText.Focus();
        }
    }
}

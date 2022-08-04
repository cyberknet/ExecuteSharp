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
    public partial class PluginInstanceView : UserControl
    {
        public IPluginInstance? PluginInstance { get; private set; }

        private int newQueryNumber = 0;

        private Query? _query = null;

        public PluginInstanceView()
        {
            InitializeComponent();
        }

        public void SetPluginInstance(IPluginInstance pluginInstance)
        {
            PluginInstance = pluginInstance;
            _query = PluginInstance.GetQuery(TimeSpan.Zero);
        }

        public void AddNewQueryPage()
        {
            if (PluginInstance != null)
            {
                newQueryNumber += 1;
                TabPage page = new TabPage($"Query {newQueryNumber}");
                QueryControl query = new QueryControl();
                query.SetPluginInstance(PluginInstance);
                query.Dock = DockStyle.Fill;
                page.Controls.Add(query);
                PluginInstanceTabs.TabPages.Add(page);
                PluginInstanceTabs.SelectedTab = page;
                OnInterfaceActive(true);
                query.SetTextboxFocus();

            }
        }

        public void AddNewExplorerPage()
        {
            if (PluginInstance != null)
            {
                TabPage page = new TabPage("Browse");
                BrowserControl browser = new BrowserControl();
                browser.SetPluginInstance(PluginInstance);
                browser.Dock = DockStyle.Fill;
                page.Controls.Add(browser);
                PluginInstanceTabs.TabPages.Add(page);
                PluginInstanceTabs.SelectedTab = page;
                browser.SetTreeViewFocus();
            }
        }

        private void PluginInstanceTabs_Selected(object sender, TabControlEventArgs e)
        {
            var control = e.TabPage.Controls[0];
            bool isQueryActive = false;
            if (control is QueryControl queryControl)
            {
                isQueryActive = true;
            }
            OnInterfaceActive(isQueryActive);
            
        }


        public event EventHandler<InterfaceActiveEventArgs> InterfaceActive;

        private void OnInterfaceActive(bool isQueryActive)
        {
            var handler = InterfaceActive;
            if (handler != null)
                handler(this, new InterfaceActiveEventArgs(isQueryActive));
        }

    }

    
}

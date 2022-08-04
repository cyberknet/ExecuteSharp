using ExecuteSharp.Plugins;
using ExecuteSharp.UI.Controls;

namespace ExecuteSharp.UI
{
    public partial class Form1 : Form
    {
        DatabasePluginManager? databasePluginManager = null;
        IPluginInstance? _activePluginInstance = null;
        public Form1()
        {
            InitializeComponent();
            LoadDatabasePlugins();

        }

        private void LoadDatabasePlugins()
        {
            var assemblyFile = System.Reflection.Assembly.GetExecutingAssembly().Location;
            if (assemblyFile != null)
            {
                string? appDirectory = Path.GetDirectoryName(assemblyFile);
                if (appDirectory != null)
                {
                    string pluginDirectory =
                        Path.Combine(
                            appDirectory,
                            "Plugins");
                    databasePluginManager = new DatabasePluginManager(pluginDirectory);
                    databasePluginManager.LoadDatabasePlugins();
                    NewInstance.Enabled = databasePluginManager.DatabasePlugins.Count > 0;
                    //var plugin = new ExecuteSharp.Databases.SqlServer.SqlServerPlugin();
                    //databasePluginManager.DatabasePlugins.Add((IDatabasePlugin)plugin);
                    //databasePluginManager.DatabasePlugins.Add(new ExecuteSharp.Databases.Oracle.OracleServerPlugin());
                }
            }
        }

        

        private void sqlServerDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void NewInstance_Click(object sender, EventArgs e)
        {
            using var connect = new Connect();
            if (databasePluginManager != null)
            {
                connect.SetDatabasePlugins(databasePluginManager.DatabasePlugins.ToArray());
                var result = connect.ShowDialog(this);
                if (result != DialogResult.Cancel && connect.SelectedDatabasePlugin != null && connect.ConnectionInformation != null)
                {
                    var connectionString = connect.ConnectionInformation.ConnectionString;
                    if (!string.IsNullOrWhiteSpace(connectionString))
                    {
                        CreatePluginInstance(connect.SelectedDatabasePlugin, connectionString);
                    }
                }
            }
        }

        private void CreatePluginInstance(DatabasePlugin pluginType, string connectionString)
        {
            var instance = pluginType.GetInstance(connectionString);
            var pluginInstanceView = new PluginInstanceView();
            pluginInstanceView.SetPluginInstance(instance);

            TabPage tabPage = new TabPage();
            tabPage.Text = $"{instance.DatabasePlugin.ShortName}";
            tabPage.Controls.Add(pluginInstanceView);
            pluginInstanceView.Dock = DockStyle.Fill;
            this.PluginTabControl.TabPages.Add(tabPage);
            PluginTabControl.SelectedTab = tabPage;
            NewQuery.Enabled = true;
            NewBrowser.Enabled = true;
            _activePluginInstance = instance;
            pluginInstanceView.InterfaceActive += PluginInstanceView_InterfaceActive;

            NewQueryButton_Click(this, EventArgs.Empty);
        }

        private void PluginInstanceView_InterfaceActive(object? sender, InterfaceActiveEventArgs e)
        {
            bool queryActive = e.IsQueryActive;
            Commit.Enabled = queryActive;
            Rollback.Enabled = queryActive;
            Execute.Enabled = queryActive;
            Stop.Enabled = queryActive;
        }

        private void NewQueryButton_Click(object sender, EventArgs e)
        {
            if (_activePluginInstance != null)
            {
                if (PluginTabControl.SelectedTab.Controls[0] is PluginInstanceView view)
                {
                    view.AddNewQueryPage();
                }
            }
        }

        private void NewBrowserButton_Click(object sender, EventArgs e)
        {
            if (_activePluginInstance != null)
            {
                if (PluginTabControl.SelectedTab.Controls[0] is PluginInstanceView view)
                view.AddNewExplorerPage();
            }
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new About();
            aboutBox.ShowDialog(this);
        }
    }
}
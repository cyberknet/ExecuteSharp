using ExecuteSharp.Metadata;
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
    public partial class BrowserControl : UserControl
    {
        private IPluginInstance? _pluginInstance { get; set; }

        private TreeNode? CatalogNode;

        private object NODE_PLACEHOLDER = new object();
        private object NODE_SCHEMAS = new object();
        private object NODE_TABLES = new object();
        private object NODE_VIEWS = new object();
        private object NODE_PROGRAMMABILITY = new object();
        private object NODE_STOREDPROCEDURES = new object();
        private object NODE_SYNONYMS = new object();

        private MetadataExplorer? _metadataExplorer = null;

        public IPluginInstance? PluginInstance { get; private set; }
        public BrowserControl()
        {
            InitializeComponent();
        }

        public void SetPluginInstance(IPluginInstance pluginInstance)
        {
            ExplorerTree.BeforeExpand += ObjectTreeView_BeforeExpand;

            CatalogNode = new TreeNode("Catalogs");
            ExplorerTree.Nodes.Add(CatalogNode);

            PluginInstance = pluginInstance;
            _metadataExplorer = pluginInstance.GetMetadataExplorer();
            //_connection = PluginInstance.GetQuery();
            if (_metadataExplorer.DisplayByCatalog)
                LoadCatalogs();
        }



        public async void LoadCatalogs()
        {
            if (PluginInstance != null && _metadataExplorer != null && CatalogNode != null)
            {
                var catalogs = await _metadataExplorer.LoadCatalogs();
                CatalogNode.Nodes.Clear();
                foreach (var catalog in catalogs)
                {
                    TreeNode node = new TreeNode(catalog.Name);
                    node.Tag = catalog;

                    if (_metadataExplorer.DisplayBySchema)
                    {
                        var childNode = AddTreeNode(node,"Schemas", NODE_SCHEMAS, true);
                    }
                    else
                    {
                        CreateDatabaseObjectNodes(node);
                    }

                    CatalogNode.Nodes.Add(node);
                }
                CatalogNode.Expand();
            }
        }

        private void CreateDatabaseObjectNodes(TreeNode node)
        {
            var childNode = AddTreeNode(node, "Tables", NODE_TABLES, true);
            childNode = AddTreeNode(node, "Views", NODE_VIEWS, true);
            childNode = AddTreeNode(node, "Synonyms", NODE_SYNONYMS, true);
            var prog = AddTreeNode(node, "Programmability", NODE_PROGRAMMABILITY, false);
            childNode = AddTreeNode(prog, "Stored Procedures", NODE_STOREDPROCEDURES, true);
        }

        private TreeNode AddTreeNode(TreeNode parent, string name, object? tag, bool addPlaceholderChild)
        {
            // create a new TreeNode
            TreeNode node = new TreeNode(name);
            // assign any tag provided (used to identify the node later)
            node.Tag = tag;

            // Placeholder nodes are added in some cases to make the [+] show up
            // so that we can dynamically fill out the tree later
            if (addPlaceholderChild)
            {
                // create a child TreeNode
                var childNode = new TreeNode("Placeholder");
                // fill the Placeholder object onto the tag so we can identify it later
                childNode.Tag = NODE_PLACEHOLDER;
                // add the placeholder node to the new node
                node.Nodes.Add(childNode);
            }
            // add the new node into the TreeView
            parent.Nodes.Add(node);
            return node;
        }

        internal void SetTreeViewFocus()
        {
            ExplorerTree.Focus();
        }

        private async void ObjectTreeView_BeforeExpand(object? sender, TreeViewCancelEventArgs e)
        {
            bool changed = false;
            var eventNode = e.Node;
            // if the event is for a treeview node that is expanding
            if ((sender != null) && (_metadataExplorer != null) && (sender is TreeView tv) && eventNode != null && e.Action == TreeViewAction.Expand)
            {
                // if the node has a parent, and the node has a placeholder child
                if (eventNode.Parent != null && ChildNodeIsPlaceholder(eventNode))
                {
                    // check if the node is a schema listing
                    if (eventNode.Tag == NODE_SCHEMAS)
                    {
                        // check if the node that is expanding is the catalog node
                        if (eventNode.Parent.Tag is Catalog catalog)
                        {
                            changed = await LoadSchemas(eventNode, catalog);
                        }
                    }
                    // check if the node is a table listing
                    else if (eventNode.Tag == NODE_TABLES)
                    {
                        changed = await LoadObjects(eventNode, _metadataExplorer.LoadTables);
                    }
                    // check if the node is a view listing
                    else if (eventNode.Tag == NODE_VIEWS)
                    {
                        changed = await LoadObjects(eventNode, _metadataExplorer.LoadViews);
                    }
                    // check if the node is a synonym listing
                    else if (eventNode.Tag == NODE_SYNONYMS)
                    {
                        changed = await LoadObjects(eventNode, _metadataExplorer.LoadSynonyms);
                    }
                    // check if the node is a stored procedure listing
                    else if (eventNode.Tag == NODE_STOREDPROCEDURES)
                    {
                        changed = await LoadObjects(eventNode, _metadataExplorer.LoadStoredProcedures);
                    }
                    // check if the node is a specific schema
                    else if (_metadataExplorer.DisplayBySchema && eventNode.Tag is Schema schema)
                    {
                        // populate tree view nodes for each type of database objects, and placeholder nodes
                        // below them so the [+] sign shows in the TreeView
                        CreateDatabaseObjectNodes(eventNode);
                    }
                }
                
                // cancel if no nodes were changed and there is still one record with a placeholder tag
                e.Cancel = !changed && eventNode.Nodes.Count > 0 && eventNode.Nodes[0].Tag == NODE_PLACEHOLDER;
            }
        }

        private async Task<bool> LoadSchemas(TreeNode eventNode, Catalog catalog)
        {
            if (_metadataExplorer != null)
            {
                var schemas = await _metadataExplorer.LoadSchemas(catalog);
                if (schemas != null)
                {
                    eventNode.Nodes.Clear();
                    foreach (var schema in schemas)
                    {
                        AddTreeNode(eventNode, schema.Name, schema, true);
                    }
                    return true;
                }
            }

            return false;
        }

        // the code to load Tables, Views, Synonyms, Stored Procedures, Functions, etc
        // into the TreeView is all the same, so the method below abstracts this out to
        // remove redundant code. The first parameter is the parent node, and the second
        // parameter is the function call to make to retrieve the list of objects
        private async Task<bool> LoadObjects<T>(TreeNode eventNode, Func<Catalog, Schema?, Task<T[]>> func) where T : NamedMetadata
        {
            // locate the first Treenode ancestor that has a Catalog object in its tag, and return the catalog
            Catalog? catalog = GetCatalogFromNode(eventNode);
            // make sure the metadata explorer has been set, and that a catalog was found
            if (_metadataExplorer != null && catalog != null)
            {
                // call the function provided above to retrieve data from the requisite MetadataExplorer object
                var results = await func(catalog, null);
                // if one or more results were found
                if (results != null)
                {
                    // clear the child nodes from the parent node (remove the Placeholder node)
                    eventNode.Nodes.Clear();
                    // loop through the results
                    foreach (var result in results)
                    {
                        // add a new node for the result item
                        AddTreeNode(eventNode, result.Name, result, false);
                    }
                    return true;
                }
            }
            return false;
        }

        private static Catalog? GetCatalogFromNode(TreeNode eventNode)
        {
            TreeNode catalogNode = eventNode;
            while (catalogNode != null)
            {
                if (catalogNode.Tag is Catalog catalog1)
                {
                    return catalog1;
                }
                else
                {
                    catalogNode = catalogNode.Parent;
                }
            }

            return null;
        }

        private bool ChildNodeIsPlaceholder(TreeNode node)
        {
            if (node.Nodes.Count == 0)
                return false;
            var firstChildNode = node.Nodes[0];
            if (firstChildNode.Tag == NODE_PLACEHOLDER)
                return true;
            return false;
        }

    }
}

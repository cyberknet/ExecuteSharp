using ExecuteSharp;
using ExecuteSharp.Metadata;
using ExecuteSharp.Plugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle
{
    public class OraclePluginInstance : IPluginInstance
    {
        protected List<OracleQuery> OracleQueries { get; set; } = new List<OracleQuery>();

        public Query[] Queries
        { 
            get 
            {
                return OracleQueries
                    .Cast<Query>()
                    .ToArray();
            }
        } 
        public string ConnectionString { get; set; }
        public DatabasePlugin DatabasePlugin { get; set; }

        public OraclePluginInstance(OraclePlugin databasePlugin, string connectionString)
        {
            DatabasePlugin = (DatabasePlugin)databasePlugin;
            ConnectionString = connectionString;
        }

        public Query GetQuery(TimeSpan timeout)
        {
            OracleQuery query = new (ConnectionString, timeout);
            return query;
        }

        public MetadataExplorer GetMetadataExplorer()
        {
            return null;
        }
    }
}

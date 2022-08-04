using ExecuteSharp;
using ExecuteSharp.Databases.Oracle.Metadata;
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

            return GetOracleQuery(timeout);
        }

        private OracleQuery GetOracleQuery(TimeSpan timeout)
        {
            return new(ConnectionString, timeout);
        }

        public MetadataExplorer GetMetadataExplorer()
        {
            return new OracleMetadataExplorer(GetOracleQuery(new TimeSpan(0, 5, 0)));
        }
    }
}

using Microsoft.Data.SqlClient;
using ExecuteSharp;
using ExecuteSharp.Plugins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExecuteSharp.Metadata;
using ExecuteSharp.Databases.SqlServer.Metadata;

namespace ExecuteSharp.Databases.SqlServer
{
    public class SqlServerPluginInstance : IPluginInstance
    {
        protected List<SqlServerQuery> SqlServerQueries { get; set; } = new List<SqlServerQuery>();

        public Query[] Queries
        { 
            get 
            {
                return SqlServerQueries
                    .Cast<Query>()
                    .ToArray();
            }
        } 
        public string ConnectionString { get; set; }
        public DatabasePlugin DatabasePlugin { get; set; }

        public SqlServerPluginInstance(SqlServerPlugin databasePlugin, string connectionString)
        {
            DatabasePlugin = (DatabasePlugin)databasePlugin;
            ConnectionString = connectionString;
        }

        public Query GetQuery(TimeSpan timeout)
        {
            
            return GetSqlServerQuery(timeout);
        }

        private SqlServerQuery GetSqlServerQuery(TimeSpan timeout)
        {
            return new(ConnectionString, timeout);
        }

        public MetadataExplorer GetMetadataExplorer()
        {
            return new SqlServerMetadataExplorer(GetSqlServerQuery(new TimeSpan(0, 5, 0)));
        }
    }
}

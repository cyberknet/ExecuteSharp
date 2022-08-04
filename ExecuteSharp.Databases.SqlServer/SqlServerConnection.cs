using Microsoft.Data.SqlClient;
using ExecuteSharp;
using System.Data.Common;
using System.Data;

namespace ExecuteSharp.Databases.SqlServer
{
    public class SqlServerConnection : Connection
    {
        private const string sql_databases = "select name from sys.databases where owner_sid != 1 order by name asc";
        public SqlServerConnection(string connectionString) : base(connectionString)
        {
        }
        public override void LoadCatalogObjects(Catalog catalog, SchemaObjectType objectType)
        {
            throw new NotImplementedException();
        }

        public override void LoadCatalogs()
        {
            var reader = ExecuteReader(sql_databases);
            if (!reader.IsClosed)
            {
                while (reader.Read())
                {
                    var name = reader[0].ToString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        var catalog = new SqlServerCatalog(this, name);
                        Catalogs.Add(catalog);
                    }
                }
            }
        }

        

        public override Query? ExecuteDataReaderAsync(string query, CancellationToken cancellationToken, params DbParameter[] parameters)
        {
            if (!string.IsNullOrEmpty(query) && parameters is SqlParameter[] sqlParameters)
            {
                SqlConnection connection = new (ConnectionString);
                SqlCommand command = new(query, connection);
                command.Parameters.AddRange(parameters);
                var sqlQuery = new SqlServerQuery(connectionString, TimeSpan.Zero);

            }
            else
            {
                return null;
            }
        }

        internal SqlDataReader ExecuteReader(string query)
        {
            var conn = new SqlConnection(ConnectionString);
            var cmd = new SqlCommand(query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
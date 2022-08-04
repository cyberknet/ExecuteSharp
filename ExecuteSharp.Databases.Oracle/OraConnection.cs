using ExecuteSharp;
using System.Data.Common;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace ExecuteSharp.Databases.Oracle
{
    public class OraConnection : Connection
    {
        private const string sql_databases = "select name from sys.databases where owner_sid != 1 order by name asc";
        public OraConnection(string connectionString) : base(connectionString)
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
                        var catalog = new OraCatalog(this, name);
                        Catalogs.Add(catalog);
                    }
                }
            }
        }

        


        public override Query? ExecuteDataReaderAsync(string query, CancellationToken cancellationToken, params DbParameter[] parameters)
        {
            if (!string.IsNullOrEmpty(query) && parameters is OracleParameter[] sqlParameters)
            {
                OracleConnection connection = new(ConnectionString);
                OracleCommand command = new(query, connection);
                command.Parameters.AddRange(parameters);
                return new OracleQuery(connection, command, TimeSpan.Zero);
            }
            else
            {
                return null;
            }
        }

        internal OracleDataReader ExecuteReader(string query)
        {
            var conn = new OracleConnection(ConnectionString);
            var cmd = new OracleCommand(query, conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
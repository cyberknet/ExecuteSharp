using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp
{
    public abstract class Connection
    {
        public string ConnectionString { get; set; }
        public Connection(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public List<Catalog> Catalogs { get; set; } = new List<Catalog>();

        public abstract void LoadCatalogs();
        public abstract void LoadCatalogObjects(Catalog catalog, SchemaObjectType objectType);

        public abstract Query? ExecuteDataReaderAsync(string query, CancellationToken cancellationToken, params DbParameter[] parameters);
    }
}

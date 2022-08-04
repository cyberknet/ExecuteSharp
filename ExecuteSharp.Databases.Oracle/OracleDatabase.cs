using ExecuteSharp;

namespace ExecuteSharp.Databases.Oracle
{
    public class OracleConnection : Connection
    {
        public OracleConnection(string connectionString) : base(connectionString) { }
        public override void LoadCatalogObjects(Catalog catalog, SchemaObjectType objectType)
        {
            throw new NotImplementedException();
        }

        public override void LoadCatalogs()
        {
            throw new NotImplementedException();
        }
    }
}
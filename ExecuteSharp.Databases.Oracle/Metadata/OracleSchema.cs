using ExecuteSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle.Metadata
{
    public class OracleSchema : Schema
    {
        private readonly OraConnection _sqlServerConnection;
        private readonly OraCatalog _sqlServerCatalog;
        public OracleSchema(OraConnection connection, OraCatalog catalog, string name) : base(connection, catalog, name)
        {
            _sqlServerConnection = connection;
            _sqlServerCatalog = catalog;
        }

        public override bool LoadObjects(SchemaObjectType objectType)
        {
            switch (objectType)
            {
                case SchemaObjectType.Table:
                    return LoadTables();
                default:
                    return false;
            }
        }

        private bool LoadTables()
        {
            return true;
        }
    }
}

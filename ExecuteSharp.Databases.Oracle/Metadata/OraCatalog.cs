using ExecuteSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle
{
    public class OraCatalog : Catalog
    {
        private const string sql_schemas = "select schema_name, schema_owner from {0}.information_schema.schemata order by schema_name, schema_owner";
        protected OraConnection _sqlServerDatabase;
        public OraCatalog(OraConnection database, string name) : base(database, name)
        {
            _sqlServerDatabase = database;
        }

        public override bool LoadSchemas()
        {
            var schemaReader = _sqlServerDatabase.ExecuteReader(string.Format(sql_schemas, this.Name));
            while (schemaReader.Read())
            {
                var name = schemaReader[0].ToString();
                if (name != null)
                {
                    var schema = new OracleSchema(_sqlServerDatabase, this, name);
                    Schemas.Add(schema);
                }
            }
            return true;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExecuteSharp.Metadata;
using Oracle.ManagedDataAccess.Client;
using View = ExecuteSharp.Metadata.View;

namespace ExecuteSharp.Databases.Oracle.Metadata
{
    public class OracleMetadataExplorer : MetadataExplorer
    {
        const string SQL_CATALOGS = "select name from sys.databases where owner_sid != 1 order by name asc";
        const string SQL_SCHEMAS = 
@"SELECT distinct s.name AS Schema_Name
    FROM  {0}.sys.objects o 
    JOIN  {0}.sys.schemas s
      ON  s.schema_id = o.schema_id
   WHERE  o.type NOT IN ('S'  --SYSTEM_TABLE
                        ,'PK' --PRIMARY_KEY_CONSTRAINT
                        ,'D'  --DEFAULT_CONSTRAINT
                        ,'C'  --CHECK_CONSTRAINT
                        ,'F'  --FOREIGN_KEY_CONSTRAINT
                        ,'IT' --INTERNAL_TABLE
                        ,'SQ' --SERVICE_QUEUE
                        ,'TR' --SQL_TRIGGER
                        ,'UQ' --UNIQUE_CONSTRAINT
						)
          or s.name = 'dbo'
ORDER BY  SCHEMA_NAME";
        const string SQL_TABLES = "select table_name, table_schema from {0}.information_schema.tables{1} order by table_name asc";
        const string SQL_TABLES_SCHEMA = " where table_schema=@schema_name";

        const string SQL_VIEWS = "select table_name, table_schema from {0}.information_schema.views{1} order by table_name asc";
        const string SQL_VIEWS_SCHEMA = " where table_schema=@schema_name";

        const string SQL_SYNONYMS = "select syn.name as synonym_name, sch.name as schema_name from {0}.sys.synonyms syn join {0}.sys.schemas sch on syn.schema_id = sch.schema_id{1} order by syn.name asc";
        const string SQL_SYNONYMS_SCHEMA = " where sch.name=@schema_name";

        const string SQL_STORED_PROCEDURES = "select routine_name as procedure_name, routine_schema as procedure_schema from {0}.INFORMATION_SCHEMA.ROUTINES{1} order by routine_name asc";
        const string SQL_STORED_PROCEDURES_SCHEMA = " where routine_schema='@schema_name'";

        const string SQL_FUNCTIONS = "select routine_name as procedure_name, routine_schema as procedure_schema from {0}.INFORMATION_SCHEMA.ROUTINES{1} order by routine_name asc";
        const string SQL_FUNCTIONS_SCHEMA = " where routine_schema='@schema_name'";

        private OracleQuery _oracleQuery;
        public override bool DisplayBySchema { get => true; }
        public override bool DisplayByCatalog { get => false; }
        public OracleMetadataExplorer(OracleQuery query) : base(query)
        {
                _oracleQuery = query;
        }
        public override async Task<Catalog[]> LoadCatalogs()
        {
            List<Catalog> catalogs = new List<Catalog>();
            var reader = await _oracleQuery.ExecuteReaderAsync(SQL_CATALOGS);
            if (!reader.IsClosed)
            {
                while (reader.Read())
                {
                    var name = reader[0].ToString();
                    if (!string.IsNullOrEmpty(name))
                    {
                        var catalog = new OracleCatalog(name);
                        catalogs.Add((Catalog)catalog);
                    }
                }
                Catalogs.Clear();
                Catalogs.AddRange(catalogs);
            }
            return catalogs.ToArray();
        }

        public override async Task<Schema[]> LoadSchemas(Catalog catalog)
        {
            var explorerCatalog = Catalogs.FirstOrDefault(c => c.Name == catalog.Name);
            var schemas = new List<Schema>();
            var reader = await _oracleQuery.ExecuteReaderAsync(string.Format(SQL_SCHEMAS, catalog.Name));
            if (explorerCatalog != null)
            {
                if (!reader.IsClosed)
                {
                    while (reader.Read())
                    {
                        var name = reader[0].ToString();
                        if (name != null)
                        {
                            var schema = new OracleSchema(explorerCatalog, name);
                            schemas.Add(schema);
                        }
                    }
                }
                explorerCatalog.Schemas.Clear();
                explorerCatalog.Schemas.AddRange(schemas);
            }
            return schemas.ToArray();
        }

        public override async Task<Table[]> LoadTables(Catalog catalog, Schema? schema)
        {
            var results = await LoadObjects<Table, OracleTable>(catalog.Name, catalog.Tables, schema, SQL_TABLES, SQL_TABLES_SCHEMA);
            return results.ToArray();
        }

        public override async Task<View[]> LoadViews(Catalog catalog, Schema? schema)
        {
            var results = await LoadObjects<View, OracleView>(catalog.Name, catalog.Views, schema, SQL_VIEWS, SQL_VIEWS_SCHEMA);
            return results.ToArray();
        }

        public override async Task<Synonym[]> LoadSynonyms(Catalog catalog, Schema? schema)
        {
            var results = await LoadObjects<Synonym, OracleSynonym>(catalog.Name, catalog.Synonyms, schema, SQL_SYNONYMS, SQL_SYNONYMS_SCHEMA);
            return results.ToArray();
        }

        public override async Task<StoredProcedure[]> LoadStoredProcedures(Catalog catalog, Schema? schema)
        {
            var results = await LoadObjects <StoredProcedure, OracleStoredProcedure>(catalog.Name, catalog.StoredProcedures, schema, SQL_STORED_PROCEDURES, SQL_STORED_PROCEDURES_SCHEMA);
            return results.ToArray();
        }
        public override async Task<Function[]> LoadFunctions(Catalog catalog, Schema? schema)
        {
            var results = await LoadObjects<Function,OracleFunction>(catalog.Name, catalog.Functions, schema, SQL_FUNCTIONS, SQL_FUNCTIONS_SCHEMA);
            return results.ToArray();
        }

        // The work done to load Tables, Views, Synonyms, Stored Procedures, Functions, etc
        // is all the same, so the method below abstracts it out to remove redundant code.
        private async Task<TBase[]> LoadObjects<TBase, TConcrete>(string catalogName, List<TBase> collection, Schema? schema, string sqlObjectSelection, string sqlSchemaFilter) 
            where TBase : CatalogNamedMetadata
            where TConcrete : TBase
        {
            // get a reference to the catalog stored in this object
            var explorerCatalog = Catalogs.FirstOrDefault(c => c.Name == catalogName);
            var objects = new List<TBase>();
            string sql = sqlObjectSelection;
            string sql_schema = string.Empty;
            List<DbParameter> parameters = new();

            // make sure the catalog found is not null
            if (explorerCatalog != null && _oracleQuery != null)
            {
                // if the schema was passed in
                if (schema != null)
                {
                    // add the schema filter subsection
                    sql_schema = sqlSchemaFilter;
                    // create a parameter for the schema name
                    var param = _oracleQuery.CreateDbParameter("@schema_name", schema.Name);
                    parameters.Add(param);
                }

                // query the SQL Server for the records that matched
                var reader = await _oracleQuery.ExecuteReaderAsync(string.Format(sql, catalogName, sql_schema), parameters.ToArray());

                // if records were found
                if (!reader.IsClosed)
                {
                    // determine the concrete type that we will be hydrating
                    var type = typeof(TConcrete);
                    // loop through all records
                    while (reader.Read())
                    {
                        // get the name from the reader, always first position
                        var name = reader[0].ToString();
                        if (name != null)
                        {
                            // we're going to create this via reflection, so create an array of parameters
                            // to pass to the constructor. For objects inheriting from CatalogNamedMetadata,
                            // this will always have constructor parameters Catalog, Name
                            var constructorParameters = new object[] { explorerCatalog, name };
                            
                            // create an instance of TConcrete
                            var obj = Activator.CreateInstance(type, constructorParameters);
                            // cast the object to TBase, and validate it is not null
                            if (obj is TBase typedObject && typedObject != null)
                            {
                                // add the object to our list
                                objects.Add(typedObject);
                            }
                            
                        }
                    }
                    // clear the catalog collection
                    collection.Clear();
                    // add all the found objects into the catalog collection
                    collection.AddRange(objects);
                }
            }
            return objects.ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Metadata
{
    public abstract class MetadataExplorer
    {
        protected Query _query;
        public abstract bool DisplayBySchema { get; }
        public MetadataExplorer(Query query)
        {
            _query = query;
        }

        public List<Catalog> Catalogs { get; set; } = new ();
        public List<Schema> Schemas { get; set; } = new ();

        public abstract Task<Catalog[]> LoadCatalogs();
        public abstract Task<Schema[]> LoadSchemas(Catalog catalog);
        public abstract Task<Table[]> LoadTables(Catalog catalog, Schema? schema);
        public abstract Task<View[]> LoadViews(Catalog catalog, Schema? schema);
        public abstract Task<Synonym[]> LoadSynonyms(Catalog catalog, Schema? schema);
        public abstract Task<StoredProcedure[]> LoadStoredProcedures(Catalog catalog, Schema? schema);
        public abstract Task<Function[]> LoadFunctions(Catalog catalog, Schema? schema);
    }
}

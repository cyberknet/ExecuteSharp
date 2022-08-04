using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Metadata
{
    public abstract class CatalogNamedMetadata : NamedMetadata
    {
        public Catalog Catalog { get; set; }
        public CatalogNamedMetadata(Catalog catalog, string name) : base(name) { Catalog = catalog; }
    }
}

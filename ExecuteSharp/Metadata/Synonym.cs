using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Metadata
{
    public abstract class Synonym : CatalogNamedMetadata
    {
        public Synonym(Catalog catalog, string name) : base(catalog, name) { }
    }
}

using ExecuteSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle.Metadata
{
    public class OracleSynonym : Synonym
    {
        public OracleSynonym(OracleCatalog catalog, string name) : base(catalog, name)
        {

        }
    }
}

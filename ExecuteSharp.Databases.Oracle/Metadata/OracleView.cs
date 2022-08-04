using ExecuteSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle.Metadata
{
    public class OracleView : ExecuteSharp.Metadata.View
    {
        public OracleView(OracleCatalog catalog, string name) : base(catalog, name)
        {

        }
    }
}

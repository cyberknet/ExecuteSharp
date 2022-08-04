using ExecuteSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.SqlServer.Metadata
{
    public class SqlServerSynonym : Synonym
    {
        public SqlServerSynonym(SqlServerCatalog catalog, string name) : base(catalog, name)
        {

        }
    }
}

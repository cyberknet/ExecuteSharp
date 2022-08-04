using ExecuteSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.SqlServer.Metadata
{
    public class SqlServerStoredProcedure : StoredProcedure
    {
        public SqlServerStoredProcedure(SqlServerCatalog catalog, string name) : base(catalog, name)
        {

        }
    }
}

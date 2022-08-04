using ExecuteSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.SqlServer.Metadata
{
    public class SqlServerTable : Table
    {
        public SqlServerTable(SqlServerCatalog catalog, string name) : base(catalog, name)
        {

        }
    }
}

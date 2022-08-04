using ExecuteSharp;
using ExecuteSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.SqlServer.Metadata
{
    public class SqlServerCatalog : Catalog
    {
        public SqlServerCatalog(string name) : base(name)
        {
        }
    }
}

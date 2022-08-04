using ExecuteSharp;
using ExecuteSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.SqlServer
{
    public class SqlServerSchema : Schema
    {
        public SqlServerSchema(Catalog catalog, string name) : base(catalog, name)
        {
        }
    }
}

using ExecuteSharp;
using ExecuteSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle
{
    public class OracleSchema : Schema
    {
        public OracleSchema(Catalog catalog, string name) : base(catalog, name)
        {
        }
    }
}

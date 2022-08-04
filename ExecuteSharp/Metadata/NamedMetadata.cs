using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Metadata
{
    public abstract class NamedMetadata
    {
        public string Name { get; set; }
        public NamedMetadata(string name) { Name = name; }
    }
}

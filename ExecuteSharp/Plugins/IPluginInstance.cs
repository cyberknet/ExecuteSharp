using ExecuteSharp.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Plugins
{
    public interface IPluginInstance
    {
        Query[] Queries { get; }
        DatabasePlugin DatabasePlugin { get; set; }

        Query GetQuery(TimeSpan timeout);
        MetadataExplorer GetMetadataExplorer();
    }
}

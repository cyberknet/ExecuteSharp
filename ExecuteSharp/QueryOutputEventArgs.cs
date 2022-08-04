using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp
{
    public class QueryOutputEventArgs : EventArgs
    {
        public string Message { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string[] Errors { get; set; } = new string[] { };
    }
}

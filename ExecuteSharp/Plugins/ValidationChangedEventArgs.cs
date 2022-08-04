using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Plugins
{
    public class ValidationChangedEventArgs : EventArgs
    {
        public bool IsValid { get; set; } = false;
    }
}

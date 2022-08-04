using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.UI.Controls
{
    public class InterfaceActiveEventArgs : EventArgs 
    {
        
        public InterfaceActiveEventArgs(bool isQueryActive)
        {
            IsQueryActive = isQueryActive;
        }

        public bool IsQueryActive { get; private set; }
    }

}

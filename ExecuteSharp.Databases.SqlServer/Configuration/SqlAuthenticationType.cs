using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.SqlServer.Configuration
{
    public enum SqlAuthenticationType
    {
        Windows = 0,
        SqlServer = 1,
        AzureMFA = 2,
        AzurePassword = 3,
        AzureIntegrated = 4
    }
}

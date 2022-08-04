using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle.Configuration
{
    public class LdapSettings
    {
        public string? LdapOraFilename { get; set; }
        public string? DefaultAdminContext { get; set; }
        public string? DirectoryServers { get; set; }
        public string? DirectoryServerType { get; set; }
        public int? Timeout { get; set; } = -1;
        public bool? AuthenticateBind { get; set; }
        public string? BindWalletLocation { get; set; }
        public string? AuthenticationWalletLocation { get; internal set; }
    }
}

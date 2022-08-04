using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.Oracle.Configuration
{
    public class OracleConnectionDetails
    {
        public ResolutionMethod ResolutionMethod { get; set; }
        public string? Hostname { get; internal set; }
        public string? Port { get; internal set; }
        public string? InstanceName { get; internal set; }
        public string? Protocol { get; internal set; }
        public string? Service { get; internal set; }
        public string? Sid { get; internal set; }

        public override string ToString()
        {
            switch (ResolutionMethod)
            {
                case ResolutionMethod.TnsNames:
                    break;
                case ResolutionMethod.Direct:
                    break;
                case ResolutionMethod.Ldap:
                    break;
            }
            return $"";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp.Databases.SqlServer.Configuration
{
    public class SqlServerConnectionDetails
    {
        public string Hostname { get; set; } = string.Empty;
        public SqlAuthenticationType SqlAuthenticationType { get; set; } = SqlAuthenticationType.SqlServer;
        public string? UserId { get; set; }
        public string? Password { get; set; }

        public override string ToString()
        {
            string descriptor = string.Empty;
            switch(SqlAuthenticationType)
            {
                case SqlAuthenticationType.Windows:
                    descriptor = " (Windows)";
                    break;
                case SqlAuthenticationType.AzurePassword:
                    descriptor = $" (Azure: {UserId})";
                    break;
                case SqlAuthenticationType.AzureIntegrated:
                    descriptor = $" (Azure Integrated)";
                    break;
                case SqlAuthenticationType.AzureMFA:
                    descriptor = $" (Azure MFA: {UserId})";
                    break;
                case SqlAuthenticationType.SqlServer:
                    descriptor = $" (SQL: {UserId})";
                    break;
            }
            return $"{Hostname}{descriptor}";
        }
    }
}

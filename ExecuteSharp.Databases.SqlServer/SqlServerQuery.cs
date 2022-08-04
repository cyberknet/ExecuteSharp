using Microsoft.Data.SqlClient;
using ExecuteSharp;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ExecuteSharp.Databases.SqlServer
{
    public class SqlServerQuery : Query
    {
        public SqlServerQuery(string connectionString, TimeSpan timeout) : base(connectionString, timeout)
        {
        }

        protected override DbConnection InitializeConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            return connection;
        }

        protected override void SetupOutputCapture()
        {
            if (this._connection is SqlConnection sqlConnection)
            {
                sqlConnection.InfoMessage += SqlConnection_InfoMessage;
            }
        }

        protected override DbCommand? CreateCommand(string query, params DbParameter[] parameters)
        {
            if (this._connection is SqlConnection sqlConnection)
            {
                if (_transaction is SqlTransaction sqlTransaction)
                {
                    var command = new SqlCommand(query, sqlConnection, sqlTransaction);
                    if (parameters.Length > 0 && parameters is SqlParameter[] sqlParameters)
                    {
                        command.Parameters.AddRange(sqlParameters);
                    }
                    return command;
                }
            }
            return null;
        }

        private void SqlConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            List<string> errors = new();
            if (e.Errors != null)
            {
                foreach(SqlError error in e.Errors)
                    errors.Add(error.ToString());
            }
            this.OnOutputReceived(new QueryOutputEventArgs
            {
                Errors = errors.ToArray(),
                Message = e.Message,
                Source = e.Source
            });
        }

        #region CreateParameter
        #region CreateDbParameter
        public override DbParameter? CreateDbParameter(string parameterName, object value, DbType dbType)
        {
            try
            {
                var param = new SqlParameter(parameterName, value);
                param.DbType = dbType;
                return param;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public override DbParameter? CreateDbParameter(string parameterName, object value, DbType dbType, int size)
        {
            try
            {
                var param = new SqlParameter(parameterName, value);
                param.DbType = dbType;
                param.Size = size;
                return param;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public override DbParameter? CreateDbParameter(string parameterName, object value, DbType dbType, int size, string sourceColumn)
        {
            try
            {
                var param = new SqlParameter(parameterName, value);
                param.DbType = dbType;
                param.Size = size;
                param.SourceColumn = sourceColumn;
                return param;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public override DbParameter? CreateDbParameter(string parameterName, DbType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
        {
            try
            {
                var param = new SqlParameter(parameterName, value);
                param.DbType = dbType;
                param.Size = size;
                param.SourceColumn = sourceColumn;
                param.Direction = direction;
                param.IsNullable = isNullable;
                param.Precision = precision;
                param.Scale = scale;
                param.SourceVersion = sourceVersion;
                return param;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public override DbParameter CreateDbParameter(string parameterName, object value)
        {
            return new SqlParameter(parameterName, value);
        }
        public override DbParameter CreateDbParameter()
        {
            return new SqlParameter();
        }
        #endregion
        #endregion
    }
}

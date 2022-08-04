using Oracle.ManagedDataAccess.Client;
using ExecuteSharp;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ExecuteSharp.Databases.Oracle
{
    public class OracleQuery : Query
    {
        public OracleQuery(string connectionString, TimeSpan timeout) : base(connectionString, timeout)
        {
        }

        protected override void SetupOutputCapture()
        {
            if (this._connection is OracleConnection oracleConnection)
            {
                oracleConnection.InfoMessage += OracleConnection_InfoMessage;
            }
        }

        protected override DbConnection InitializeConnection(string connectionString)
        {
            var connection = new OracleConnection(connectionString);
            return connection;
        }

        protected override DbCommand? CreateCommand(string query, params DbParameter[] parameters)
        {
            if (this._connection is OracleConnection oracleConnection && _transaction is OracleTransaction oracleTransaction && parameters is OracleParameter[] oracleParameters)
            {
                var command = new OracleCommand(query, oracleConnection);
                command.Transaction = oracleTransaction;

                if (parameters.Length > 0)
                {
                    command.Parameters.AddRange(oracleParameters);
                }
                return command;
            }
            return null;
        }

        private void OracleConnection_InfoMessage(object sender, OracleInfoMessageEventArgs e)
        {
            List<string> errors = new();
            if (e.Errors != null)
            {
                foreach (OracleError error in e.Errors)
                    errors.Add(error.ToString());
            }
            this.OnOutputReceived(new QueryOutputEventArgs
            {
                Errors = errors.ToArray(),
                Message = e.Message,
                Source = e.Source
            });
        }


        #region CreateDbParameter
        public override DbParameter? CreateDbParameter(string parameterName, object value, DbType dbType)
        {
            try
            {
                var param = new OracleParameter(parameterName, value);
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
                var param = new OracleParameter(parameterName, value);
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
                var param = new OracleParameter(parameterName, value);
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
                var param = new OracleParameter(parameterName, value);
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
            return new OracleParameter(parameterName, value);
        }
        public override DbParameter CreateDbParameter()
        {
            return new OracleParameter();
        }
        #endregion
    }
}

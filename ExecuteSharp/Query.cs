using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecuteSharp
{
    public abstract class Query
    {
        private string _connectionString = string.Empty;
        public DateTime Started { get; private set; }
        public TimeSpan ExecutionDuration { get => DateTime.Now - Started; }
        public DbDataReader? DataReader { get; set; }
        public TimeSpan Timeout { get; private set; }
        public CancellationToken CancellationToken { get; private set; }
        protected DbConnection _connection { get; set; }
        protected DbTransaction? _transaction { get; set; }

        public event EventHandler<QueryOutputEventArgs>? OutputReceived;


        public Query(string connectionString, TimeSpan timeout)
        {
            _connectionString = connectionString;
            _connection = InitializeConnection(connectionString);
            _connection.StateChange += Connection_StateChange;
            SetupOutputCapture();

            CancellationTokenSource source = new CancellationTokenSource();
            source.CancelAfter(timeout);
            CancellationToken = source.Token;

        }

        protected abstract DbConnection InitializeConnection(string connectionString);

        protected virtual void OnOutputReceived(QueryOutputEventArgs e)
        {
            var handler = OutputReceived;
            if (handler != null)
                handler(this, e);
        }

        protected abstract void SetupOutputCapture();

        public async Task<DbDataReader?> ExecuteReaderAsync(string query, params DbParameter[] parameters)
        {
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            if (_transaction == null)
            {
                _transaction = _connection.BeginTransaction();
            }
            var command = CreateCommand(query, parameters);
            if (command != null)
            {
                var reader = await command.ExecuteReaderAsync(CancellationToken);
                return reader;
            }
            return null;
        }

        public async Task<bool> Commit()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Rollback()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                return true;
            }
            return false;
        }

        protected abstract DbCommand? CreateCommand(string query, params DbParameter[] parameters);
        



        private void Connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
        }

        #region CreateParameter
        public abstract DbParameter? CreateDbParameter();
        public abstract DbParameter? CreateDbParameter(string parameterName, object value);
        public abstract DbParameter? CreateDbParameter(string parameterName, object value, DbType dbType);
        public abstract DbParameter? CreateDbParameter(string parameterName, object value, DbType dbType, int size);
        public abstract DbParameter? CreateDbParameter(string parameterName, object value, DbType dbType, int size, string sourceColumn);
        public abstract DbParameter? CreateDbParameter(string parameterName, DbType dbType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value);
        #endregion
    }
}

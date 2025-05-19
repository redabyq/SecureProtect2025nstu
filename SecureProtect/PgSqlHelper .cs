using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureProtect
{
    public class PgSqlHelper : IDisposable
    {
        private NpgsqlConnection _connection;
        private readonly string _connectionString;
        public PgSqlHelper(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        public async Task OpenConnectionAsync()
        {
            if (_connection == null)
            {
                _connection = new NpgsqlConnection(_connectionString);
            }
            if (_connection.State != ConnectionState.Open)
            {
                await _connection.OpenAsync();
            }
        }
        public async Task CloseConnectionAsync()
        {
            if (_connection?.State == ConnectionState.Open)
            {
                await _connection.CloseAsync();
            }
        }
        public async Task<DataTable> ExecuteQueryAsDataTableAsync(string sql, params NpgsqlParameter[] parameters)
        {
            await OpenConnectionAsync();

            using (var command = new NpgsqlCommand(sql, _connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (var reader = await command.ExecuteReaderAsync())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }
        public async Task<List<T>> ExecuteQueryAsListAsync<T>(string sql, Func<NpgsqlDataReader, T> mapper, params NpgsqlParameter[] parameters)
        {
            await OpenConnectionAsync();

            var result = new List<T>();

            using (var command = new NpgsqlCommand(sql, _connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(mapper(reader));
                    }
                }
            }

            return result;
        }
        public async Task<object> ExecuteScalarAsync(string sql, params NpgsqlParameter[] parameters)
        {
            await OpenConnectionAsync();

            using (var command = new NpgsqlCommand(sql, _connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                return await command.ExecuteScalarAsync();
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, params NpgsqlParameter[] parameters)
        {
            await OpenConnectionAsync();

            using (var command = new NpgsqlCommand(sql, _connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                return await command.ExecuteNonQueryAsync();
            }
        }

        public NpgsqlParameter CreateParameter(string name, object value, NpgsqlTypes.NpgsqlDbType dbType)
        {
            return new NpgsqlParameter(name, dbType) { Value = value ?? DBNull.Value };
        }

        public void Dispose()
        {
            _connection?.Dispose();
            _connection = null;
        }
    }
}

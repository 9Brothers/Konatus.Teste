using System.Collections.Generic;
using System.Threading.Tasks;
using Konatus.Teste.Domain.Interfaces.Repositories.SqlServer;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using Dapper;
using System.Data;

namespace Konatus.Teste.Infrastructure.SqlServer
{
    public class SqlServerRepository<T> : ISqlServerRepository<T> where T : class
    {
        // * Attr
        private readonly string _connectionString;

        // * Props
        protected string ProcedureName { get; set; }
        public object Params { get; set; }
        
        public SqlServerRepository(IConfiguration configuration)
        {
            _connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING") ?? configuration.GetConnectionString("AircraftControl");
        }

        public virtual async Task<string> Add(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<string>(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual async Task<int> Delete(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual async Task<IEnumerable<T>> Get(T entity, int page = 0)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<T>(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }

        public virtual async Task<int> Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(ProcedureName, Params, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
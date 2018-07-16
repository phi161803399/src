using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace RekenMachineAPI.Service
{
    public interface IBaseService
    {
        DbContext DbContext { get; set; }

        Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData);
        Task WithConnection(Func<IDbConnection, Task> getData);

        Task<TResult> WithConnection<TRead, TResult>(Func<IDbConnection, Task<TRead>> getData,
            Func<TRead, Task<TResult>> process);
    }

    public class BaseService : IBaseService
    {
        public DbContext DbContext { get; set; }
        private readonly string _connectionString;

        public BaseService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Context"].ConnectionString;            
        }

        public async Task<T> WithConnection<T>(Func<IDbConnection, Task<T>> getData)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    return await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL exception (not a timeout)", ex);
            }
        }

        // use for buffered queries that do not return a type
        // ReSharper disable once UnusedMember.Global
        public async Task WithConnection(Func<IDbConnection, Task> getData)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    await getData(connection);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL exception (not a timeout)", ex);
            }
        }

        // use for non-buffered queries that return a type
        // ReSharper disable once UnusedMember.Global
        public async Task<TResult> WithConnection<TRead, TResult>(Func<IDbConnection, Task<TRead>> getData,
            Func<TRead, Task<TResult>> process)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var data = await getData(connection);
                    return await process(data);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL timeout", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception($"{GetType().FullName}.WithConnection() experienced a SQL exception (not a timeout)", ex);
            }
        }
    }
}
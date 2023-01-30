using Blog.DataAccess.Abstract;
using Blog.Entity.Config;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Blog.DataAccess.Concrete
{
    public class DBRepository : IDBRepository
    {
        private readonly ConnectionStrings _connectionStrings;  

        public DBRepository(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        private IDbConnection GetDbConnection()
        {
            return new SqlConnection(_connectionStrings.DbConnection);
        }        

        public async Task<List<T>> GetAllAsync<T>(string commandText, DynamicParameters? parameters = null)
        {
            using(var db = GetDbConnection())
            {
                var result = await db.QueryAsync<T>(commandText, parameters);
                return result.ToList();
            }
        }

        public async Task<T> GetAsync<T>(string commandText, DynamicParameters? parameters = null)
        {
            using(var db = GetDbConnection())
            {
                return  await db.QueryFirstOrDefaultAsync<T>(commandText, parameters);
            }
        }

        public async Task<T> InsertAsync<T>(string commandText, DynamicParameters? parameters = null)
        {
            using(var db = GetDbConnection())
            {
                return await db.QuerySingleAsync<T>(commandText, parameters);
            }
        }

        public async Task UpdateAsync(string commandText, DynamicParameters? parameters = null)
        {
            using(var db= GetDbConnection())
            {
               await db.QueryAsync(commandText, parameters);
            }
        }

        public async Task DeleteAsync(string commandText, DynamicParameters? parameters = null)
        {
            using(var db=GetDbConnection())
            {
                await db.QueryAsync(commandText, parameters);
            }
        }
    }
}

using Dapper;

namespace Blog.DataAccess.Abstract
{
    public interface IDBRepository
    {
        Task<T> GetAsync<T>(string commandText, DynamicParameters? parameters = null);
        Task<List<T>> GetAllAsync<T>(string commandText, DynamicParameters? parameters = null);
        Task<T> InsertAsync<T>(string commandText, DynamicParameters? parameters = null);
        Task UpdateAsync(string commandText, DynamicParameters? parameters = null);
        Task DeleteAsync(string commandText, DynamicParameters? parameters = null);
    }
}

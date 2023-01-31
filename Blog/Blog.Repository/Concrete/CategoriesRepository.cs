using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Blog.Entity.Models;
using Blog.Repository.Abstract;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Blog.Repository.Concrete
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IDBRepository _dBRepository;

        public CategoriesRepository(IDBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            string sql = "Select * from Category";
            return await _dBRepository.GetAllAsync<Category>(sql);
        }
    }
}

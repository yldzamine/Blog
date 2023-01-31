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
        //private readonly IDBRepository _dBRepository;
        private readonly DBEFContext _dbContext;    

        public CategoriesRepository(DBEFContext dBEFContext)
        {
            
            _dbContext = dBEFContext;   
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Category.ToListAsync();
        }
    }
}

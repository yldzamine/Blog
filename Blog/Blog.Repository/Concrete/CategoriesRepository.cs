using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Blog.Entity.Models;
using Blog.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Blog.Repository.Concrete
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly IDBRepository _dBRepository;
        private readonly DBEFContext _dbContext;    

        public CategoriesRepository(IDBRepository dBRepository,
                                    DBEFContext dBEFContext)
        {
            _dBRepository = dBRepository;
            _dbContext = dBEFContext;   
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}

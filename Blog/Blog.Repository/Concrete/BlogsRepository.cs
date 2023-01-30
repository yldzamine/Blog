using Blog.DataAccess.Abstract;
using Blog.DataAccess.Concrete;
using Blog.Entity.Models;
using Blog.Repository.Abstract;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Blog.Repository.Concrete
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly IDBRepository _dbRrepository;
        private readonly DBEFContext _dBEFContext;

        public BlogsRepository(IDBRepository dbRepository,
                               DBEFContext dBEFContext)
        {
            _dBEFContext = dBEFContext;
            _dbRrepository = dbRepository;  
        }
            

        public async Task<List<Blogs>> GetAllBlogsAsync(string title)
        {
            string sql = "Select * from Blogs b INNER JOIN Category c ON b.Category = c.Id";
            DynamicParameters dynamicParameters = new DynamicParameters();  
            if(!string.IsNullOrEmpty(title))
            {
                sql += "and Title Like @Title";
                dynamicParameters.Add("Title", "%" + title + "%", DbType.String);  
            }

            return await _dbRrepository.GetAllAsync<Blogs>(sql, dynamicParameters);            
        }

        public async Task<List<Blogs>> GetBlogsAsync()
        {
            return await _dBEFContext.Blogs.ToListAsync();
        }

        public async Task<Blogs> GetBlogsByIdAsync(int id)
        {
            string sql = "Select * from Blogs Where Id = @Id";
            DynamicParameters dynParameters = new DynamicParameters();
            dynParameters.Add("Id", id, DbType.Int32);   
            return await _dbRrepository.GetAsync<Blogs>(sql, dynParameters);    
        }

        public  async Task<Blogs> InsertBlogsAsync(Blogs blogs)
        {
            string sql = @"Insert Into Blogs(Title, Description, Url, Category)
                          Values(@Title, @Description, @Url, @Category) Select SCOPE_IDENTITY()";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("Title ", blogs.Title, DbType.String);
            dynamicParameters.Add("Description", blogs.Description, DbType.String); 
            dynamicParameters.Add("Url", blogs.Url, DbType.String);
            dynamicParameters.Add("Category", blogs.Category, DbType.Int32);
            int id = await _dbRrepository.InsertAsync<int>(sql, dynamicParameters);
            blogs.Id = id;
            return blogs;

        }

        public async Task UpdateBlogsAsync(Blogs blogs)
        {
            string sql = @"Update t SET 
                                  t.Title = @Title,
                                  t.Description = @Description,
                                  t.Url = @Url
                                  t.Category = Category
                          From Blogs t 
                          Where t.Id = @Id";
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("Id", blogs.Id, DbType.Int32);
            dynamicParameters.Add("Title", blogs.Title, DbType.String);
            dynamicParameters.Add("Description", blogs.Description , DbType.String);
            dynamicParameters.Add("Url", blogs.Url, DbType.String);
            dynamicParameters.Add("Category", blogs.Category , DbType.Int32);

            await _dbRrepository.UpdateAsync(sql, dynamicParameters);
        }

        public async Task DeleteBlogsAsync(int id)
        {
            string sql = "Delete From Blogs Where Id = @ Id";
            DynamicParameters dynParameters = new DynamicParameters();
            dynParameters.Add("Id", id, DbType.Int32);  

            await _dbRrepository.DeleteAsync(sql, dynParameters);   
        }
    }
}

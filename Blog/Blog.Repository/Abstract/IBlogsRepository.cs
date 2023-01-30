using Blog.Entity.Models;

namespace Blog.Repository.Abstract
{
    public interface IBlogsRepository
    {
        Task<List<Blogs>> GetBlogsAsync();
        Task<Blogs> GetBlogsByIdAsync(int id);
        Task<List<Blogs>> GetAllBlogsAsync(string title);
        Task<Blogs> InsertBlogsAsync(Blogs blogs);
        Task UpdateBlogsAsync(Blogs blogs);
        Task DeleteBlogsAsync(int id);
    }
}

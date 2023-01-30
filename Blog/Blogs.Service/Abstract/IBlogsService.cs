using Blog.Entity.Dtos;

namespace Blogs.Service.Abstract
{
    public interface IBlogsService
    {
        Task<List<BlogDto>> GetBlogsAsync();
        Task<BlogDto> GetBlogsByIdAsync(int id);
        Task<List<BlogDto>> GetAllBlogsAsync(string title);
        Task<BlogDto> InsertBlogsAsync(BlogInsertDto blogsDto);
        Task UpdateBlogsAsync(int id, BlogInsertDto blogsDto);
        Task DeleteBlogsAsync(int id);
    }
}

using Blog.Entity.Dtos;

namespace Blogs.Service.Abstract
{
    public interface ICategoriesService
    {
        Task<List<CategoryDto>> GetNewsAsync();
    }
}

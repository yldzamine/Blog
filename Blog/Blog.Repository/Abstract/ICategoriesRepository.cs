using Blog.Entity.Models;

namespace Blog.Repository.Abstract
{
    public interface ICategoriesRepository
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}

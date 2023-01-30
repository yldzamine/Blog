using Blog.Entity.Dtos;
using Blog.Repository.Concrete;
using Blogs.Service.Abstract;

namespace Blogs.Service.Concrete
{
    public class CategoriesService : ICategoriesService
    {
        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesService(CategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }   

        public async Task<List<CategoryDto>> GetNewsAsync()
        {
           var modelList = await _categoriesRepository.GetCategoriesAsync();    

           return modelList.Select(model => new CategoryDto
           {
               Id = model.Id,
               Title = model.Title
           }).ToList(); 
        }
    }
}

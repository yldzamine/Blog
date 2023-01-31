using Blog.Entity.Dtos;
using Blog.Repository.Abstract;
using Blogs.Service.Abstract;

namespace Blogs.Service.Concrete
{
    public class BlogService : IBlogsService
    {
        private readonly IBlogsRepository _blogsRepository;

        public BlogService(IBlogsRepository blogsRepository)
        {
            _blogsRepository = blogsRepository;
        }       

        public async Task<List<BlogDto>> GetAllBlogsAsync(string title)
        {
           var modelList = await _blogsRepository.GetAllBlogsAsync(title);

            return modelList.Select(model => new BlogDto
            {
                Id = model.Id,
                Title = model.Title,    
                Description = model.Description,
                Category = model.Category
            }).ToList();
        }

        public async Task<List<BlogDto>> GetBlogsAsync()
        {
            var modelList = await _blogsRepository.GetBlogsAsync();

            return modelList.Select(model => new BlogDto
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Category = model.Category
            }).ToList();
        }

        public async Task<BlogDto> GetBlogsByIdAsync(int id)
        {
            var model = await _blogsRepository.GetBlogsByIdAsync(id);

            return new BlogDto
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Category = model.Category
            };
        }

        public async Task<BlogDto> InsertBlogsAsync(BlogInsertDto blogsDto)
        {
            if (blogsDto == null)
                return null;

            var model = await _blogsRepository.InsertBlogsAsync(new Blog.Entity.Models.Blogs
            {

                Title = blogsDto.Title,
                Description = blogsDto.Description,
                Category = blogsDto.Category
            });

            if (model.Id == 0)
                return null;

            return new BlogDto
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Category = model.Category
            };
        }

        public async Task UpdateBlogsAsync(int id, BlogInsertDto blogsDto)
        {
            await _blogsRepository.UpdateBlogsAsync(new Blog.Entity.Models.Blogs 
            {
                Id = id,
                Title = blogsDto.Title,
                Description= blogsDto.Description,
                Category= blogsDto.Category
            });

        }

        public async Task DeleteBlogsAsync(int id)
        {
            await _blogsRepository.DeleteBlogsAsync(id);
        }
    }
}

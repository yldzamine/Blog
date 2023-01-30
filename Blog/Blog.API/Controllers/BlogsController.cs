using Blogs.Service.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogService _blogService;
        private readonly CategoriesService _categoriesService;

        public BlogsController(BlogService blogService,
                               CategoriesService categoriesService)
        {
            _blogService = blogService;
            _categoriesService = categoriesService;
        }   
               
    }
}
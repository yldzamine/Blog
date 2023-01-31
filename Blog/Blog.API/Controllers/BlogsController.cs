using Blog.Entity.Dtos;
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
          
        
        /// <summary>
        /// Gets Blogs List
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<BlogDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogsAll([FromQuery] string search)
        {
            var response = await _blogService.GetAllBlogsAsync(search);

            return Ok(response);
        }

        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BlogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogById([FromRoute] int id)
        {
            var response = await _blogService.GetBlogsByIdAsync(id);

            return Ok(response);
        }

        /// <summary>
        /// Insert Blog
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BlogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBlog([FromRoute] int id, [FromBody]  BlogInsertDto model)
        {
            if (model == null)
                return BadRequest("Model can not be null");
            
            await _blogService.UpdateBlogsAsync(id, model);

            return Ok();
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BlogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBlog([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("id can not be 0!");

            await _blogService.DeleteBlogsAsync(id);    

            return Ok();
        }



    }
}
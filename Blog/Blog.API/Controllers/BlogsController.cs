using Blog.Entity.Dtos;
using Blogs.Service.Abstract;
using Blogs.Service.Concrete;
using Microsoft.AspNetCore.Mvc;


namespace Blog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogsService _blogService;
        private readonly ICategoriesService _categoriesService;

        public BlogsController(IBlogsService blogService, ICategoriesService categoriesService)
        {
            _blogService = blogService;
            _categoriesService = categoriesService; 
        }


        /// <summary>
        /// Depending on the search, the method that lists the blog
        /// if the search is empty, all the blog data is listed.
        /// </summary>
        /// <param name="search"></param>
        /// <returns>IEnumerable of slugs</returns>
        /// <response code="200">If all requested items are found</response>
        /// <response code="400">If slugs parameter is missing</response>       
        [HttpGet]
        [ProducesResponseType(typeof(List<BlogDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogsAll([FromQuery] string? search)
        {
            var response = await _blogService.GetAllBlogsAsync(search);

            return Ok(response);
        }

        /// <summary>
        /// Method to fetch blog data to id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">If all requested items are found</response>
        /// <response code="400">If slugs parameter is missing</response>       
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BlogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlogById([FromRoute] int id)
        {
            var response = await _blogService.GetBlogsByIdAsync(id);

            return Ok(response);
        }

        /// <summary>
        /// The method that updates the blog data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">If all requested items are found</response>
        /// <response code="400">If slugs parameter is missing</response>
        [HttpPost("{id}")]
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
        /// Method that deletes a blog based on the entered id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">If all requested items are found</response>
        /// <response code="400">If slugs parameter is missing</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BlogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBlog([FromRoute] int id)
        {
            if (id == 0)
                return BadRequest("id can not be 0!");

            await _blogService.DeleteBlogsAsync(id);    

            return Ok();
        }


        /// <summary>
        /// Blog Insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <response code="200">If all requested items are found</response>
        /// <response code="400">If slugs parameter is missing</response>
        [HttpPost]
        [ProducesResponseType(typeof(BlogDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertBlog([FromBody] BlogInsertDto model)
        {
            if (model == null)
                return BadRequest("Blog model can not be null!");

            await _blogService.InsertBlogsAsync(model);

            return Ok();
        }

     
    }
}
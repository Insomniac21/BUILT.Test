using BUILT.Test.RestApi.Models;
using BUILT.Test.RestApi.Requests;
using BUILT.Test.RestApi.Responses;
using BUILT.Test.RestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BUILT.Test.RestApi.Controllers
{
    [Route("categories")]
    [ApiController]
    public class BlogPostCategories : ControllerBase
    {
        private BlogPostCategoryService _blogPostCategoryService;

        public BlogPostCategories(BlogPostCategoryService blogPostCategoryService) 
        {
            _blogPostCategoryService = blogPostCategoryService;
        }

        /// <summary>
        /// Get all the blog posts
        /// </summary>
        /// <remarks>
        /// Sample request :
        /// 
        ///     GET /posts
        /// </remarks>
        /// <returns>All the blog post that can be found.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAllBlogPostCategoryResponse>> GetAllBlogPostCategories()
        {
            return new GetAllBlogPostCategoryResponse() 
            {
                Categories = await _blogPostCategoryService.GetAllBlogPostCategories()
            };
        }
    }
}

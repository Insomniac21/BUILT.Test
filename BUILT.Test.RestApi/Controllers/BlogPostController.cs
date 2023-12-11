using BUILT.Test.RestApi.Exceptions;
using BUILT.Test.RestApi.Models;
using BUILT.Test.RestApi.Requests;
using BUILT.Test.RestApi.Responses;
using BUILT.Test.RestApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace BUILT.Test.RestApi.Controllers
{
    [Route("posts")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private BlogPostService _blogPostService;

        public BlogPostController(BlogPostService blogPostService) 
        {
            _blogPostService = blogPostService;
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
        public async Task<ActionResult<GetAllBlogPostResponse>> GetAllBlogPosts()
        {
            return new GetAllBlogPostResponse() 
            {
                Posts = await _blogPostService.GetAllBlogPost()
            };
        }

        /// <summary>
        /// Get a blog post by is Id
        /// </summary>
        /// <param name="id">The id need to be integer.</param>
        /// <returns>An example</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetBlogPostByIdResponse>> GetBlogPostById(int id)
        {
            BlogPostModel? example = await _blogPostService.GetBlogPostById(id);
            if (example == null) return StatusCode(404, $"The blog post with id {id} could not be found.");

            return new GetBlogPostByIdResponse()
            {
                Example = example
            };
        }

        /// <summary>
        /// Create a blog post
        /// </summary>
        /// <returns>An example</returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<BlogPostModel>> CreateBlogPost(CreateBlogPostRequest createblogPostRequest)
        {
            try
            {
                BlogPostModel? blogPost = await _blogPostService.CreateBlogPost(createblogPostRequest);

                return StatusCode(201, blogPost);
            }
            catch (CategoryDoesNotExistException)
            {
                return StatusCode(400, $"The category id {createblogPostRequest.CategoryId} does not exist.");
            }
        }

        /// <summary>
        /// Update a blog post
        /// </summary>
        /// <returns>The updated example</returns>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BlogPostModel>> UpdateBlogPost(UpdateBlogPostRequest updateBlogPostRequest)
        {
            try
            {
                BlogPostModel? blogPost = await _blogPostService.UpdateBlogPost(updateBlogPostRequest);

                return StatusCode(200, blogPost);
            }
            catch (CategoryDoesNotExistException)
            {
                return StatusCode(400, $"The category id {updateBlogPostRequest.CategoryId} does not exist.");
            }
        }

        /// <summary>
        /// Delete all blog posts
        /// </summary>
        /// <returns>The updated example</returns>
        [HttpDelete()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BlogPostModel>> DeleteAllBlogPost()
        {
            int delete_count = await _blogPostService.DeleteAllBlogPost();
            return StatusCode(200, delete_count);
        }

        /// <summary>
        /// Delete all blog posts
        /// </summary>
        /// <returns>The updated example</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BlogPostModel>> DeleteBlogPostById(int id)
        {
            int delete_count = await _blogPostService.DeleteBlogPostById(id);
            if (delete_count <= 0) return StatusCode(404, $"The blog post with id {id} can't be found.");
            return StatusCode(200, delete_count);
        }
    }
}

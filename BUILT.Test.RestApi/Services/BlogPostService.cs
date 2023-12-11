using BUILT.Test.RestApi.Models;
using BUILT.Test.RestApi.Repositories;
using BUILT.Test.RestApi.Requests;
using System.Runtime.InteropServices;

namespace BUILT.Test.RestApi.Services
{
    public class BlogPostService
    {
        private BlogPostRepository _blogPostRepository;

        public BlogPostService(BlogPostRepository blogPostRepository) 
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IEnumerable<BlogPostModel>> GetAllBlogPost() => await _blogPostRepository.GetAllBlogPost();

        public async Task<BlogPostModel?> GetBlogPostById(int id) => await _blogPostRepository.GetBlogPostById(id);

        public async Task<BlogPostModel?> GetBlogPostByTitle(string title) => await _blogPostRepository.GetBlogPostByTitle(title);

        public async Task<BlogPostModel> CreateBlogPost(CreateBlogPostRequest createBlogPostRequest) => 
            await _blogPostRepository
                .CreateBlogPost(new BlogPostModel()
                {
                    Title = createBlogPostRequest.Title,
                    Contents = createBlogPostRequest.Contents,
                    CategoryId = createBlogPostRequest.CategoryId
                });

        public async Task<BlogPostModel> UpdateBlogPost(UpdateBlogPostRequest updateBlogPostRequest) => 
            await _blogPostRepository
                .UpdateBlogPost(new BlogPostModel()
                {
                    Id = updateBlogPostRequest.Id,
                    Title = updateBlogPostRequest.Title,
                    Contents = updateBlogPostRequest.Contents,
                    CategoryId = updateBlogPostRequest.CategoryId
                });

        public async Task<int> DeleteAllBlogPost() => await _blogPostRepository.DeleteAllBlogPost();

        public async Task<int> DeleteBlogPostById(int id) => await _blogPostRepository.DeleteBlogPostById(id);
    }
}

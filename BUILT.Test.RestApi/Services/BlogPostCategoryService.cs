using BUILT.Test.RestApi.Models;
using BUILT.Test.RestApi.Repositories;

namespace BUILT.Test.RestApi.Services
{
    public class BlogPostCategoryService
    {
        private BlogPostCategoryRepository _blogPostCategoriesRepository;

        public BlogPostCategoryService(BlogPostCategoryRepository blogPostCategoriesRepository)
        {
            _blogPostCategoriesRepository = blogPostCategoriesRepository;
        }

        public async Task<IEnumerable<BlogPostCategoryModel>> GetAllBlogPostCategories() => await _blogPostCategoriesRepository.GetAllBlogPostCategories();

    }
}

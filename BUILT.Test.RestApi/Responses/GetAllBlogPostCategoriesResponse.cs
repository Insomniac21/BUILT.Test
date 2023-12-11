using BUILT.Test.RestApi.Models;

namespace BUILT.Test.RestApi.Responses
{
    public class GetAllBlogPostCategoryResponse
    {
        public required IEnumerable<BlogPostCategoryModel> Categories { get; set; }
    }
}

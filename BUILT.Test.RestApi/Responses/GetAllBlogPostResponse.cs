using BUILT.Test.RestApi.Models;
using BUILT.Test.RestApi.Services;

namespace BUILT.Test.RestApi.Responses
{
    public class GetAllBlogPostResponse
    {
        public required IEnumerable<BlogPostModel> Posts { get; set; }
    }
}

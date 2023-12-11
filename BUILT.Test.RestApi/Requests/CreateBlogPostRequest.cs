namespace BUILT.Test.RestApi.Requests
{
    public class CreateBlogPostRequest
    {
        public required string Title { get; set; }
        public required string Contents { get; set; }
        public required int CategoryId { get; set; }

    }
}

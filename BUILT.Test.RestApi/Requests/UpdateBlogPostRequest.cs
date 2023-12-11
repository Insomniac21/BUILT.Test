namespace BUILT.Test.RestApi.Requests
{
    public class UpdateBlogPostRequest
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Contents { get; set; }
        public int CategoryId { get; set; }
    }
}

namespace BUILT.Test.RestApi.Models
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Contents { get; set; }
        public DateTime TimeStamp { get; set; }
        public int CategoryId { get; set; }
    }
}

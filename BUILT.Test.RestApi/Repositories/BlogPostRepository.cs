using BUILT.Test.RestApi.DbContexts;
using BUILT.Test.RestApi.Exceptions;
using BUILT.Test.RestApi.Models;
using Dapper;
using System.Data;

namespace BUILT.Test.RestApi.Repositories
{
    public class BlogPostRepository
    {
        private IDbConnection _connection;

        public BlogPostRepository(BlogDbContext context) 
        { 
            _connection = context.CreateConnection();
        }

        public async Task<IEnumerable<BlogPostModel>> GetAllBlogPost()
        {
            return await _connection.QueryAsync<BlogPostModel>("SELECT Id, Title, Contents, TimeStamp FROM BlogPosts ORDER BY TimeStamp ASC");
        }

        public async Task<BlogPostModel?> GetBlogPostById(int id)
        {
            object parameter = new { Id = id };
            return await _connection.QueryFirstOrDefaultAsync<BlogPostModel?>("SELECT * FROM BlogPosts WHERE Id = @Id", parameter);
        }

        public async Task<BlogPostModel?> GetBlogPostByTitle(string title)
        {
            object parameter = new { Title = title };
            return await _connection.QueryFirstOrDefaultAsync<BlogPostModel?>(
                @"SELECT Id, Title, Contents, TimeStamp, CategoryId FROM BlogPosts WHERE Name = @Title", parameter);
        }

        public async Task<BlogPostModel> CreateBlogPost(BlogPostModel blogPost)
        {
            object parameter = blogPost;
            await ThrowIfCategoryDoesNotExist(blogPost.CategoryId);
            blogPost = await _connection
                .QuerySingleAsync<BlogPostModel>(
                "INSERT INTO BlogPosts (Title, Contents, CategoryId) OUTPUT INSERTED.* VALUES (@Title, @Contents, @CategoryId)", 
                parameter);
            return blogPost;
        }

        public async Task<BlogPostModel> UpdateBlogPost(BlogPostModel blogPost)
        {
            object parameter = blogPost;
            await ThrowIfCategoryDoesNotExist(blogPost.CategoryId);
            blogPost.Id = await _connection
                .ExecuteAsync(
                "UPDATE BlogPosts SET Title = @Title, Contents = @Contents, CategoryId = @CategoryId WHERE Id = @Id", 
                parameter);
            return blogPost;
        }

        public async Task<int> DeleteAllBlogPost() => await _connection.ExecuteAsync("DELETE FROM BlogPosts");

        public async Task<int> DeleteBlogPostById(int id)
        {
            object parameter = new { Id = id };
            return await _connection.ExecuteAsync("DELETE FROM BlogPosts WHERE Id = @Id", parameter);
        }

        private async Task ThrowIfCategoryDoesNotExist(int categoryId)
        {
            var doesCategoryExist = await _connection.ExecuteScalarAsync<bool>("select count(1) from BlogPostCategories where Id=@id", new { Id = categoryId });
            if (!doesCategoryExist)
                throw new CategoryDoesNotExistException();
        }
    }
}

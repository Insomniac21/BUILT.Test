using BUILT.Test.RestApi.DbContexts;
using BUILT.Test.RestApi.Models;
using Dapper;
using System.Data;

namespace BUILT.Test.RestApi.Repositories
{
    public class BlogPostCategoryRepository
    {
        private IDbConnection _connection;

        public BlogPostCategoryRepository(BlogDbContext context)
        {
            _connection = context.CreateConnection();
        }

        public async Task<IEnumerable<BlogPostCategoryModel>> GetAllBlogPostCategories()
        {
            return await _connection.QueryAsync<BlogPostCategoryModel>("SELECT Id, Name FROM BlogPostCategories");
        }
       
    }
}

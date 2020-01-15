using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyGraphQL.Domain.EF.Configuration;
using MyGraphQL.Domain.Entity.Entities;
namespace MyGraphQL.Domain.EF
{
    public class ArticlesDbContext : DbContext
    {

        private readonly string _connectionString;

        public ArticlesDbContext()
        {
            _connectionString = Configure.ConfigurationBuilder()
                                               .Build()
                                               .GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<ArticlesDbContext>();
            builder.UseSqlServer(_connectionString);
        }

        /// <summary>
        /// Constructor for migrations
        /// </summary>
        /// <param name="options"></param>
        public ArticlesDbContext(DbContextOptions<ArticlesDbContext> options) : base(options) {}


        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleInfo> ArticleInfos { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    }
}

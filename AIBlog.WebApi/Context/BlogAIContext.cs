using AIBlog.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace AIBlog.WebApi.Context
{
    public class BlogAIContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public BlogAIContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("BlogAI")
                    ?? throw new InvalidOperationException("ConnectionStrings:BlogAI bağlantı ayarı bulunamadı.");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
    }
}

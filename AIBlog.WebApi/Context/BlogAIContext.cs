using AIBlog.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AIBlog.WebApi.Context
{
    public class BlogAIContext : IdentityDbContext<AppUser>
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
        public DbSet<Article> Articles => Set<Article>();
        public DbSet<About> Abouts => Set<About>();
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<TradingVideo> TradingVideos => Set<TradingVideo>();

    }
}

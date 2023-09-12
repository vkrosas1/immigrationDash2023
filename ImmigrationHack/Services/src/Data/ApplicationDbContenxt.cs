using ImmigrationHack.Services.src.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImmigrationHack.Services.src.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ApplicationDbContext> _logger;

        public ApplicationDbContext(IConfiguration config, ILogger<ApplicationDbContext> logger)
        {
            _config = config;
            _logger = logger;
        }

        public DbSet<UserAuth> UsersAuth { get; set; }
        public DbSet<UserInfo> UsersInfo { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        public DbSet<Entities.Path> Paths { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<UserPath> UserPaths { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetConnectionString("Database");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}

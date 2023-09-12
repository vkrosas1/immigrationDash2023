namespace ImmigrationHack.Services.src.Data
{
    using ImmigrationHack.Services.src.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _config;
        private readonly ILogger<ApplicationDbContext> _logger;

        public ApplicationDbContext(IConfiguration config, ILogger<ApplicationDbContext> logger)
        {
            _config = config;
            _logger = logger;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDocument> UserDocuments { get; set; }
        public DbSet<Path> Paths { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _config.GetConnectionString("Database");
            optionsBuilder.UseSqlServer(connectionString);
        }
        //public DbSet<YourEntity> YourEntities { get; set; }
    }

}

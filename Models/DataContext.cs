using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace votingApp2.Models
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Options> Options { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Votter> Votters { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poll>()
                .HasMany(p => p.Options)
                .WithOne(o => o.Poll)
                .HasForeignKey(o => o.poll_id);

            modelBuilder.Entity<Votter>()
                .HasMany(u => u.Poll)
                .WithOne(p => p.Votter)
                .HasForeignKey(p => p.owner_id);
        }*/
    }
}

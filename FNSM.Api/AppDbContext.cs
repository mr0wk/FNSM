using FNSM.DataLayer;
using Microsoft.EntityFrameworkCore;

namespace FNSM.Api
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Activity>().HasData(
                new Activity { Id = 1, Description = "My car's gone!", CreatedDate = DateTime.Now});
        }

    }
}

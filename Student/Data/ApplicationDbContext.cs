using Microsoft.EntityFrameworkCore;
using Student.Models;

namespace Student.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        public DbSet<SchoolStudent> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolStudent>().HasData(
                new SchoolStudent
                {
                    ID = 1,
                    Name = "Arjun",
                    standard = 4
                },
                new SchoolStudent
                {
                    ID = 2,
                    Name = "Bashir",
                    standard = 5
                }
                );
        }
    }
}

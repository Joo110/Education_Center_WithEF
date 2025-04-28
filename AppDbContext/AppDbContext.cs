using Education_Center_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Education_Center_EF
{
    public class AppDbContext : DbContext
    {
        public DbSet<clsPeople.Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Conncation.ConnectionString);
        }
    }
}
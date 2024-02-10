using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FoodWithCore.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QE6J6UN\\SQLEXPRESS; database=DbCoreFood; integrated security=true; TrustServerCertificate=true;");
        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

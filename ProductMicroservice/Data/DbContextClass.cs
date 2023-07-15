using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Model;

namespace ProductMicroservice.Data
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration configuration;

        public DbContextClass(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Product> Products { get; set; }
    }
}

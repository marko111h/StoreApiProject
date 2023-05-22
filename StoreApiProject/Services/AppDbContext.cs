using Microsoft.EntityFrameworkCore;
using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public class AppDbContext : DbContext
    {
      

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        Database.Migrate();

        }

        public virtual DbSet<Products> Product { get; set; }
        public virtual DbSet<StateOfStorages> StateOfStorage { get; set; }
        public virtual DbSet<Storages> Storage { get; set; }
    }
}

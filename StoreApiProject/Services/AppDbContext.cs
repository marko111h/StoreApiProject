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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateOfStorages>()
                .HasOne(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<StateOfStorages>()
             .HasOne(s => s.Storage)
             .WithMany()
             .HasForeignKey(s => s.StorageId);
        }
    }
}

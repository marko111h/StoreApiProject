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

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StateOfStorage> StateOfStorages { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StateOfStorage>()
                .HasOne(s => s.Product)
                .WithMany()
                .HasForeignKey(s => s.ProductId);

            modelBuilder.Entity<StateOfStorage>()
             .HasOne(s => s.Storage)
             .WithMany()
             .HasForeignKey(s => s.StorageId);
        }
    }
}

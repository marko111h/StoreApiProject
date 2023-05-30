using Microsoft.EntityFrameworkCore;
using StoreApiProject.Migrations;
using StoreApiProject.Models;
using StoreApiProject.Services;

using System.Security.Cryptography.X509Certificates;

namespace StoreApiProject
{

    public static class DbSeedingClass
    {
        public static void SeedDataContext(this AppDbContext context)
        {
            var products = new List<Product>()
            {
               new Product { ProductName = "Apple", Price = 7.8m },
                    new Product { ProductName = "Banana", Price = 12m },
                    new Product { ProductName = "Orange", Price = 8.5m },
                    new Product { ProductName = "Brocoli", Price = 10m },
                    new Product { ProductName = "Onion", Price = 6.9m },
                    new Product { ProductName = "Tomato", Price = 11m },
                    new Product { ProductName = "Mushrooms", Price = 45m },
                   new Product { ProductName = "Cucamber", Price = 25m },
                      new Product { ProductName = "Carton", Price = 10.5m }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            var storages = new List<Storage>()
            {
               new Storage { StorageName = "Storage1", KindOfStorage = "Fruit" },
                    new Storage { StorageName = "Storage1", KindOfStorage = "Vegetables" },
             
            };
            context.Storages.AddRange(storages);
            context.SaveChanges();

            var productId = 1; 
            var storageId = 1;

            var stateOfStorage = new List<StateOfStorage>()
            {
                new StateOfStorage
                {
                    ProductId = productId,
                    StorageId = storageId,
                    Quantity = 10
                }
            };
            context.StateOfStorages.AddRange(stateOfStorage);
            context.SaveChanges();
        }

}

}

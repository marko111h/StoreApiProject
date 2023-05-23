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
            var products = new List<Products>()
            {
               new Products { ProductName = "Apple", Price = 7.8m },
                    new Products { ProductName = "Banana", Price = 12m },
                    new Products { ProductName = "Orange", Price = 8.5m },
                    new Products { ProductName = "Brocoli", Price = 10m },
                    new Products { ProductName = "Onion", Price = 6.9m },
                    new Products { ProductName = "Tomato", Price = 11m },
                    new Products { ProductName = "Mushrooms", Price = 45m },
                   new Products { ProductName = "Cucamber", Price = 25m },
                      new Products { ProductName = "Carton", Price = 10.5m }
            };
            context.Product.AddRange(products);
            context.SaveChanges();

            var storages = new List<Storages>()
            {
               new Storages { StorageName = "Storage1", KindOfStorage = "Fruit" },
                    new Storages { StorageName = "Storage1", KindOfStorage = "Vegetables" },
             
            };
            context.Storage.AddRange(storages);
            context.SaveChanges();

            var productId = 1; 
            var storageId = 1;

            var stateOfStorage = new List<StateOfStorages>()
            {
                new StateOfStorages
                {
                    ProductId = productId,
                    StorageId = storageId,
                    Quantity = 10
                }
            };
            context.StateOfStorage.AddRange(stateOfStorage);
            context.SaveChanges();
        }

}

}

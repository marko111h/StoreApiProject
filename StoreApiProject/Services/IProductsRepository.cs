﻿using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public interface IProductsRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int ProductId);
        Product GetProductByPrice(decimal Price);
        ICollection<string> GetProductNames();
        ICollection<object> GetProductNamesAndPrices();
        ICollection<Product> GetProducts(decimal? greaterThen, decimal? lowerThen);
        ICollection<Product> GetProductsFruits();
        ICollection<Product> GetProductsVegetables();
         public void DeleteProduct(int productId);

        void SaveChanges();
      

    }
}

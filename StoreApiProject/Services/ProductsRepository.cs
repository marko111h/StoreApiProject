﻿using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public class ProductsRepository : IProductsRepository
    {
        private AppDbContext _productsContext;

        public ProductsRepository(AppDbContext productsContext)
        {
            _productsContext = productsContext;
        }
        public ICollection<Products> GetProducts()
        {
           return _productsContext.Product.OrderBy(p => p.ProductName).ToList();
        }
        //asdasdasdasdsa
        public Products GetProduct(int ProductId)
        {
         
            return _productsContext.Product.Where(p => p.ProductId == ProductId).FirstOrDefault();
        }

        public Products GetProductByPrice(decimal Price)
        {
            return _productsContext.Product.Where(p => p.Price == Price).FirstOrDefault();
        }

        public ICollection<string> GetProductNames()
        {
            return _productsContext.Product.OrderBy(p => p.ProductName).Select(p => p.ProductName).ToList();
        }

        public ICollection<object> GetProductNamesAndPrices()
        {
            return _productsContext.Product.Select(p => new {  p.ProductName, p.Price }).ToList<object>();
        }

        public ICollection<Products> GetProductsGreaterThen10()
        {
           
                return _productsContext.Product.Where(p => p.Price > 10).OrderByDescending(p => p.Price).ToList();
            
        }
    }
}

using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public interface IProductsRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int ProductId);
        Product GetProductByPrice(decimal Price);
        ICollection<string> GetProductNames();
        ICollection<object> GetProductNamesAndPrices();
        ICollection<Product> GetProductsGreaterThen10();
        ICollection<Product> GetProductsGreaterThen10AndLowerThen30();
         public void DeleteProduct(int productId);

        void SaveChanges();
      

    }
}

using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public interface IProductsRepository
    {
        ICollection<Products> GetProducts();
        Products GetProduct(int ProductId);
        Products GetProductByPrice(decimal Price);
        ICollection<string> GetProductNames();
        ICollection<object> GetProductNamesAndPrices();
        ICollection<Products> GetProductsGreaterThen10();
        ICollection<Products> GetProductsGreaterThen10AndLowerThen30();
        void DeleteProduct(int productId);

        void SaveChanges();
      

    }
}

using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public interface IProductsRepository
    {
        ICollection<Products> GetProducts();
        Products GetProducts(int ProductId);
        Products GetProducts(decimal Price);

    }
}

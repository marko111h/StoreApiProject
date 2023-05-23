using StoreApiProject.Models;

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
        public Products GetProducts(int ProductId)
        {
           return _productsContext.Product.Where(p => p.ProductId == ProductId).FirstOrDefault();
        }

        public Products GetProducts(decimal Price)
        {
            throw new NotImplementedException();
        }
    }
}

using StoreApiProject.Models;

namespace StoreApiProject.Services
{
    public class ProductsRepository : IProductsRepository
    {
        string[] fruits = {
                "Apple", "Banana", "Orange", "Mango", "Strawberry", "Grapes",
                "Watermelon", "Pineapple", "Kiwi", "Pear", "Peach", "Cherry",
                "Blueberry", "Raspberry", "Blackberry", "Lemon", "Lime", "Coconut",
                "Pomegranate", "Avocado", "Fig"
            };

        string[] vegetables = {
                    "Carrot", "Broccoli", "Lettuce", "Tomato", "Cucumber", "Spinach",
                    "Onion", "Potato", "Sweet Potato", "Pepper", "Cabbage", "Eggplant",
                    "Zucchini", "Mushroom", "Cauliflower", "Celery", "Radish", "Asparagus",
                    "Green Bean", "Beet", "Brussels Sprouts", "Artichoke"
                };
        private AppDbContext _productsContext;

        public ProductsRepository(AppDbContext productsContext)
        {
            _productsContext = productsContext;
        }
        public ICollection<Product> GetProducts()
        {
           return _productsContext.Products.OrderBy(p => p.ProductId).ToList();
        }
        //asdasdasdasdsa
        public Product GetProduct(int productId)
        {
         
            return _productsContext.Products.Where(p => p.ProductId == productId).FirstOrDefault();
        }

        public Product GetProductByPrice(decimal price)
        {
            return _productsContext.Products.Where(p => p.Price == price).FirstOrDefault();
        }

        public ICollection<string> GetProductNames()
        {
            return _productsContext.Products.OrderBy(p => p.ProductName).Select(p => p.ProductName).ToList();
        }

        public ICollection<object> GetProductNamesAndPrices()
        {
            return _productsContext.Products.Select(p => new {  p.ProductName, p.Price }).Cast<object>().ToList(); 
        }
        
        public ICollection<Product> GetProducts(decimal? greaterThen, decimal? lowerThen )
        {
           if( lowerThen == null )
            {
                return _productsContext.Products.Where(p => p.Price > greaterThen).OrderByDescending(p => p.Price).ToList();
            }
            else if (greaterThen == null)
            {
                return _productsContext.Products.Where(p =>  p.Price < lowerThen.Value).OrderByDescending(p => p.Price).ToList();
            }
            else if (greaterThen > lowerThen)
            {
                return _productsContext.Products.Where(p => p.Price > greaterThen || p.Price < lowerThen.Value).OrderByDescending(p => p.Price).ToList();
            }
            else 

            {
                return _productsContext.Products.Where(p => p.Price > greaterThen && p.Price < lowerThen.Value).OrderByDescending(p => p.Price).ToList();
        }
     

        }
        public ICollection<Product> GetProductsFruits()
        {
            return _productsContext.Products.Where(p => fruits.Contains(p.ProductName)).ToList();
        }

        public ICollection<Product> GetProductsVegetables()
        {
            return _productsContext.Products.Where(p => vegetables.Contains(p.ProductName)).ToList();
        }


        public void DeleteProduct(int productId)
        {
            var product = _productsContext.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                _productsContext.Products.Remove(product);
                _productsContext.SaveChanges();
            }
        }
        public void SaveChanges()
        {
            _productsContext.SaveChanges();
        }

    }
}

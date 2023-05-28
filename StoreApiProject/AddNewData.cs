using StoreApiProject.Models;
using StoreApiProject.Services;

namespace StoreApiProject
{
    public class AddNewData
    {
        //   public string Name { get; set; }
        //  public decimal Price { get; set; }

        public  void Add(string name, decimal price,  AppDbContext context)
        {
            var newProduct = new Products
            {
                 ProductName = name,
                 Price = price,
            };
            context.Product.AddRange(newProduct);
            context.SaveChanges();
        }
    }
}

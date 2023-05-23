using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Services;

namespace StoreApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductsRepository _productsRepository;
        public ProductsController(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        //api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productsRepository.GetProducts().ToList();

            return Ok(products);
        }
    }
}

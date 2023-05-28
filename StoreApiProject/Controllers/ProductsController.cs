using Microsoft.AspNetCore.Mvc;
using StoreApiProject.Models;
using StoreApiProject.Services;

namespace StoreApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductsRepository _productsRepository;
        private AppDbContext _dbContext;
        public ProductsController(IProductsRepository productsRepository, AppDbContext dbContext)
        {
            _productsRepository = productsRepository;
            _dbContext = dbContext;
        }

        //api/products
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productsRepository.GetProducts().ToList();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(products);
        }

        ///get a single product
        //api/products/productId
        [HttpGet("{productId}")]
        public IActionResult GetProduct(int productId)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = _productsRepository.GetProduct(productId);

            return Ok(product);
        }
        /// get product by price but dont work :D
        //api/products/price/{Price}
        [HttpGet("price/{Price}")]
        public IActionResult GetProductByPrice(decimal price)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _productsRepository.GetProductByPrice(price);

         
            return Ok(product);
        }

        ////get products names only
        ///
        // api/products/productsName
        [HttpGet("productsName")]
        public IActionResult GetProductNames()
        {
            var productsName = _productsRepository.GetProductNames().ToList();
            return Ok(productsName);
        }

        // GET: api/products/namesandprices
        [HttpGet("namesandprices")]
        public IActionResult GetProductNamesAndPrices()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = _productsRepository.GetProductNamesAndPrices().ToList();

        

            return Ok(products);
        }

        // GET: api/products/getProductsGreaterThen10
        [HttpGet("getProductsGreaterThen10")]
        public IActionResult GetProductsGreaterThen10()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = _productsRepository.GetProductsGreaterThen10().ToList();



            return Ok(products);
        }


        // GET: api/products/getProductsGreaterThen10AndLowerThen30
        [HttpGet("getProductsGreaterThen10AndLowerThen30")]
        public IActionResult GetProductsGreaterThen10AndLowerThen30()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = _productsRepository.GetProductsGreaterThen10AndLowerThen30().ToList();



            return Ok(products);
        }
        /// POST: api/products
        /// 
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductRequestModel model)
        {
            var newProduct = new Products
            {
                ProductName = model.Name,
                Price = model.Price
            };

            _dbContext.Add(newProduct);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

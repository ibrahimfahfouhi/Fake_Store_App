using FakeStoreApp.entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreApp.Controllers
{
    [ApiController]
    [Route("/products")]
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly FakeStoreDbContext _dbContext;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(FakeStoreDbContext fakeStoreDbContext, ILogger<ProductsController> logger)
        {
            _dbContext = fakeStoreDbContext;
            _logger = logger;
        }
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Product>> getAllProducts() { 
           var products = _dbContext.Set<Product>().ToList();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetProductById(int id) {
            _logger.LogDebug("Getting product #" + id);
            var product = _dbContext.Set<Product>().Find(id);
            if( product == null)
            {
                _logger.LogWarning("Product #{id} was not found -- time: {t}", id, DateTime.Now);
            }
            return product == null? NotFound() : Ok(product); 
        }

        [HttpPost]
        [Route("")]
        public ActionResult<int> creatProduct(Product product) {
            product.id = 0;
            _dbContext.Set<Product>().Add(product);
            _dbContext.SaveChanges();
            return Ok(product);
        }

        [HttpPut]
        [Route("")]
        public ActionResult updateProduct(Product product)
        {
            var existingProduct = _dbContext.Set<Product>().Find(product.id);
            existingProduct.name = product.name;
            existingProduct.sku = product.sku;
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult deleteProduct(int id)
        {
            var productToDelete = _dbContext.Set<Product>().Find(id);
            _dbContext.Set<Product>().Remove(productToDelete);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}

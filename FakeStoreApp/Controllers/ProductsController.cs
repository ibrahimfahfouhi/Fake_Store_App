using FakeStoreApp.entities;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreApp.Controllers
{
    [ApiController]
    [Route("/products")]
    public class ProductsController : Controller
    {
        private readonly FakeStoreDbContext _dbContext;
        public ProductsController(FakeStoreDbContext fakeStoreDbContext)
        {
            _dbContext = fakeStoreDbContext;
        }
        [HttpPost]
        [Route("")]
        public ActionResult<int> creatProduct(Product product) {
            product.id = 0;
            _dbContext.Set<Product>().Add(product);
            _dbContext.SaveChanges();
            return Ok(product);
        }
    }
}

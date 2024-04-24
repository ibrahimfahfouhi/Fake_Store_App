using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;

namespace FakeStoreApp.Controllers
{
    [ApiController]
    [Route("/config")]
    public class ConfigController : ControllerBase
    {
        IConfiguration _configuration;
        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("")]
        public ActionResult getConfig() {
            var confi = new
            {
                DefaultConnection = _configuration["ConnectionStrings:DefaultConnection"]
            };
            return Ok(confi);
        }
    }
}

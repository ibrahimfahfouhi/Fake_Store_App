using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FakeStoreApp.Controllers
{
    [ApiController]
    [Route("Configration")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<AttachmentOptions> _attachmentOptions;

        public ConfigurationController(IConfiguration configuration, IOptions<AttachmentOptions> attachmentOptions)
        {
            _configuration = configuration;
            _attachmentOptions = attachmentOptions;
        }
        [HttpGet]
        [Route("")]
        public ActionResult getConfiguration()
        {
            var config = new
            {
                allowedHosts = _configuration["AllowedHosts"],
                defaultConnection = _configuration.GetConnectionString("DefaultConnection"), //_configuration["ConnectionStrings:DefaultConnection"]
                enableCompression = _attachmentOptions.Value.EnableCompression
            };
            return Ok(config);  
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Subscriber.Configuration;

namespace Subscriber.Controllers
{
    [ApiController]
    [Route("data")]
    public class DataController : ControllerBase
    {
        private readonly ConfigurationStore _cs;
        public DataController(ConfigurationStore cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]string param)
        {
            var data = _cs.GetString(param);
            
            return Ok(data);
        }
    }

}
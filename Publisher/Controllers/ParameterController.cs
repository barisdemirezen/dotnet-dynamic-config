using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Publisher.Data;

namespace Publisher.Controllers
{
    [Route("api")]
    [ApiController]
    public class ParameterController : ControllerBase
    {
        private readonly DataContext _context;

        public ParameterController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ParameterRequestModel request)
        {
            var data = await _context.Parameters
                .Where(x => x.ApplicationName == request.ApplicationName && x.Environment == request.Environment)
                .OrderBy(x => x.ApplicationName)
                .ThenBy(x => x.Environment)
                .Select(e => new ParameterResponseModel
                {
                    Key = e.Key,
                    Value = e.Value
                }).ToListAsync();

            return Ok(data);
        }
    }

    public class ParameterRequestModel
    {
        public string Environment { get; set; }
        public string ApplicationName { get; set; }
    }

    public class ParameterResponseModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

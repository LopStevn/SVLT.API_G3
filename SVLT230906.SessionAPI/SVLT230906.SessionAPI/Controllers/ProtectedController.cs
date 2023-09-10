using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SVLT230906.SessionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProtectedController : ControllerBase
    {
        static List<object> data = new List<object>();
        // GET: api/<ProtectedController>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return data;
        }

        // POST api/<ProtectedController>
        [HttpPost]
        public IActionResult Post(string name, string lastname)
        {
            data.Add(new {name, lastname});
            return Ok();
        }
    }
}

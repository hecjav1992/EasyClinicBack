using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyClinic.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogingController : ControllerBase
    {
        // GET: api/<LogingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LogingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LogingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LogingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LogingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

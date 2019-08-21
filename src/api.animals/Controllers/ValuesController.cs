using System.Collections.Generic;
using auth;
using Microsoft.AspNetCore.Mvc;

namespace api.animals.Controllers
{
    [Route("animals/[controller]")]
    [Auth("animals")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}

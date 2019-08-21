using System.Collections.Generic;
using auth;
using Microsoft.AspNetCore.Mvc;

namespace api.properties.Controllers
{
    [Route("properties/")]
    [Auth("properties")]
    [ApiController]
    public class AllController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}

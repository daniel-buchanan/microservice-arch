using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using auth;

namespace api.event_stream.Controllers
{
    [ApiController]
    public class StreamController : ControllerBase
    {
        // GET api/values
        [HttpPost]
        [Auth("append")]
        [Route("append")]
        public ActionResult<IEnumerable<string>> Append()
        {
            return new string[] { "value1", "value2" };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using es;

namespace api.snapshot.Controllers
{
    [Route("snapshot")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        [Route("update")]
        public void Post([FromBody] EventPayload evnt)
        {
        }
    }
}

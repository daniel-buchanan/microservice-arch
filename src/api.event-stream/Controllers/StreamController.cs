using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using auth;
using es;
using es.Services;

namespace api.event_stream.Controllers
{
    [ApiController]
    public class StreamController : ControllerBase
    {
        private readonly IEventsService _eventsService;

        public StreamController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        // GET api/values
        [HttpPost]
        [Auth("append")]
        [Route("append")]
        public ActionResult<IEnumerable<string>> Append()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Auth("query")]
        [Route("query")]
        public ActionResult<IEnumerable<string>> Get() 
        {
            return null;
        }
    }
}

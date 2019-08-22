using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using auth;
using api.event_stream.Services;
using es;

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
        public StatusCodeResult Append(EventPayload evnt)
        {
            _eventsService.Append(evnt);
            return new StatusCodeResult(200);
        }

        [HttpGet]
        [Auth("query")]
        [Route("query")]
        public IEnumerable<EventPayload> Get(string aggregate) 
        {
            return new List<EventPayload>();
        }
    }
}

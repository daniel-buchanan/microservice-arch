using api.event_coordinator.Services;
using auth;
using es;
using Microsoft.AspNetCore.Mvc;

namespace api.event_coordinator.Controllers
{
    [Route("coordinator")]
    [ApiController]
    public class CoordinatorController : ControllerBase
    {
        private readonly IQueue _queue;

        public CoordinatorController(IQueue queue)
        {
            _queue = queue;
        }

        [HttpPost]
        [Auth("coordinator/publish")]
        [Route("publish")]
        public StatusCodeResult Publish(EventPayload evnt) 
        {
            _queue.Add(evnt);

            return new StatusCodeResult(200);
        }
    }
}

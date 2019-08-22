using api.event_coordinator.Services;
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
        [Route("publish")]
        public StatusCodeResult Publish(EventPayload evnt) 
        {
            _queue.Add(evnt);

            return new StatusCodeResult(200);
        }
    }
}

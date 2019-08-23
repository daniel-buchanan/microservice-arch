using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using es;
using api.snapshot.Services;

namespace api.snapshot.Controllers
{
    [Route("snapshot")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        private readonly ISnapshotUpdateService _snapshotUpdateService;

        public CoreController(ISnapshotUpdateService snapshotUpdateService)
        {
            _snapshotUpdateService = snapshotUpdateService;
        }

        // POST api/values
        [HttpPost]
        [Route("update")]
        public async Task Post([FromBody] EventPayload evnt)
        {
            await _snapshotUpdateService.Update(evnt);
        }
    }
}

using System.Threading.Tasks;
using api.command_handler.Services;
using auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.command_handler.Controllers
{
    [Route("commands")]
    [Auth("commands")]
    [ApiController]
    public class CoreController : ControllerBase
    {
        private readonly ICommandHandlerService _commandHandler;

        public CoreController(ICommandHandlerService commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost]
        public async Task Post([FromBody] object value)
        {
            var json = JsonConvert.SerializeObject(value);
            await _commandHandler.Handle(json);
        }
    }
}

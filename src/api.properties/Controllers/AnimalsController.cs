using System.Collections.Generic;
using auth;
using Microsoft.AspNetCore.Mvc;

namespace api.properties.Controllers
{
    [Route("properties/{propertyId}/animals")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        [Auth("properties/{propertyId}/animals")]
        public ActionResult<IEnumerable<string>> Get(string propertyId)
        {
            return new List<string>()
            {
                "Animal 1",
                "Animal 2"
            };
        }
    }
}
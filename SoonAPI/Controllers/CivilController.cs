using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CivilController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(CivilListResponse.Get());

        }
    }
}


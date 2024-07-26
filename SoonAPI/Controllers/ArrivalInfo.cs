using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrivalInfoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(ArrivalInfoListResponse.Get());

            
        }
    }
}


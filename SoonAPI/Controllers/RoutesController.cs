using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(RoutesListResponse.Get());
        }
    }
}

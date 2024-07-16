using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(BrandListResponse.Get());

            // Receive security header
            string username = Request.Headers["username"];
            string token = Request.Headers["token"];

            // Check if headers were received
            if(!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(token))
            {
                // Validate token
                if(Security.ValidateToken(username, token))
                {
                    return Ok(BrandListResponse.Get());
                }
                else
                {
                    return Ok(MessageResponse.Get(501, "Invalid token"));
                }
              
            }
            else
            {
                return Ok(MessageResponse.Get(500, "Missing security Headers"));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                // Receive security header
                string username = Request.Headers["username"];
                string token = Request.Headers["token"];

                // Check if headers were received
                if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(token))
                {
                    // Validate token
                    if (Security.ValidateToken(username, token))
                    {
                        Brand b = Brand.Get(id);
                        return Ok(BrandResponse.Get(b));
                    }
                    else
                    {
                        return Ok(MessageResponse.Get(501, "Invalid token"));
                    }
                }
                else
                {
                    return Ok(MessageResponse.Get(500, "Missing security Headers"));
                }

            }
            catch (RecordNotFoundException e)
            {
                return Ok(MessageResponse.Get(1, e.Message));
            }
        }
    }
}

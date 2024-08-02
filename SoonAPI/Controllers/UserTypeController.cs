using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(UserTypeListResponse.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                UserType b = UserType.Get(id);
                return Ok(UserTypeResponse.Get(b));
            }
            catch (RecordNotFoundException e)
            {
                return Ok(MessageResponse.Get(1, e.Message));
            }
        }

        [HttpPost]
        public ActionResult Post([FromForm] PostUserType p)
        {
            // Check if data was posted
            if (!String.IsNullOrEmpty(p.Description))
            {
                if (UserType.Add(new UserType(p.Description)))
                    return Ok(MessageResponse.Get(0, "Tipo de Usuario registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo registrar al tipo de usuario"));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }
    }
}

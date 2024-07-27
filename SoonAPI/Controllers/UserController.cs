using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(UserListResponse.Get());
        }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Get(string id)
    {
        try
        {
            Usuario b = Usuario.Get(id);
            return Ok(UserResponse.Get(b));
        }
        catch (RecordNotFoundException e)
        {
            return Ok(MessageResponse.Get(1, e.Message));
        }
    }

    [HttpPost]
        public ActionResult Post([FromForm] PostUser p)
        {
            // Check if data was posted
            if (p.code.HasValue &&
                !String.IsNullOrEmpty(p.email) &&
                !String.IsNullOrEmpty(p.password) &&
                p.type.HasValue)
            {
                if (Usuario.Add(new Usuario(p.code.Value, p.email, p.password, p.type.Value)))
                    return Ok(MessageResponse.Get(0, "Usuario registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo registrar al usuario"));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }
    }



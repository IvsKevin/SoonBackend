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
    [Route("login")]
    public ActionResult Login([FromForm] string email, [FromForm] string password)
    {
        // Check if data was posted
        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
        {
            // Validate credentials
            Usuario? user = Usuario.ValidateCredentials(email, password);
            if (user != null)
            {
                // You can create a session token here or any other logic for successful login
                return Ok(UserResponse.Get(user));
            }
            else
            {
                return Ok(MessageResponse.Get(1, "No se ha encontrado al usuario"));
            }
        }
        else
        {
            return Ok(MessageResponse.Get(2, "Datos del formulario incompletos"));
        }
    }


    [HttpPost]
    public ActionResult Post([FromForm] PostUser p)
    {
        // Check if data was posted
        if (
            !String.IsNullOrEmpty(p.Email) &&
            !String.IsNullOrEmpty(p.Password) &&
            p.Type.HasValue)
        {
            if (Usuario.Add(new Usuario(p.Email, p.Password, p.Type.Value)))
                return Ok(MessageResponse.Get(0, "Usuario registrado correctamente"));
            else
                return Ok(MessageResponse.Get(2, "No se pudo registrar al usuario"));
        }
        else
            return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
    }
}



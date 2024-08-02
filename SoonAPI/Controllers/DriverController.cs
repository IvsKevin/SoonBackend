using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(DriverListResponse.Get());

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                Driver b = Driver.Get(id);
                return Ok(DriverResponse.Get(b));
            }
            catch (RecordNotFoundException e)
            {
                return Ok(MessageResponse.Get(1, e.Message));
            }
        }

        [HttpPost]
        public ActionResult Post([FromForm] PostDriver p)
        {
            // Check if data was posted
            if (!String.IsNullOrEmpty(p.Name) &&
                !String.IsNullOrEmpty(p.LastName) &&
                !String.IsNullOrEmpty(p.LastName2) &&
                !String.IsNullOrEmpty(p.Number) &&
                p.Bus.HasValue &&
                p.User.HasValue)
            {
                if (Driver.Add(new Driver(p.Name, p.LastName, p.LastName2, p.Number, p.Bus.Value, p.User.Value)))
                    return Ok(MessageResponse.Get(0, "Conductor registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo completar el registro del conductor."));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }
    }



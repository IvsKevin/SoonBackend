using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(RoutesListResponse.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                Routes b = Routes.Get(id);
                return Ok(RoutesResponse.Get(b));
            }
            catch (RecordNotFoundException e)
            {
                return Ok(MessageResponse.Get(1, e.Message));
            }
        }

        [HttpPost]
        public ActionResult Post([FromForm] PostRoutes p)
        {
            bool Status = true;  
            // Check if data was posted
            if (!String.IsNullOrEmpty(p.Name))
            {
                if (Routes.Add(new Routes(p.Name, Status)))
                    return Ok(MessageResponse.Get(0, "Ruta registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo completar el registro de la ruta."));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }
    }


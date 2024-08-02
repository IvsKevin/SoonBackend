using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class StationController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {

            return Ok(StationListResponse.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                Station b = Station.Get(id);
                return Ok(StationResponse.Get(b));
            }
            catch (RecordNotFoundException e)
            {
                return Ok(MessageResponse.Get(1, e.Message));
            }
        }

        [HttpPost]
        public ActionResult Post([FromForm] PostStation p)
        {
            // Check if data was posted
            if (
                !String.IsNullOrEmpty(p.Name) &&
                !String.IsNullOrEmpty(p.Location) &&
                p.Status.HasValue)
            {
                if (Station.Add(new Station(p.Name, p.Location, p.Status.Value)))
                    return Ok(MessageResponse.Get(0, "Estacion registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo completar el registro de la estacion."));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }
    }


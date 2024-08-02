using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class RouteStationController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(RouteStationListResponse.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                RouteStation b = RouteStation.Get(id);
                return Ok(RouteStationResponse.Get(b));
            }
            catch (RecordNotFoundException e)
            {
                return Ok(MessageResponse.Get(1, e.Message));
            }
        }

        [HttpPost]
        public ActionResult Post([FromForm] PostRouteStation p)
        {
            // Check if data was posted
            if (p.Route.HasValue && p.Station.HasValue)
            {
                if (RouteStation.Add(new RouteStation(p.Route.Value, p.Station.Value)))
                    return Ok(MessageResponse.Get(0, "Ruta de Estacion registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo completar el registro de la ruta de estacion."));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }
    }



using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(BusListResponse.Get());
        }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Get(string id)
    {
        try
        {
            Bus b = Bus.Get(id);
            return Ok(BusResponse.Get(b));
        }
        catch (RecordNotFoundException e)
        {
            return Ok(MessageResponse.Get(1, e.Message));
        }
    }

    [HttpPost]
    public ActionResult Post([FromForm] PostBus p)
    {
        bool status = true;
        // Check if data was posted
        if (
            !String.IsNullOrEmpty(p.Plates) &&
            p.Capacity.HasValue)
        {
            if (Bus.Add(new Bus(p.Plates, p.Capacity.Value, status)))
                return Ok(MessageResponse.Get(0, "Autobus registrado correctamente"));
            else
                return Ok(MessageResponse.Get(2, "No se pudo registrar el autobus"));
        }
        else
            return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
    }
}



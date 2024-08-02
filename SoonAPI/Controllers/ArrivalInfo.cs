using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class ArrivalInfoController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(ArrivalInfoListResponse.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                ArrivalInfo b = ArrivalInfo.Get(id);
                return Ok(ArrivalInfoResponse.Get(b));
            }
            catch (RecordNotFoundException e)
            {
                return Ok(MessageResponse.Get(1, e.Message));
            }
        }

        [HttpPost]
        public ActionResult Post([FromForm] PostArrivalInfo p)
        {
            // Check if data was posted
            if (p.Station.HasValue &&
                p.Bus.HasValue &&
                p.DepartureTime.HasValue &&
                p.ArrivalTime.HasValue)
            {
                if (ArrivalInfo.Add(new ArrivalInfo(p.Station.Value, p.Bus.Value, p.DepartureTime.Value, p.ArrivalTime.Value)))
                    return Ok(MessageResponse.Get(0, "La informacion de llegada registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo registrar la informacion de llegada"));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }
}



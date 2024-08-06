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
        bool Status = true;
        // Check if data was posted
        if (
            !String.IsNullOrEmpty(p.Name) &&
            !String.IsNullOrEmpty(p.Location) &&
            p.Latitude.HasValue &&
            p.Longitude.HasValue)
            {
                if (Station.Add(new Station(p.Name, p.Location, Status, p.Latitude.Value, p.Longitude.Value)))
                    return Ok(MessageResponse.Get(0, "Estacion registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo completar el registro de la estacion."));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }

    [HttpPut("{id}")]
    public ActionResult Update(string id, [FromForm] PostStation updatedStation)
    {
        try
        {
            if (!String.IsNullOrEmpty(updatedStation.Name) &&
                !String.IsNullOrEmpty(updatedStation.Location) &&
                updatedStation.Latitude.HasValue &&
                updatedStation.Longitude.HasValue)
            {
                Station stationToUpdate = Station.Get(id);
                stationToUpdate.Name = updatedStation.Name;
                stationToUpdate.Location = updatedStation.Location;
                stationToUpdate.Latitude = updatedStation.Latitude.Value;
                stationToUpdate.Longitude = updatedStation.Longitude.Value;

                if (Station.Update(stationToUpdate))
                    return Ok(MessageResponse.Get(0, "Estación actualizada correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo actualizar la estación."));
            }
            else
            {
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
            }
        }
        catch (RecordNotFoundException e)
        {
            return NotFound(MessageResponse.Get(1, e.Message));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageResponse.Get(1, e.Message));
        }
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        try
        {
            if (Station.Delete(id))
                return Ok(MessageResponse.Get(0, "Estación eliminada correctamente"));
            else
                return NotFound(MessageResponse.Get(1, "Estación no encontrada"));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageResponse.Get(1, e.Message));
        }
    }

}


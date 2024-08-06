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
            if (!String.IsNullOrEmpty(p.Name) && !String.IsNullOrEmpty(p.Map))
            {
                if (Routes.Add(new Routes(p.Name, Status, p.Map)))
                    return Ok(MessageResponse.Get(0, "Ruta registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo completar el registro de la ruta."));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }

    [HttpPut("{id}")]
    public ActionResult Update(string id, [FromForm] PostRoutes updatedRoute)
    {
        try
        {
            if (!String.IsNullOrEmpty(updatedRoute.Name) && !String.IsNullOrEmpty(updatedRoute.Map))
            {
                Routes routeToUpdate = Routes.Get(id);
                routeToUpdate.Name = updatedRoute.Name;
                routeToUpdate.Map = updatedRoute.Map;

                if (Routes.Update(routeToUpdate))
                    return Ok(MessageResponse.Get(0, "Ruta actualizada correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo actualizar la ruta."));
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
            if (Routes.Delete(id))
                return Ok(MessageResponse.Get(0, "Ruta eliminada correctamente"));
            else
                return NotFound(MessageResponse.Get(1, "Ruta no encontrada"));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageResponse.Get(1, e.Message));
        }
    }

}


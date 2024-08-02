using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsoleApp.Exceptions;



    [Route("api/[controller]")]
    [ApiController]
    public class CivilController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(CivilListResponse.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                Civil b = Civil.Get(id);
                return Ok(CivilResponse.Get(b));
            }
            catch (RecordNotFoundException e)
            {
                return Ok(MessageResponse.Get(1, e.Message));
            }
        }

        [HttpPost]
        public ActionResult Post([FromForm] PostCivil p)
        {
            // Check if data was posted
            if (!String.IsNullOrEmpty(p.Name) &&
                !String.IsNullOrEmpty(p.LastName) &&
                !String.IsNullOrEmpty(p.LastName2) &&
                !String.IsNullOrEmpty(p.Number) &&
                p.Birthday.HasValue &&
                p.User.HasValue &&
                p.Card.HasValue)
            {
                if (Civil.Add(new Civil(p.Name, p.LastName, p.LastName2, p.Number, p.Birthday.Value, p.User.Value, p.Card.Value)))
                    return Ok(MessageResponse.Get(0, "Civil registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo completar el registro del civil."));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }
    }



using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(CardListResponse.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(string id)
        {
            try
            {
                Card b = Card.Get(id);
                return Ok(CardResponse.Get(b));
            }
            catch (RecordNotFoundException e)
            {
                return Ok(MessageResponse.Get(1, e.Message));
            }
        }

        [HttpPost]
        public ActionResult Post([FromForm] PostCard p)
        {
            // Check if data was posted
            if (p.Balance.HasValue)
            {
                if (Card.Add(new Card(p.Balance.Value)))
                    return Ok(MessageResponse.Get(0, "La cuenta se ha registrado correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo registrar la cuenta"));
            }
            else
                return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
        }

    [HttpPut("{id}")]
    public ActionResult Update(string id, [FromForm] PostCard updatedCard)
    {
        try
        {
            if (updatedCard.Balance.HasValue)
            {
                Card cardToUpdate = Card.Get(id);
                cardToUpdate.Balance = updatedCard.Balance.Value;

                if (Card.Update(cardToUpdate))
                    return Ok(MessageResponse.Get(0, "Tarjeta actualizada correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo actualizar la tarjeta"));
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
            if (Card.Delete(id))
                return Ok(MessageResponse.Get(0, "Tarjeta eliminada correctamente"));
            else
                return NotFound(MessageResponse.Get(1, "Tarjeta no encontrada"));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageResponse.Get(1, e.Message));
        }
    }

}


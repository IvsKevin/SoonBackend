using ConsoleApp.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    [HttpGet]
    public ActionResult Get()
    {
        return Ok(TransactionListResponse.Get());
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult Get(string id)
    {
        try
        {
            Transaction b = Transaction.Get(id);
            return Ok(TransactionResponse.Get(b));
        }
        catch (RecordNotFoundException e)
        {
            return Ok(MessageResponse.Get(1, e.Message));
        }
    }

    [HttpPost]
    public ActionResult Post([FromForm] PostTransaction p)
    {
            DateTime Date = DateTime.Now; 
        // Check if data was posted
        if (!String.IsNullOrEmpty(p.Type) &&
            p.Amount.HasValue &&
            p.Card.HasValue)
        {
            if (Transaction.Add(new Transaction(p.Type, Date, p.Amount.Value, p.Card.Value)))
                return Ok(MessageResponse.Get(0, "Transaccion registrado correctamente"));
            else
                return Ok(MessageResponse.Get(2, "No se pudo completar la transaccion."));
        }
        else
            return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
    }

    [HttpPut("{id}")]
    public ActionResult Update(string id, [FromForm] PostTransaction updatedTransaction)
    {
        try
        {
            if (!string.IsNullOrEmpty(updatedTransaction.Type) && updatedTransaction.Amount.HasValue && updatedTransaction.Card.HasValue)
            {
                Transaction transactionToUpdate = Transaction.Get(id);
                transactionToUpdate.Type = updatedTransaction.Type;
                transactionToUpdate.Amount = updatedTransaction.Amount.Value;
                transactionToUpdate.Card = updatedTransaction.Card.Value;

                if (Transaction.Update(transactionToUpdate))
                    return Ok(MessageResponse.Get(0, "Transacción actualizada correctamente"));
                else
                    return Ok(MessageResponse.Get(2, "No se pudo actualizar la transacción"));
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
            if (Transaction.Delete(id))
                return Ok(MessageResponse.Get(0, "Transacción eliminada correctamente"));
            else
                return NotFound(MessageResponse.Get(1, "Transacción no encontrada"));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, MessageResponse.Get(1, e.Message));
        }
    }

}



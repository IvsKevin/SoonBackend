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
        // Check if data was posted
        if (p.Code.HasValue &&
            !String.IsNullOrEmpty(p.Type) &&
            p.Date.HasValue &&
            p.Amount.HasValue &&
            p.Card.HasValue)
        {
            if (Transaction.Add(new Transaction(p.Code.Value, p.Type, p.Date.Value, p.Amount.Value, p.Card.Value)))
                return Ok(MessageResponse.Get(0, "Transaccion registrado correctamente"));
            else
                return Ok(MessageResponse.Get(2, "No se pudo completar la transaccion."));
        }
        else
            return Ok(MessageResponse.Get(1, "Datos del formulario incompletos"));
    }
}



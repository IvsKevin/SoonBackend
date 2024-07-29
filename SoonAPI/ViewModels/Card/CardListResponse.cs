using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class CardListResponse : JsonResponse
{
    public List<Card>? Cards { get; set; }


    public static CardListResponse Get()
    {
        CardListResponse r = new CardListResponse();
        r.Status = 0;
        r.Cards = Card.Get();
        return r;
    }
}

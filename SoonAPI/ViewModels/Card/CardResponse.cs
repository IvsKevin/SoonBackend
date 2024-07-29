using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class CardResponse : JsonResponse
{
    public Card? Card { get; set; }

    public static CardResponse Get(Card b)
    {
        CardResponse r = new CardResponse();
        r.Status = 0;
        r.Card = b;
        return r;
    }
}


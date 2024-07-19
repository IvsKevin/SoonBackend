using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class TransactionResponse : JsonResponse
{
    public Transaction Transaction { get; set; }

    public static TransactionResponse Get(Transaction b)
    {
        TransactionResponse r = new TransactionResponse();
        r.Status = 0;
        r.Transaction = b;
        return r;
    }
}


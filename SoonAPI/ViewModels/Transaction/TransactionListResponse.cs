using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class TransactionListResponse : JsonResponse
{
    public List<Transaction>? Transactions { get; set; }


    public static TransactionListResponse Get()
    {
        TransactionListResponse r = new TransactionListResponse();
        r.Status = 0;
        r.Transactions = Transaction.Get();
        return r;
    }
}

using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class ArrivalInfoResponse : JsonResponse
{
    public ArrivalInfo ArrivalInfo { get; set; }

    public static ArrivalInfoResponse Get(ArrivalInfo b)
    {
        ArrivalInfoResponse r = new ArrivalInfoResponse();
        r.Status = 0;
        r.ArrivalInfo = b;
        return r;
    }
}


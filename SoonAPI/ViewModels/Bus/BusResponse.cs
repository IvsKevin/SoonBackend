using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class BusResponse : JsonResponse
{
    public Bus Bus { get; set; }

    public static BusResponse Get(Bus b)
    {
        BusResponse r = new BusResponse();
        r.Status = 0;
        r.Bus = b;
        return r;
    }
}


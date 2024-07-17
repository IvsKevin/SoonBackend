using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class StationResponse : JsonResponse
{
    public Station Station { get; set; }

    public static StationResponse Get(Station b)
    {
        StationResponse r = new StationResponse ();
        r.Status = 0;
        r.Station = b;
        return r;
    }
}


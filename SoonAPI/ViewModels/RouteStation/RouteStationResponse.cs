using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class RouteStationResponse : JsonResponse
{
    public RouteStation? RouteStation { get; set; }

    public static RouteStationResponse Get(RouteStation b)
    {
        RouteStationResponse r = new RouteStationResponse();
        r.Status = 0;
        r.RouteStation = b;
        return r;
    }
}


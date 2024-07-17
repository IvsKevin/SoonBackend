using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class RoutesResponse : JsonResponse
{
    public Routes Route { get; set; }

    public static RoutesResponse Get(Routes b)
    {
        RoutesResponse r = new RoutesResponse();
        r.Status = 0;
        r.Route = b;
        return r;
    }
}


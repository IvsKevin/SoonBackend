using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class RouteStationListResponse : JsonResponse
{
    public List<RouteStation> RouteStations { get; set; }


    public static RouteStationListResponse Get()
    {
        RouteStationListResponse r = new RouteStationListResponse();
        r.Status = 0;
        r.RouteStations = RouteStation.Get();
        return r;
    }
}

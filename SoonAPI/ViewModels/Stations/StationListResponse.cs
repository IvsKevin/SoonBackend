using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class StationListResponse : JsonResponse
{
    public List<Station>? Stations { get; set; }


    public static StationListResponse Get()
    {
        StationListResponse r = new StationListResponse();
        r.Status = 0;
        r.Stations = Station.Get();
        return r;
    }
}

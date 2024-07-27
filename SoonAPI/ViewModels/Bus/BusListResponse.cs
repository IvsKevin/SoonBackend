using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class BusListResponse : JsonResponse
{
    public List<Bus>? Buses { get; set; }


    public static BusListResponse Get()
    {
        BusListResponse r = new BusListResponse();
        r.Status = 0;
        r.Buses = Bus.Get();
        return r;
    }
}

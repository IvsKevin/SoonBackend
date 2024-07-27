using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class DriverListResponse : JsonResponse
{
    public List<Driver>? Drivers { get; set; }


    public static DriverListResponse Get()
    {
        DriverListResponse r = new DriverListResponse();
        r.Status = 0;
        r.Drivers= Driver.Get();
        return r;
    }
}

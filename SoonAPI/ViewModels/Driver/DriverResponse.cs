using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class DriverResponse : JsonResponse
{
    public Driver Driver { get; set; }

    public static DriverResponse Get(Driver b)
    {
        DriverResponse r = new DriverResponse();
        r.Status = 0;
        r.Driver = b;
        return r;
    }
}


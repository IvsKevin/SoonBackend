using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class BusesDistributionResponse : JsonResponse
{
    public BusesDistribution? BusDistribution { get; set; }

    public static BusesDistributionResponse Get(BusesDistribution b)
    {
        BusesDistributionResponse r = new BusesDistributionResponse();
        r.Status = 0;
        r.BusDistribution = b;
        return r;
    }
}


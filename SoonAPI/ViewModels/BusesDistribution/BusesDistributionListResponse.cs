using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class BusesDistributionListResponse : JsonResponse
{
    public List<BusesDistribution> BusesDistributions { get; set; }


    public static BusesDistributionListResponse Get()
    {
        BusesDistributionListResponse r = new BusesDistributionListResponse();
        r.Status = 0;
        r.BusesDistributions= BusesDistribution.Get();
        return r;
    }
}

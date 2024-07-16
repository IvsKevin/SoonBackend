using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class BrandResponse : JsonResponse
{
    public Brand Brand { get; set; }

    public static BrandResponse Get(Brand b)
    {
        BrandResponse r = new BrandResponse();
        r.Status = 0;
        r.Brand = b;
        return r;
    }
}


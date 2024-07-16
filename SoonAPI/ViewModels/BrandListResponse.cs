using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class BrandListResponse : JsonResponse
{
    public List<Brand> Brands { get; set; }


    public static BrandListResponse Get()
    {
        BrandListResponse r = new BrandListResponse();
        r.Status = 0;
        r.Brands = Brand.Get();
        return r;
    }
}

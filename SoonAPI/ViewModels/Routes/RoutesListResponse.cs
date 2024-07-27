using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class RoutesListResponse : JsonResponse
{
    public List<Routes>? Routess { get; set; }


    public static RoutesListResponse Get()
    {
        RoutesListResponse r = new RoutesListResponse();
        r.Status = 0;
        r.Routess = Routes.Get();
        return r;
    }
}

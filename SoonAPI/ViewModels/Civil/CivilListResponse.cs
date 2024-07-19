using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class CivilListResponse : JsonResponse
{
    public List<Civil> Civils { get; set; }


    public static CivilListResponse Get()
    {
        CivilListResponse r = new CivilListResponse();
        r.Status = 0;
        r.Civils = Civil.Get();
        return r;
    }
}

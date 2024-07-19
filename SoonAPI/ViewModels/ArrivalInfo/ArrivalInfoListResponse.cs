using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class ArrivalInfoListResponse : JsonResponse
{
    public List<ArrivalInfo> ArrivalInfos { get; set; }


    public static ArrivalInfoListResponse Get()
    {
        ArrivalInfoListResponse r = new ArrivalInfoListResponse();
        r.Status = 0;
        r.ArrivalInfos = ArrivalInfo.Get();
        return r;
    }
}

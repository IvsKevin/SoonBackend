using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class CivilResponse : JsonResponse
{
    public Civil? Civil { get; set; }

    public static CivilResponse Get(Civil b)
    {
        CivilResponse r = new CivilResponse();
        r.Status = 0;
        r.Civil = b;
        return r;
    }
}


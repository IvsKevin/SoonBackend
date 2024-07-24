using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class CalendarResponse : JsonResponse
{
    public Calendar Calendar { get; set; }

    public static CalendarResponse Get(Calendar b)
    {
        CalendarResponse r = new CalendarResponse();
        r.Status = 0;
        r.Calendar = b;
        return r;
    }
}


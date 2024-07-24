using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class CalendarListResponse : JsonResponse
{
    public List<Calendar> Calendars { get; set; }


    public static CalendarListResponse Get()
    {
        CalendarListResponse r = new CalendarListResponse();
        r.Status = 0;
        r.Calendars = Calendar.Get();
        return r;
    }
}

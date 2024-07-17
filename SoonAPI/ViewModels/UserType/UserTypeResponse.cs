using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class UserTypeResponse : JsonResponse
{
    public UserType UserType { get; set; }

    public static UserTypeResponse Get(UserType b)
    {
        UserTypeResponse r = new UserTypeResponse();
        r.Status = 0;
        r.UserType = b;
        return r;
    }
}


using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class UserTypeListResponse : JsonResponse
{
    public List<UserType>? UserTypes { get; set; }


    public static UserTypeListResponse Get()
    {
        UserTypeListResponse r = new UserTypeListResponse();
        r.Status = 0;
        r.UserTypes = UserType.Get();
        return r;
    }
}

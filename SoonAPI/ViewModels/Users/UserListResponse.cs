using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class UserListResponse : JsonResponse
{
    public List<User> Users { get; set; }


    public static UserListResponse Get()
    {
        UserListResponse r = new UserListResponse();
        r.Status = 0;
        r.Users = User.Get();
        return r;
    }
}

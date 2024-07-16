using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class UserResponse : JsonResponse
{
        public User User { get; set; }

        public static UserResponse Get(User b)
        {
            UserResponse r = new UserResponse();
            r.Status = 0;
            r.User = b;
            return r;
        }
    }


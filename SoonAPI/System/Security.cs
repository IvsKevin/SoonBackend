using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class Security 
{
    public static bool ValidateToken(string username, string token)
    {
        if(username == "sa" && token == "ABC123")
        {
            return true;
        } else
        {
            return false;
        }
    }
}
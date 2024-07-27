using ConsoleApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

public class MessageResponse : JsonResponse
    {
        public string? Message { get; set; }

        public static MessageResponse Get(int status, string message)
        {
            MessageResponse r = new MessageResponse();
            r.Status = status;
            r.Message = message;
            return r;
        }
    }


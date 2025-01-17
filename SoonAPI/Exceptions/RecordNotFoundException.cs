﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Exceptions
{
    internal class RecordNotFoundException : Exception
    {
        private string _message;

        public override string Message => _message;

        public RecordNotFoundException(string table, string id)
        {
            _message = "No se pudo encontrar en " + table + " el id " + id;
        }
    }
}

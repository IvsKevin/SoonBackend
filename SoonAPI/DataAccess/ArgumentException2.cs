using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Exceptions
{
    internal class ArgumentException2 : Exception
    {
        private string _message;

        public override string Message => _message;

        public ArgumentException2(string msg)
        {
            _message = msg;
        }
    }
}

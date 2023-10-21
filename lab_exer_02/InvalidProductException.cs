using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_exer_02
{
    public class InvalidProductException : Exception
    {
        public InvalidProductException() : base() { }
        public InvalidProductException(string message) : base(message) { }
        public InvalidProductException(string message, Exception inner) : base(message, inner) { }
    }

}

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

        public class NumberFormatException : Exception
        {
            public NumberFormatException() : base() { }
            public NumberFormatException(string message) : base(message) { }
            public NumberFormatException(string message, Exception inner) : base(message, inner) { }
        }

        public class StringFormatException : Exception
        {
            public StringFormatException() : base() { }
            public StringFormatException(string message) : base(message) { }
            public StringFormatException(string message, Exception inner) : base(message, inner) { }
        }

        public class CurrencyFormatException : Exception
        {
            public CurrencyFormatException() : base() { }
            public CurrencyFormatException(string message) : base(message) { }
            public CurrencyFormatException(string message, Exception inner) : base(message, inner) { }
        }

    }

}

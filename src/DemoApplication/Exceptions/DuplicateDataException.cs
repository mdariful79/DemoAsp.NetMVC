using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApplication.Exceptions
{
    public class DuplicateDataException : Exception
    {
        public DuplicateDataException(string message) : base(message)
        {
        }
    }
}

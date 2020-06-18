using System;
using System.Collections.Generic;
using System.Text;

namespace MCS.Core
{
    public class UserOperationException : Exception
    {
        public UserOperationException() { }
        public UserOperationException(string message) : base(message) { }
        public UserOperationException(string message, Exception innerException) : base(message, innerException) { }
    }
}

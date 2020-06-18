using System;

namespace MCS.Core
{
    public class CacheRegisterException : MCSException
    {
        public CacheRegisterException() { }

        public CacheRegisterException(string message) : base(message) { }

        public CacheRegisterException(string message, Exception inner) : base(message, inner) { }
    }
}

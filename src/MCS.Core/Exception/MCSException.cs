using System;

namespace MCS.Core
{
    /// <summary>
    /// MZcms 异常
    /// </summary>
    public class MCSException : ApplicationException
    {
        public MCSException() {
            Log.Error(this.Message, this);
        }

        public MCSException(string message) : base(message) {
            Log.Error(message, this);
        }

        public MCSException(string message, Exception inner) : base(message, inner) {
            Log.Error(message, inner);
        }

    }
}

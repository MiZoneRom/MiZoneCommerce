using System;

namespace MiZoneCommerce.Core
{
    public class MiZoneCommerceException : ApplicationException
    {
        public MiZoneCommerceException()
        {
            Log.Error(this.Message, this);
        }

        public MiZoneCommerceException(string message) : base(message)
        {
            Log.Error(message, this);
        }

        public MiZoneCommerceException(string message, Exception inner) : base(message, inner)
        {
            Log.Error(message, inner);
        }
    }
}

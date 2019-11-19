using MiZoneCommerce.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiZoneCommerce.ServiceProvider
{
    public class ServiceInstacnceCreateException : MiZoneCommerceException
    {
        public ServiceInstacnceCreateException() { }

        public ServiceInstacnceCreateException(string message) : base(message) { }

        public ServiceInstacnceCreateException(string message, Exception inner) : base(message, inner) { }
    }
}

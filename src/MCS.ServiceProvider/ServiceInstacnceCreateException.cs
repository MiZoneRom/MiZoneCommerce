using System;

namespace MCS.ServiceProvider
{
    /// <summary>
    /// 服务实例创建异常
    /// </summary>
    public class ServiceInstacnceCreateException : MCS.Core.MCSException
    {
        public ServiceInstacnceCreateException() { }

        public ServiceInstacnceCreateException(string message) : base(message) { }

        public ServiceInstacnceCreateException(string message, Exception inner) : base(message, inner) { }
    }
}

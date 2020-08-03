using MCS.Core;
using MCS.IServices;

namespace MCS.Application
{
    /// <summary>
    /// Applicaion 基类
    /// </summary>
    public class BaseApplicaion
    {
        protected static T GetService<T>() where T:IService
        {
            return ObjectContainer.Current.Resolve<T>();
        }
    }

    public class BaseApplicaion<T> : BaseApplicaion where T : IService
    {
        protected static T Service { get { return GetService<T>(); } }
    }
}

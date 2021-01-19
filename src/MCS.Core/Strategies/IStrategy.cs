
using Microsoft.Extensions.DependencyInjection;

namespace MCS.Core.Strategies
{
    public interface IStrategy
    {
        void Regist(IServiceCollection _services);

    }
}

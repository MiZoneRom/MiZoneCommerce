using Microsoft.AspNetCore.Mvc;

namespace MCS.Core.AccessControlHelper
{
    public interface IResourceAccessStrategy
    {
        /// <summary>
        /// Is resource can be accessed
        /// </summary>
        /// <param name="accessKey">accessKey</param>
        /// <returns></returns>
        bool IsCanAccess(string accessKey);

        /// <summary>
        /// AccessStrategyName
        /// </summary>
        //string StrategyName { get; }

#if NET45
        ActionResult DisallowedCommonResult { get; }

        ActionResult DisallowedAjaxResult { get; }

#else
        IActionResult DisallowedCommonResult { get; }

        IActionResult DisallowedAjaxResult { get; }

#endif
    }
}

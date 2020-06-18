using System;
using System.Collections.Generic;
using System.Text;
using MCS.Core;

namespace MCS.Service
{
    public class ServiceBase
    {
        #region 字段
        private bool _useNoLazyNoProxyContext;
        #endregion

        #region 属性
        protected MCS.Entities.Entities.EntitiesContext Context
        {
            get
            {
                //if (_useNoLazyNoProxyContext)
                //   return this.NoLazyNoProxyContext;
                var name = string.Format("CallContextName:{0}", this.GetHashCode());
                var entities = CallContext.GetData(name) as MZcms.Entity.Entities.EntitiesContext;
                if (entities == null)
                {
                    entities = new EntitiesContext();
                    CallContext.SetData(name, entities);
                }
                return entities;
            }
        }
        /// <summary>
        /// 没有延迟加载，没有代理的上下文
        /// </summary>
        protected MZcms.Entity.Entities.EntitiesContext NoLazyNoProxyContext
        {
            get
            {
                var name = string.Format("NoLazyNoProxyContext:{0}", this.GetHashCode());

                var entities = CallContext.GetData(name) as MZcms.Entity.Entities.EntitiesContext;

                if (entities == null)
                {
                    entities = new EntitiesContext();
                    //entities.Configuration.LazyLoadingEnabled = false;
                    //entities.Configuration.ProxyCreationEnabled = false;
                    CallContext.SetData(name, entities);
                }
                return entities;
            }
        }

        public void Dispose()
        {
        }
        #endregion

    }
}

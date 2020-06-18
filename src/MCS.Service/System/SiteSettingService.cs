using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.MsSql;
using MCS.CommonModel;
using MCS.Core.Helper;
using MCS.Entities;
using MCS.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MCS.Service
{
    public class SiteSettingService : ServiceBase, ISiteSettingService
    {
        public List<SiteSettingsInfo> GetSiteSettings()
        {
            return Context.QuerySet<SiteSettingsInfo>().ToList();
        }

        public void SaveSettings(Dictionary<string, string> settings)
        {
            var keys = settings.Keys.ToList();
            var models = Context.QuerySet<SiteSettingsInfo>().Where(p => keys.Contains(p.Key)).ToList();

            using (Context)
            {
                Context.Open();

                //创建事务对象
                var transaction = Context.BeginTransaction();

                foreach (var item in settings)
                {
                    var model = models.FirstOrDefault(p => p.Key == item.Key);
                    if (model != null)
                    {
                        model.Value = item.Value;
                        Context.CommandSet<SiteSettingsInfo>(transaction).Where(p => p.Key == item.Key).Update(model);
                    }
                    else
                    {
                        Context.CommandSet<SiteSettingsInfo>(transaction).Insert(new SiteSettingsInfo
                        {
                            Key = item.Key,
                            Value = item.Value
                        });
                    }
                }

                transaction.Commit();

            }

        }

    }
}

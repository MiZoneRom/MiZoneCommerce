﻿using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.MsSql;
using MCS.CommonModel;
using MCS.Core.Helper;
using MCS.Entities;
using MCS.IServices;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace MCS.Service
{
    public class SiteSettingService : ServiceBase, ISiteSettingService
    {
        public List<SiteSettingInfo> GetSiteSettings()
        {
            return Context.QuerySet<SiteSettingInfo>().ToList();
        }

        public void SaveSettings(Dictionary<string, string> settings)
        {
            var keys = settings.Keys.ToList();
            var models = Context.QuerySet<SiteSettingInfo>().Where(p => keys.Contains(p.Key)).ToList();

            using (var conn = new SqlConnection(ConnectionString))
            {

                conn.Open();

                //创建事务对象
                var transaction = conn.BeginTransaction();

                foreach (var item in settings)
                {
                    var model = models.FirstOrDefault(p => p.Key == item.Key);
                    if (model != null)
                    {
                        model.Value = item.Value;
                        conn.CommandSet<SiteSettingInfo>(transaction).Where(p => p.Key == item.Key).Update(model);
                    }
                    else
                    {
                        conn.CommandSet<SiteSettingInfo>(transaction).Insert(new SiteSettingInfo
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

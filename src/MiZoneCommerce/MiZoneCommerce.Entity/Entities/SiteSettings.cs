using MiZoneCommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiZoneCommerce.Entity.Entities
{
    /// <summary>
    /// 站点设置
    /// </summary>
    public class SiteSettings:BaseModel
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

using MiZoneCommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiZoneCommerce.Entity.Entities
{
    public class SiteSettings:BaseModel
    {
        public long Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}

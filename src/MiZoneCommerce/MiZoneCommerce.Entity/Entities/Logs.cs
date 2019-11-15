using MiZoneCommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiZoneCommerce.Entity.Entities
{
    public class Logs : BaseModel
    {
        public long Id { get; set; }
        public string PageUrl { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public string Description { get; set; }
    }
}

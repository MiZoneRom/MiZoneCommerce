
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.SiteSetting")]
     public partial class SiteSettingInfo
     {
        
        		public long Id {get;set;}
        		public string Key {get;set;}
        		public string Value {get;set;}
        
     }

}


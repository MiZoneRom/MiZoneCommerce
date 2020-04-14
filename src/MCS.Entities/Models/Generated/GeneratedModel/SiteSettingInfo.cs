
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.SiteSetting")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class SiteSettingInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public string Key {get;set;}
        [Column] public string Value {get;set;}
        
     }

}


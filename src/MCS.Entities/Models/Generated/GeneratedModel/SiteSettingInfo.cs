
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
        
        
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "Key",  isColumn: true)]
		public string Key {get;set;}

        
		[Column(name: "Value",  isColumn: true)]
		public string Value {get;set;}

        
     }

}


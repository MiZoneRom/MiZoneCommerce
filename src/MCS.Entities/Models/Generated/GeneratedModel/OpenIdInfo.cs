
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.OpenId")]
     public partial class OpenIdInfo
     {
        
        		public long Id {get;set;}
        		public string OpenId {get;set;}
        		public DateTime SubscribeTime {get;set;}
        		public bool IsSubscribe {get;set;}
        
     }

}


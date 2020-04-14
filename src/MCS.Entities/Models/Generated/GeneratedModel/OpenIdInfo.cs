
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.OpenId")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class OpenIdInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public string OpenId {get;set;}
        [Column] public DateTime SubscribeTime {get;set;}
        [Column] public bool IsSubscribe {get;set;}
        
     }

}


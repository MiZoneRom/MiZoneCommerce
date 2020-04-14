
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberOpenId")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberOpenIdInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public string OpenId {get;set;}
        [Column] public string UnionOpenId {get;set;}
        [Column] public string UnionId {get;set;}
        [Column] public string ServiceProvider {get;set;}
        [Column] public int AppIdType {get;set;}
        
     }

}


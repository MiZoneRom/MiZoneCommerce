
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberIntegral")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberIntegralInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public string UserName {get;set;}
        [Column] public int HistoryIntegrals {get;set;}
        [Column] public int AvailableIntegrals {get;set;}
        
     }

}


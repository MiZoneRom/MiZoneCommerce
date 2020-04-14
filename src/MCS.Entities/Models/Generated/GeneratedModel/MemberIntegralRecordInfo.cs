
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberIntegralRecord")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberIntegralRecordInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public string UserName {get;set;}
        [Column] public int TypeId {get;set;}
        [Column] public int Integral {get;set;}
        [Column] public DateTime CreateDate {get;set;}
        [Column] public string Remark {get;set;}
        
     }

}


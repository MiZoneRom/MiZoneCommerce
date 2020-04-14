
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberActivityDegree")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberActivityDegreeInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public long UserId {get;set;}
        [Column] public bool OneMonth {get;set;}
        [Column] public bool ThreeMonth {get;set;}
        [Column] public bool SixMonth {get;set;}
        [Column] public DateTime? OneMonthEffectiveTime {get;set;}
        [Column] public DateTime? ThreeMonthEffectiveTime {get;set;}
        [Column] public DateTime? SixMonthEffectiveTime {get;set;}
        
     }

}


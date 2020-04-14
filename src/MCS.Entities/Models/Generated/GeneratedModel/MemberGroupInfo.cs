
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberGroup")]
     [PrimaryKey("Id")]
     [ExplicitColumns]
     public partial class MemberGroupInfo
     {
        
        [Column] public long Id {get;set;}
        [Column] public int StatisticsType {get;set;}
        [Column] public int Total {get;set;}
        
     }

}


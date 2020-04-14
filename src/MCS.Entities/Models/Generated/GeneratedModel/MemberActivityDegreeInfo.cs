
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberActivityDegree")]
     public partial class MemberActivityDegreeInfo
     {
        
        		public long Id {get;set;}
        		public long UserId {get;set;}
        		public bool OneMonth {get;set;}
        		public bool ThreeMonth {get;set;}
        		public bool SixMonth {get;set;}
        		public DateTime? OneMonthEffectiveTime {get;set;}
        		public DateTime? ThreeMonthEffectiveTime {get;set;}
        		public DateTime? SixMonthEffectiveTime {get;set;}
        
     }

}


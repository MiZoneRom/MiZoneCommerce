
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
        
        
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "UserId",  isColumn: true)]
		public long UserId {get;set;}

        
		[Column(name: "OneMonth",  isColumn: true)]
		public bool OneMonth {get;set;}

        
		[Column(name: "ThreeMonth",  isColumn: true)]
		public bool ThreeMonth {get;set;}

        
		[Column(name: "SixMonth",  isColumn: true)]
		public bool SixMonth {get;set;}

        
		[Column(name: "OneMonthEffectiveTime",  isColumn: true)]
		public DateTime? OneMonthEffectiveTime {get;set;}

        
		[Column(name: "ThreeMonthEffectiveTime",  isColumn: true)]
		public DateTime? ThreeMonthEffectiveTime {get;set;}

        
		[Column(name: "SixMonthEffectiveTime",  isColumn: true)]
		public DateTime? SixMonthEffectiveTime {get;set;}

        
     }

}


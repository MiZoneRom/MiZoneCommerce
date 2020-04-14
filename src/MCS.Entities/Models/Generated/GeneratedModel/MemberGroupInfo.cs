
using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Dapper.Common;

namespace MCS.Entities
{
    
     [Table("dbo.MemberGroup")]
     public partial class MemberGroupInfo
     {
        
        
		[Column(name: "Id",key: ColumnKey.Primary,  isColumn: true)]
		public long Id {get;set;}

        
		[Column(name: "StatisticsType",  isColumn: true)]
		public int StatisticsType {get;set;}

        
		[Column(name: "Total",  isColumn: true)]
		public int Total {get;set;}

        
     }

}



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
        
        
		/// <summary>
        /// Id
        /// </summary>
		[Column(name: "Id",key: ColumnKey.Primary, isIdentity: true, isColumn: true)]
		public long Id { get; set; }

        
		/// <summary>
        /// StatisticsType
        /// </summary>
		[Column(name: "StatisticsType",  isColumn: true)]
		public int StatisticsType { get; set; }

        
		/// <summary>
        /// Total
        /// </summary>
		[Column(name: "Total",  isColumn: true)]
		public int Total { get; set; }

        
     }

}


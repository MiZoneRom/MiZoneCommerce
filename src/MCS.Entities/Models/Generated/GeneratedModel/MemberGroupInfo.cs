
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.MemberGroup")]
     public partial class MemberGroupInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// StatisticsType
        /// </summary>
		
		[Required]
		[Column("StatisticsType")]
		public int StatisticsType { get; set; }
        
		/// <summary>
        /// Total
        /// </summary>
		
		[Required]
		[Column("Total")]
		public int Total { get; set; }
        
     }

}


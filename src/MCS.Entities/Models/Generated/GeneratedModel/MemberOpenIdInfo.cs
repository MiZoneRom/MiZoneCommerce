
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.MemberOpenId")]
     public partial class MemberOpenIdInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// UserId
        /// </summary>
		
		[Required]
		[Column("UserId")]
		public long UserId { get; set; }
        
		/// <summary>
        /// OpenId
        /// </summary>
		
		
		[Column("OpenId")]
		public string OpenId { get; set; }
        
		/// <summary>
        /// UnionOpenId
        /// </summary>
		
		
		[Column("UnionOpenId")]
		public string UnionOpenId { get; set; }
        
		/// <summary>
        /// UnionId
        /// </summary>
		
		
		[Column("UnionId")]
		public string UnionId { get; set; }
        
		/// <summary>
        /// ServiceProvider
        /// </summary>
		
		[Required]
		[Column("ServiceProvider")]
		public string ServiceProvider { get; set; }
        
		/// <summary>
        /// AppIdType
        /// </summary>
		
		[Required]
		[Column("AppIdType")]
		public int AppIdType { get; set; }
        
     }

}


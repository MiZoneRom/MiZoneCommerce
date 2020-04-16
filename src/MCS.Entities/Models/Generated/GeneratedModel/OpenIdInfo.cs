
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.OpenId")]
     public partial class OpenIdInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Key]
		[Required]
		[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// OpenId
        /// </summary>
		
		[Required]
		[Column("OpenId")]
		public string OpenId { get; set; }
        
		/// <summary>
        /// SubscribeTime
        /// </summary>
		
		[Required]
		[Column("SubscribeTime")]
		public DateTime SubscribeTime { get; set; }
        
		/// <summary>
        /// IsSubscribe
        /// </summary>
		
		[Required]
		[Column("IsSubscribe")]
		public bool IsSubscribe { get; set; }
        
     }

}


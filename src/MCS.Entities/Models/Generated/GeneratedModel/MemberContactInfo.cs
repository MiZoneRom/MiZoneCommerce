
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dapper;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Table("dbo.MemberContact")]
     public partial class MemberContactInfo:IModel
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
        /// UserType
        /// </summary>
		
		[Required]
		[Column("UserType")]
		public int UserType { get; set; }
        
		/// <summary>
        /// ServiceProvider
        /// </summary>
		
		[Required]
		[Column("ServiceProvider")]
		public string ServiceProvider { get; set; }
        
		/// <summary>
        /// Contact
        /// </summary>
		
		[Required]
		[Column("Contact")]
		public string Contact { get; set; }
        
     }

}


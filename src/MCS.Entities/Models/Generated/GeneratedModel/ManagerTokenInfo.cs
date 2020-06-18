
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "ManagerToken")]
     public partial class ManagerTokenInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity]
		//[Required]
		//[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// UserId
        /// </summary>
		
		//[Required]
		//[Column("UserId")]
		public long UserId { get; set; }
        
		/// <summary>
        /// Token
        /// </summary>
		
		//[Required]
		//[Column("Token")]
		public string Token { get; set; }
        
		/// <summary>
        /// RefreshToken
        /// </summary>
		
		//[Required]
		//[Column("RefreshToken")]
		public string RefreshToken { get; set; }
        
		/// <summary>
        /// Expires
        /// </summary>
		
		//[Required]
		//[Column("Expires")]
		public DateTime Expires { get; set; }
        
     }

}


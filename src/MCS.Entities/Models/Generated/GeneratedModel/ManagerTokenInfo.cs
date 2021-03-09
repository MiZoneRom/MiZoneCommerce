
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "ManagerToken")]
     public partial class ManagerTokenInfo:IBaseEntity<ManagerInfo, long>, IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// UserId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "UserId")]
		public long UserId { get; set; }
        
		/// <summary>
        /// Token
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Token")]
		public string Token { get; set; }
        
		/// <summary>
        /// RefreshToken
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "RefreshToken")]
		public string RefreshToken { get; set; }
        
		/// <summary>
        /// Expires
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Expires")]
		public DateTime Expires { get; set; }
        
     }

}


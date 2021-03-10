
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
     public partial class ManagerTokenInfo:IBaseEntity<ManagerTokenInfo, long>
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public override long Id { get; set; }
        
		/// <summary>
        /// ManagerId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "ManagerId")]
		public  long ManagerId { get; set; }
        
		/// <summary>
        /// Token
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Token")]
		public  string Token { get; set; }
        
		/// <summary>
        /// RefreshToken
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "RefreshToken")]
		public  string RefreshToken { get; set; }
        
		/// <summary>
        /// Expires
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Expires")]
		public  DateTime Expires { get; set; }
        
     }

}


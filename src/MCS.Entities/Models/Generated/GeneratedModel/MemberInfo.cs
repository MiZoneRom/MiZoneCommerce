
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "Member")]
     public partial class MemberInfo:IBaseEntity<MemberInfo, long>
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public override long Id { get; set; }
        
		/// <summary>
        /// UserName
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "UserName")]
		public  string UserName { get; set; }
        
     }

}



using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "NavigationAction")]
     public partial class NavigationActionInfo:IBaseEntity<NavigationActionInfo, long>
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public override long Id { get; set; }
        
		/// <summary>
        /// NavId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "NavId")]
		public  long NavId { get; set; }
        
		/// <summary>
        /// Name
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
		public  string Name { get; set; }
        
		/// <summary>
        /// AccessKey
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "AccessKey")]
		public  string AccessKey { get; set; }
        
     }

}


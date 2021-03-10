
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "ManagerNavigationAction")]
     public partial class ManagerNavigationActionInfo:IBaseEntity<ManagerNavigationActionInfo, long>
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public override long Id { get; set; }
        
		/// <summary>
        /// NavigationId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "NavigationId")]
		public  long NavigationId { get; set; }
        
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


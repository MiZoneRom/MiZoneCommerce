
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "ManagerGroup")]
     public partial class ManagerGroupInfo:IBaseEntity<ManagerGroupInfo, long>
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public override long Id { get; set; }
        
		/// <summary>
        /// Name
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
		public  string Name { get; set; }
        
		/// <summary>
        /// ParentId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "ParentId")]
		public  long ParentId { get; set; }
        
		/// <summary>
        /// CreateTime
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "CreateTime")]
		public  DateTime CreateTime { get; set; }
        
     }

}



using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "ManagerNavigation")]
     public partial class ManagerNavigationInfo:IBaseEntity<ManagerNavigationInfo, long>
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "Id")]
		public override long Id { get; set; }
        
		/// <summary>
        /// ParentId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "ParentId")]
		public  long ParentId { get; set; }
        
		/// <summary>
        /// Name
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
		public  string Name { get; set; }
        
		/// <summary>
        /// SubTitle
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "SubTitle")]
		public  string SubTitle { get; set; }
        
		/// <summary>
        /// Icon
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Icon")]
		public  string Icon { get; set; }
        
		/// <summary>
        /// Component
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Component")]
		public  string Component { get; set; }
        
		/// <summary>
        /// Path
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Path")]
		public  string Path { get; set; }
        
		/// <summary>
        /// PathType
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "PathType")]
		public  int? PathType { get; set; }
        
		/// <summary>
        /// SortId
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "SortId")]
		public  int SortId { get; set; }
        
		/// <summary>
        /// Status
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Status")]
		public  int Status { get; set; }
        
		/// <summary>
        /// Remark
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "Remark")]
		public  string Remark { get; set; }
        
     }

}


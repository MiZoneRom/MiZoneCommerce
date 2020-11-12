
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Kogel.Dapper.Extension.Attributes;
using MCS.CommonModel;

namespace MCS.Entities
{
    
     [Display(Rename = "Navigation")]
     public partial class NavigationInfo:IModel
     {
        
		/// <summary>
        /// Id
        /// </summary>
		[Identity]
		//[Required]
		//[Column("Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// ParentId
        /// </summary>
		
		//[Required]
		//[Column("ParentId")]
		public long ParentId { get; set; }
        
		/// <summary>
        /// Type
        /// </summary>
		
		//
		//[Column("Type")]
		public int? Type { get; set; }
        
		/// <summary>
        /// Name
        /// </summary>
		
		//
		//[Column("Name")]
		public string Name { get; set; }
        
		/// <summary>
        /// Title
        /// </summary>
		
		//[Required]
		//[Column("Title")]
		public string Title { get; set; }
        
		/// <summary>
        /// SubTitle
        /// </summary>
		
		//
		//[Column("SubTitle")]
		public string SubTitle { get; set; }
        
		/// <summary>
        /// Icon
        /// </summary>
		
		//
		//[Column("Icon")]
		public string Icon { get; set; }
        
		/// <summary>
        /// Link
        /// </summary>
		
		//
		//[Column("Link")]
		public string Link { get; set; }
        
		/// <summary>
        /// SortId
        /// </summary>
		
		//[Required]
		//[Column("SortId")]
		public int SortId { get; set; }
        
		/// <summary>
        /// IsLock
        /// </summary>
		
		//[Required]
		//[Column("IsLock")]
		public bool IsLock { get; set; }
        
		/// <summary>
        /// Remark
        /// </summary>
		
		//
		//[Column("Remark")]
		public string Remark { get; set; }
        
		/// <summary>
        /// ActionType
        /// </summary>
		
		//[Required]
		//[Column("ActionType")]
		public int ActionType { get; set; }
        
		/// <summary>
        /// IsSys
        /// </summary>
		
		//[Required]
		//[Column("IsSys")]
		public bool IsSys { get; set; }
        
		/// <summary>
        /// IsHidden
        /// </summary>
		
		//[Required]
		//[Column("IsHidden")]
		public bool IsHidden { get; set; }
        
     }

}


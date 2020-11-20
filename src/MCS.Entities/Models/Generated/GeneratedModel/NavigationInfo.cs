
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
        /// 父级导航ID
        /// </summary>
		
		//[Required]
		//[Column("ParentId")]
		public long ParentId { get; set; }
        
		/// <summary>
        /// 导航类型
        /// </summary>
		
		//
		//[Column("Type")]
		public int? Type { get; set; }
        
		/// <summary>
        /// 导航名称
        /// </summary>
		
		//
		//[Column("Name")]
		public string Name { get; set; }
        
		/// <summary>
        /// 副标题
        /// </summary>
		
		//
		//[Column("SubTitle")]
		public string SubTitle { get; set; }
        
		/// <summary>
        /// 图标
        /// </summary>
		
		//
		//[Column("Icon")]
		public string Icon { get; set; }
        
		/// <summary>
        /// 路径
        /// </summary>
		
		//
		//[Column("Path")]
		public string Path { get; set; }
        
		/// <summary>
        /// 路径类型
        /// </summary>
		
		//[Required]
		//[Column("PathType")]
		public int PathType { get; set; }
        
		/// <summary>
        /// 模块
        /// </summary>
		
		//
		//[Column("Component")]
		public string Component { get; set; }
        
		/// <summary>
        /// 排序Id
        /// </summary>
		
		//[Required]
		//[Column("SortId")]
		public int SortId { get; set; }
        
		/// <summary>
        /// 状态
        /// </summary>
		
		//[Required]
		//[Column("Status")]
		public int Status { get; set; }
        
		/// <summary>
        /// 备注
        /// </summary>
		
		//
		//[Column("Remark")]
		public string Remark { get; set; }
        
     }

}


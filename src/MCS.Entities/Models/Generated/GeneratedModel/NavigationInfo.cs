
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
        /// 导航Id
        /// </summary>
		[Identity(IsIncrease =true)]
        [System.ComponentModel.DataAnnotations.Display(Name = "导航Id")]
		public long Id { get; set; }
        
		/// <summary>
        /// 父级导航ID
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "父级导航ID")]
		public long ParentId { get; set; }
        
		/// <summary>
        /// 导航名称
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "导航名称")]
		public string Name { get; set; }
        
		/// <summary>
        /// 副标题
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "副标题")]
		public string SubTitle { get; set; }
        
		/// <summary>
        /// 图标
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "图标")]
		public string Icon { get; set; }
        
		/// <summary>
        /// 导航类型
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "导航类型")]
		public NavigationType NavType { get; set; }
        
		/// <summary>
        /// 区域
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "区域")]
		public string Areas { get; set; }
        
		/// <summary>
        /// 控制器
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "控制器")]
		public string Controllers { get; set; }
        
		/// <summary>
        /// 视图
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "视图")]
		public string Views { get; set; }
        
		/// <summary>
        /// 模块（VUE使用）
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "模块（VUE使用）")]
		public string Component { get; set; }
        
		/// <summary>
        /// 路径
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "路径")]
		public string Path { get; set; }
        
		/// <summary>
        /// 路径类型（本页面，新标签页）
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "路径类型（本页面，新标签页）")]
		public int PathType { get; set; }
        
		/// <summary>
        /// 排序Id
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "排序Id")]
		public int SortId { get; set; }
        
		/// <summary>
        /// 状态
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "状态")]
		public int Status { get; set; }
        
		/// <summary>
        /// 备注
        /// </summary>
		
        [System.ComponentModel.DataAnnotations.Display(Name = "备注")]
		public string Remark { get; set; }
        
     }

}


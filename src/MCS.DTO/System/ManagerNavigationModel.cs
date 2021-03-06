﻿using MCS.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MCS.DTO
{
    public class ManagerNavigationModel
    {

        /// <summary>
        /// 导航Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 父级导航ID
        /// </summary>
        [Display(Name = "父级导航")]
        public long ParentId { get; set; }

        /// <summary>
        /// 导航名称
        /// </summary>
        [Display(Name = "导航名称")]
        [Required(ErrorMessage = "导航名称必填")]
        [StringLength(15, ErrorMessage = "字符长度不能超过15个字")]
        public string Name { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        [Display(Name = "副标题")]
        public string SubTitle { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Display(Name = "图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 模块（VUE使用）
        /// </summary>
        [Display(Name = "模块")]
        public string Component { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        [Display(Name = "路径")]
        public string Path { get; set; }

        /// <summary>
        /// 路径类型（本页面，新标签页）
        /// </summary>
        [Display(Name = "路径类型")]
        public int PathType { get; set; }

        /// <summary>
        /// 排序Id
        /// </summary>
        [Display(Name = "排序Id")]
        public int SortId { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Display(Name = "状态")]
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        public bool IsOpen { get; set; }

        /// <summary>
        /// 层级
        /// </summary>
        public int ClassLayer { get; set; }

        /// <summary>
        /// 子项
        /// </summary>
        public List<ManagerNavigationModel> Children { get; set; }

        /// <summary>
        /// 父级
        /// </summary>
        [Display(Name = "父级")]
        public ManagerNavigationModel Parent { get; set; }

        /// <summary>
        /// 操作类型
        /// </summary>
        [Display(Name = "操作")]
        public List<ManagerNavigationActionModel> Actions { get; set; }

        /// <summary>
        /// 操作Id
        /// </summary>
        [Display(Name = "操作")]
        public List<long> ActionIds { get; set; }

    }
}

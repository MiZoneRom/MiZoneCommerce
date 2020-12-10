using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MCS.CommonModel
{
    /// <summary>
    /// 统一管理操作枚举
    /// </summary>
    public enum NavigationAction
    {
        /// <summary>
        /// 显示
        /// </summary>
        [Description("显示")]
        Show = 2,
        /// <summary>
        /// 查看
        /// </summary>
        [Description("查看")]
        View = 3,
        /// <summary>
        /// 添加
        /// </summary>
        [Description("添加")]
        Add = 4,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Edit = 5,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete = 6,
        /// <summary>
        /// 审核
        /// </summary>
        [Description("审核")]
        Audit = 7,
        /// <summary>
        /// 回复
        /// </summary>
        [Description("回复")]
        Reply = 8,
        /// <summary>
        /// 确认
        /// </summary>
        [Description("确认")]
        Confirm = 9,
        /// <summary>
        /// 取消
        /// </summary>
        [Description("取消")]
        Cancel = 10,
        /// <summary>
        /// 作废
        /// </summary>
        [Description("作废")]
        Invalid = 11,
        /// <summary>
        /// 生成
        /// </summary>
        [Description("生成")]
        Build = 12,
        /// <summary>
        /// 安装
        /// </summary>
        [Description("安装")]
        Instal = 13,
        /// <summary>
        /// 卸载
        /// </summary>
        [Description("卸载")]
        UnLoad = 14,
        /// <summary>
        /// 登录
        /// </summary>
        [Description("登录")]
        Login = 15,
        /// <summary>
        /// 备份
        /// </summary>
        [Description("备份")]
        Back = 16,
        /// <summary>
        /// 还原
        /// </summary>
        [Description("还原")]
        Restore = 17,
        /// <summary>
        /// 替换
        /// </summary>
        [Description("替换")]
        Replace = 18,
        /// <summary>
        /// 复制
        /// </summary>
        [Description("复制")]
        Copy = 19
    }
}

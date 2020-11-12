using System.ComponentModel.DataAnnotations;

namespace MCS.Web.Areas.Admin.Models.Manage
{
    public class ManageLoginModel
    {
        [Display(Name = "登录账号")]
        [Required(ErrorMessage = "登录账号必填")]
        [StringLength(15, ErrorMessage = "字符长度不能超过15个字")]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "登录密码必填")]
        [StringLength(15, ErrorMessage = "字符长度不能超过15个字")]
        public string Password { get; set; }
    }
}

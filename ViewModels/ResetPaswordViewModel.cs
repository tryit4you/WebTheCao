using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage ="Yêu cầu nhập tên tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Yêu cầu nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Mật khẩu xác thực không được trống")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Mật khẩu xác thực không trùng khớp")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Token { get; set; }
    }
}

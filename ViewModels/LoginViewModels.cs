using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.ViewModels
{
    public class LoginViewModels
    {
        [Required(ErrorMessage ="Yêu cầu nhập tên đăng nhập")]
        [DisplayName("Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Yêu cầu nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string  Email { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

    }
}

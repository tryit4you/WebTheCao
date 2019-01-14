using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTheCao.Areas.Admin.ViewModels;
using WebTheCao.Data.Models;

namespace WebTheCao.Areas.Admin.Components
{
    public class UserRegisterViewComponent:ViewComponent
    {
        private UserManager<ApplicationUser> _userManager;
        public UserRegisterViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var data = _userManager.Users.
                Where(x => x.CreatedDate.Subtract(DateTime.Now).Days == 0&&x.ViewStatus==false).ToList();
            var userRegisterVm = new UserRegiterViewModels
            {
                Users = data
            };
            return View(userRegisterVm);
        }
    }
}

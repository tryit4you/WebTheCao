using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebTheCao.Data.Models;

namespace WebTheCao.Components
{
    public class headerViewComponent:ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public headerViewComponent(UserManager<ApplicationUser> userManager) 
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            var user = _userManager.Users.FirstOrDefault(x=>x.UserName==userName);
            if (user != null)
            {
                return View(user);
            }
            return View();
        }
    }
}

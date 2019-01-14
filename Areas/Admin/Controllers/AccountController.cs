using WebTheCao.Data.Models;
using WebTheCao.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebTheCao.SharedComponents;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    //phần này là tài khoản
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IPasswordValidator<ApplicationUser> _passwordValidator;
        private readonly IUserValidator<ApplicationUser> _userValidator;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IPasswordValidator<ApplicationUser> passwordValidator,
            IUserValidator<ApplicationUser> userValidator,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordValidator = passwordValidator;
            _userValidator = userValidator;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrator")]
        public IActionResult GetData(string filter, int page, int pageSize = 10)
        {
            var totalRows = 0;
            var users = _userManager.Users.OrderByDescending(x => x.CreatedDate).ToList();

            totalRows = users.Count;
            if (!string.IsNullOrEmpty(filter))
            {
                users = users.Where(p => p.UserName.ToLower().Contains(filter)).ToList();
                totalRows = users.Count();
            }

            var model = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Ok(new
            {
                data = model,
                total = totalRows,
                status = true
            });
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModels()
            {
                ReturnUrl = returnUrl
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModels loginViewModels)
        {
            if (!ModelState.IsValid)
                return View(loginViewModels);
            var user = await _userManager.FindByNameAsync(loginViewModels.UserName);

            if (user != null)
            {
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModels.Password, loginViewModels.RememberMe, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginViewModels.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home", "Admin");
                    }
                    return Redirect(loginViewModels.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View(loginViewModels);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create(string models, string password)
        {
            var data = JsonConvert.DeserializeObject<ApplicationUser>(models);
            List<string> errors = new List<string>();
            ApplicationUser user = new ApplicationUser
            {
                UserName = data.UserName,
                Email = data.Email,
                DisplayName = data.DisplayName,
                Sdt = data.Sdt,
                CreatedDate = DateTime.Now,
                Status = true,
                EmailConfirmed = true
            };
            IdentityResult result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return Json(new
                {
                    status = true,
                    message="Tạo tài khoản thành công!"
                });
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    errors.Add(error.Description);
                }
                return Json(new
                {
                    status = false,
                    data = errors
                });
            }

        }
        [Authorize(Roles = "Administrator")]
        public IActionResult getDetail(string id)
        {
            var data = _userManager.Users.FirstOrDefault(x => x.Id == id);

            return Json(new
            {
                status = true,
                data = data
            });
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/login");
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            List<string> errors = new List<string>();
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return Json(new
                    {
                        status = true,
                        message = ResultState.Delete_SUCCESS
                    });
                }
                else 
                {
                    foreach (var  err in result.Errors)
                    {
                        errors.Add(err.Description);
                    }

                    return Json(new
                    {
                        status = false,
                        errors = errors
                    });
                }
            }
            else
            {
                errors.Add("Không tìm thấy tài khoản!");
                return Json(new
                {
                    status = false,
                    errors=errors
                });

            }


        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> update(string models, string password)
        {
            List<string> errors = new List<string>();

            var data = JsonConvert.DeserializeObject<ApplicationUser>(models);
            ApplicationUser user = await _userManager.FindByIdAsync(data.Id);
            if (user != null)
            {
                
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        foreach (var error in validPass.Errors) 
                        {
                            errors.Add(error.Description);
                        }
                    }
                }
                if ((validPass == null)
                || ( password != string.Empty && validPass.Succeeded))
                {
                    user.Sdt = data.Sdt;
                    user.DisplayName = data.DisplayName;
                    user.UserName = data.UserName;
                    user.Email = data.Email;
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return Json(new
                        {
                            status = true,
                            message = ResultState.Update_SUCCESS
                        });
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            errors.Add(error.Description);
                        }
                    }
                }
            }
            else
            {
                errors.Add("Không tìm thấy tài khoản");
            }
            return Json(new
            {
                status = false,
                errors=errors
            });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangeStatus(string id)
        {
            List<string> errors = new List<string>();
            bool status;
            string message = string.Empty;
            var user = _userManager.Users.Where(x => x.Id == id).SingleOrDefault();
            if (user == null)
            {
                status = false;
                message = ResultState.NotFound;
            }
            else
            {
                user.Status = !user.Status;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Json(new
                    {
                        status = true,
                        message = ResultState.Update_SUCCESS
                    });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        errors.Add(error.Description);
                    }
                }
                status = user.Status;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ActiveEmail(string id)
        {
            List<string> errors = new List<string>();
            bool status;
            string message = string.Empty;
            var user = _userManager.Users.Where(x => x.Id == id).SingleOrDefault();
            if (user == null)
            {
                status = false;
                message = ResultState.NotFound;
            }
            else
            {
                user.EmailConfirmed = true;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Json(new
                    {
                        status = true,
                        message = ResultState.Update_SUCCESS
                    });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        errors.Add(error.Description);
                    }
                }
                status = user.Status;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }
        [HttpPost]
        public async Task<IActionResult> MakeAllRead()
        {
            bool status;
            try
            {

                foreach (var item in _userManager.Users.Where(x => x.ViewStatus == false))
                {
                    item.ViewStatus = true;
                    await _userManager.UpdateAsync(item);
                }
          
                status = true;

            }
            catch
            {
                status = false;
            }
            return Json(new
            {
                status = status
            });
        }

        public IActionResult MakeItemRead(string id)
        {
            var status = false;
            var user = _userManager.Users.FirstOrDefault(x=>x.Id==id);
            if (user == null)
            {
                status = false;
            }
            else
            {
                user.ViewStatus = true;
                _userManager.UpdateAsync(user);
                status = true;
            }
            return Json(new
            {
                status = status
            });
        }
    }
}
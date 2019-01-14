using WebTheCao.Data.Models;
using WebTheCao.Services;
using WebTheCao.SharedComponents;
using WebTheCao.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTheCao.Data.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace WebTheCao.Controllers
{
    [Route("[controller]/[action]")]
    public class UserAccountController : Controller
    {

        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _signInManager;
        private INopCardRepository _NopCardRepository;
        private IGiaoDichRepository _giaoDichRepository;
        private ITKNHRepository _tknhRepository;
        private IMenhGiaRepository _menhgiaRepository;
        private ICardRepository _cardRepository;
        public UserAccountController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            INopCardRepository NopCardRepository,
            IGiaoDichRepository giaoDichRepository,
            ITKNHRepository tknhRepository,
            ICardRepository cardRepository,
            IMenhGiaRepository menhgiaRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _NopCardRepository = NopCardRepository;
            _giaoDichRepository = giaoDichRepository;
            _tknhRepository = tknhRepository;
            _menhgiaRepository = menhgiaRepository;
            _cardRepository = cardRepository;
        }

        [Route("/tai-khoan/{id?}")]
        [Authorize]
        public async Task<IActionResult> Profile(string id)
        {

            var infor = await _userManager.FindByIdAsync(id);
            return View(infor);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string userName, string password, bool rememberMe)
        {
            string message = string.Empty;
            bool status = false;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                message = "Tên đăng nhập hoặc mật khẩu không được để trống";
                return Json(new
                {
                    message = message,
                    status = status
                });
            }
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                if (user.Status == false)
                {
                    if (user.Status == false)
                    {
                        return Json(new
                        {
                            message = "Tài khoản đã bị khóa bởi quản trị viên vì một lý do nào đó!",
                            status = false
                        });
                    }
                }
                else
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
                    if (result.Succeeded)
                    {
                        return Json(new
                        {
                            message = "Đăng nhập thành công",
                            status = true
                        });
                    }
                    else if (result.IsNotAllowed)
                    {
                        return Json(new
                        {
                            message = "Tài khoản chưa được kích hoạt. Hãy kiểm tra email để kích hoạt tài khoản",
                            status = false
                        });
                    }

                }
            }
            message = "Tên đăng nhập hoặc mật khẩu không đúng.";
            return Json(new
            {
                message = message,
                status = status
            });
        }
        [Route("/login")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (returnUrl != "")
            {

                return View(new LoginViewModels()
                {
                    ReturnUrl = returnUrl
                });
            }
            else
            {
                return Redirect("/admin/home/index");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/login")]
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
                        return View();
                    }
                    else if (result.IsNotAllowed)
                    {
                        return Json(new
                        {
                            message = "Tài khoản chưa được kích hoạt. Hãy kiểm tra email để kích hoạt tài khoản",
                            status = false
                        });
                    }
                    return Redirect(loginViewModels.ReturnUrl);
                }
            }
            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View(loginViewModels);
        }


        public IActionResult GoogleSignIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" });
        }

        [HttpPost]
        [Route("/UserAccount/SendPasswordResetLink")]
        public JsonResult SendPasswordResetLink(string email)
        {
            string message = string.Empty;
            var user = _userManager.FindByEmailAsync(email).Result;

            if (user == null || !(_userManager.IsEmailConfirmedAsync(user).Result))
            {
                message = "Không tồn tại email hoặc tài khoản không được xác minh!";
                return Json(new
                {
                    status = false,
                    message = message
                });
            }

            var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;

            var resetLink = Url.Action("ResetPassword",
                            "UserAccount", new { token = token },
                             protocol: HttpContext.Request.Scheme);


            try
            {
                EmailSender.SendMail(user.Email, resetLink);
                message = "Đường dẫn khôi phục mật khẩu đã được gởi đến email!";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            return Json(new
            {
                status = true,
                message = message
            });
        }

        public IActionResult ResetPassword(string token)
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel obj)
        {
            if (ModelState.IsValid)
            {

                var user = _userManager.
                             FindByNameAsync(obj.UserName).Result;

                IdentityResult result = _userManager.ResetPasswordAsync
                          (user, obj.Token, obj.Password).Result;
                if (result.Succeeded)
                {
                    ViewBag.Message = "Khôi phục mật khẩu thành công!";
                    return View();
                }
                else
                {
                    ViewBag.Message = "Lỗi khôi phục! Hãy chắc chắn là bạn nhập đúng tên tài khoản";
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Vui lòng điền đầy đủ thông tin!");
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Register(string models)
        {
            var status = false;
            string message = string.Empty;
            string notifi = string.Empty;
            var data = JsonConvert.DeserializeObject<LoginViewModels>(models);
            List<string> errorMessasge = new List<string>();
            ApplicationUser user = new ApplicationUser
            {
                UserName = data.UserName,
                Email = data.Email,
                Sdt = data.PhoneNumber,
                CreatedDate = DateTime.Now,
                Status = true
            };
            IdentityResult result = await _userManager.CreateAsync(user, data.Password);
            if (result.Succeeded)
            {
                string confirmationToken = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;

                string confirmationLink = Url.Action("confirmemail",
                  "useraccount", new
                  {
                      userid = user.Id,
                      token = confirmationToken
                  },
                   protocol: HttpContext.Request.Scheme);
                try
                {
                    EmailSender.SendMail(user.Email, confirmationLink);
                    status = true;
                    message = "Kiểm tra email để xác thực tài khoản";
                }
                catch (Exception ex)
                {
                    message = "Lỗi xác thực:" + ex.Message;
                    status = false;
                }
                return Json(new
                {
                    status = status,
                    notifi=notifi,
                    message = message
                });
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    switch (error.Code)
                    {
                        case "DuplicateEmail":
                            errorMessasge.Add("Địa chỉ email đã được đăng ký.");
                            break;
                        case "InvalidUserName":
                            errorMessasge.Add("Tên tài khoản bạn vừa nhập không hợp lệ!");
                            break;
                        case "DuplicateUserName":
                            errorMessasge.Add("Tên tài khoản đã tồn tại.");
                            break;
                    }
                }
                return Json(new
                {
                    message = errorMessasge,
                    status = false
                });
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ConfirmEmail(string userid, string token)
        {
            var message = string.Empty;
            var user = _userManager.FindByIdAsync(userid).Result;
            IdentityResult result = _userManager.
                        ConfirmEmailAsync(user, token).Result;
            if (result.Succeeded)
            {
                ViewBag.Message = "Xác thực email thành công!";
                return View("Success");
            }
            else
            {
                ViewBag.Message = "Lỗi xác thực email!";
                return View("Error");
            }
        }
        [Authorize]
        [Route("/logout/{id}")]
        public async Task<IActionResult> LogOut(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user.Id != null)
            {

                await _signInManager.SignOutAsync();
                return Redirect("/");
            }
            else
            {
                return Redirect("/");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("/useraccount/uploadAvatar")]
        public async Task<IActionResult> uploadAvatar(string image, string userid)
        {

            var uploadStatus = false;
            if (image != null)
            {
                var user = await _userManager.FindByIdAsync(userid);
                user.UrlAvatar = image;
                await _userManager.UpdateAsync(user);
                uploadStatus = true;
            }
            return Json(new
            {
                status = uploadStatus
            });
        }

        [Authorize]
        [HttpPost]
        [Route("/UserAccount/UpdateUser")]
        public async Task<IActionResult> UpdateUser(string user)
        {
            var status = false;
            var mess = string.Empty;
            var data = JsonConvert.DeserializeObject<ApplicationUser>(user);
            try
            {
                var userTarget = await _userManager.FindByIdAsync(data.Id);
                userTarget.DisplayName = data.DisplayName;
                userTarget.Address = data.Address;
                userTarget.Sdt = data.PhoneNumber;
                userTarget.Email = data.Email;

                await _userManager.UpdateAsync(userTarget);
                status = true;
                mess = ResultState.Update_SUCCESS;
            }
            catch (Exception)
            {
                mess = ResultState.Update_FALSE;
            }

            return Json(new
            {
                status = status,
                message = mess
            });
        }
        [Route("/giao-dich/{userId}")]
        [Authorize]
        public IActionResult LichSuGiaoDich(string userId)
        {

            var taiKhoan = _userManager.Users.Where(x => x.Id == userId).SingleOrDefault();
            return View(taiKhoan);
        }
        [HttpPost]
        public IActionResult LichSuGiaoDich(string userId, int page, int pageSize = 5)
        {
            var totalRows = 0;
            var lichsuGd = from ls in _giaoDichRepository.giaoDiches()
                           join user in _userManager.Users
                           on ls.UserId equals user.Id
                           where user.Id == userId
                           select new
                           {
                               ls.Content,
                               CreatedDate = String.Format("{0:d/M/yyyy h:mm:ss}", ls.CreatedDate),
                               ls.SoTien,
                               ls.Notes,
                               user.TaiKhoanChinh,
                               user.TaiKhoanKhuyenMai
                           };
            totalRows = lichsuGd.Count();
            var data = lichsuGd.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return Json(new
            {
                data = data,
                total = totalRows,
                page = page,
                status = true
            });
        }
        [HttpPost]
        public IActionResult LichSuNapThe(string userId, int page, int pageSize = 5)
        {
            var totalRows = 0;
            var napthes = _NopCardRepository.NopCards();
            var menhgias = _menhgiaRepository.MenhGias();
            var cards = _cardRepository.Cards();
            var data = from nc in napthes
                       join mg in menhgias on nc.menhgiaId equals mg.Id
                       join c in cards on nc.cardId equals c.Id
                       where nc.UserId == userId
                       orderby nc.NgayNopCard descending
                       select new NopCardViewModels
                       {
                           Id = nc.Id,
                           LoaiThe = c.Name,
                           MenhGia = mg.Price,
                           GiaChietKhau = mg.unit_Price,
                           NgayNopThe = String.Format("{0:d/M/yyyy h:mm:ss}", nc.NgayNopCard),
                           SoDienThoai = nc.Phone,
                           requiredLabel = nc.Required == "0" ? "không" : "nhanh",
                           SoLuong = nc.warenty,
                           TrangThai = nc.Status,
                           Notes=nc.NoiDung
                       };
            totalRows = data.Count();
            var models = data.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return Json(new
            {
                data = models,
                total = totalRows,
                page = page,
                status = true
            });
        }
        [HttpPost]
        [Authorize]
        public IActionResult Delete(string id)
        {
            var status = false;
            string message = ResultState.Delete_FALSE;
            try
            {
                var result = _NopCardRepository.Delete(id);
                _NopCardRepository.SaveChange();
                status = result;
                message = ResultState.Delete_SUCCESS;
            }
            catch (Exception e)
            {
                message = e.Message;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }
        [Route("/giao-dich/nap-tien")]
        public IActionResult NapTien()
        {
            var userId = "";
            var username = "";
            if (User.Identity.IsAuthenticated)
            {
                userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                username = _userManager.Users.FirstOrDefault(x => x.Id == userId).UserName.ToString();
            }
            ViewBag.userName = username;
            var adminId = _userManager.Users.Where(x => x.UserName == "Administrator").SingleOrDefault().Id;
            var dstaikhoan = _tknhRepository.TaiKhoans().Where(x => x.UserId == adminId && x.Status == true).ToList();
            return View(dstaikhoan);
        }
        [AllowAnonymous]
        [Route("/AccessDenied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
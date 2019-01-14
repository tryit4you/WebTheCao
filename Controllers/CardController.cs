using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using reCAPTCHA.AspNetCore;
using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebTheCao.Areas.Admin.Services;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.ViewModels;

namespace WebTheCao.Controllers
{
    public class CardController : Controller
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMenhGiaRepository _menhgiaRepository;
        private readonly INopCardRepository _NopCardRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private IRecaptchaService _recaptcha;
        private string reCaptcha = "reCaptcha";

        public CardController(ICardRepository cardRepository,
            IMenhGiaRepository menhgiaReposiroty,
            INopCardRepository NopCardRepository,
            UserManager<ApplicationUser> userManager,
            IRecaptchaService recaptcha)
        {
            this._cardRepository = cardRepository;
            this._menhgiaRepository = menhgiaReposiroty;
            this._NopCardRepository = NopCardRepository;
            this._recaptcha = recaptcha;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckAgency()
        {
            var checkAgency = false;
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                checkAgency = _userManager.IsInRoleAsync(user, "Đại lý").Result;
            }
            return Json(new
            {
                data = checkAgency
            });
        }

        private async Task<bool> KttkAsync(string mgId, decimal required, int soluong)
        {
            decimal totalPrice = 0;
            var menhgiathe = _menhgiaRepository.GetMenhGia(mgId);
            var phiyeucau = Math.Abs(required) * menhgiathe.Price;
            totalPrice = (menhgiathe.unit_Price * Math.Abs(soluong)) + phiyeucau;
            var kttk = false;
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                if (user.TaiKhoanChinh >= totalPrice)
                {
                    kttk = true;
                    return kttk;
                }
            }
            return false;
        }

        [HttpPost]
        public async Task<IActionResult> checkTKAccount(string menhgiaId, decimal required, int soluong = 0)
        {
            var result = await KttkAsync(menhgiaId, required, soluong);
            return Json(new
            {
                result = result
            });
        }

        public IActionResult GetCard()
        {
            var cards = _cardRepository.Cards().Where(x => x.Status).ToList();
            return Json(new
            {
                data = cards
            });
        }

        public async Task<IActionResult> GetPrice(string cardId)
        {
            bool checkAgency = false;
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                checkAgency = _userManager.IsInRoleAsync(user, "Đại lý").Result;
            }
            var prices = _menhgiaRepository.MenhGias().
                OrderBy(x => x.Price).
                Where(x => x.cardId == cardId).
                Where(x => x.DaiLy == checkAgency)
                .ToList();
            return Json(new
            {
                data = prices
            });
        }

        public string SendMailToAdmin(SendEmailViewModels model)
        {
            string res = string.Empty;
            string required = string.Empty;
            required = (int.Parse(model.Required) != 0 ? "Nhanh" : "Chậm");
            var message = "Tài khoản: " + model.UserName
                + "\nEmail: " + model.Email
                + "\nSố điện thoại: " + model.PhoneNumber
                + "\nLoại thẻ: " + model.LoaiThe
                + "\nMệnh giá: " + model.MenhGia
                + "\nSố lượng thẻ: " + model.Soluong
                + "\nMức độ yêu cầu: " + required
                + "\nGhi chú: " + model.Notes
                + "\nTổng tiền: " + model.TongTien.ToString("#,###");
            var subject = "Yêu cầu nộp thẻ từ tài khoản <<" + model.UserName + ">>";
            try
            {
                EmailSender.SendMail(model.Email, message, subject);
                return res = "Đã gởi email đến quản trị viên! Yêu cầu của bạn sẻ được trả lời sớm nhất có thể";
            }
            catch (Exception)
            {
                return res = "Gởi mail không thành công!";
            }
        }

        [HttpPost]
        public async Task<IActionResult> BuyCard(string form)
        {
            string message = "Yêu cầu nạp thẻ không thành công!";
            bool status = false;
            var data = JsonConvert.DeserializeObject<NopCard>(form);
            var req = decimal.Parse(data.Required);
            var res = await KttkAsync(data.menhgiaId, req, data.warenty);
            var captcha = HttpContext.Session.GetString(reCaptcha);
            
            if (captcha!=null)
            {
                if (User.Identity.IsAuthenticated && res == true)
                {
                    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    data.UserId = userId;
                    data.NgayNopCard = DateTime.Now;
                    var result = _NopCardRepository.AddNopCard(data);
                    _NopCardRepository.SaveChange();

                    status = true;
                    message = "Yêu cầu nạp thẻ thành công!";
                    var menhgia = _menhgiaRepository.GetMenhGia(data.menhgiaId).Price;
                    var sendMailViewModel = new SendEmailViewModels
                    {
                        Email = data.Email,
                        UserName = User.Identity.Name,
                        LoaiThe = _cardRepository.GetCard(data.cardId).Name,
                        MenhGia = menhgia,
                        Notes = data.NoiDung,
                        PhoneNumber = data.Phone,
                        Required = data.Required,
                        Soluong = data.warenty,
                        TongTien = menhgia * data.warenty
                    };
                    SendMailToAdmin(sendMailViewModel);
                    HttpContext.Session.Clear();

                }
                return Json(new
                {
                    status = status,
                    message = message
                });
            }
            else
            {
                return Json(new
                {
                    status=false,
                    message= "Vui lòng xác thực mã captcha!!! "
                });
            }
         
          
        }

        //verify the captcha's response with Google

        [HttpPost]
        private async Task<CaptchaVerification> VerifyCaptcha(string captchaResponse)
        {
            string userIP = string.Empty;
            var ipAddress = Request.HttpContext.Connection.RemoteIpAddress;
            if (ipAddress != null) userIP = ipAddress.MapToIPv4().ToString();

            var recapchaResponse = Request.Form["g-recaptcha-response"];
            var payload = string.Format("&secret={0}&remoteip={1}&response={2}", "6Lfb0HgUAAAAAHtpKhTxIqQQpyI_iNX1Tu9jLdZJ", userIP,
               captchaResponse
            );

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://www.google.com");
            var request = new HttpRequestMessage(HttpMethod.Post, "/recaptcha/api/siteverify");
            request.Content = new StringContent(payload, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.SendAsync(request);
            return JsonConvert.DeserializeObject<CaptchaVerification>(response.Content.ReadAsStringAsync().Result);
        }

        [HttpPost("api/captcha/verify")]
        public async Task<Object> Verify(string captchaResponse)
        {
            var result = await VerifyCaptcha(captchaResponse);
            if (result.Success)
                HttpContext.Session.SetString(reCaptcha,captchaResponse);
            return new JsonResult(result);
        }
    }
}
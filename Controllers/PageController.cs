using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.ViewModels;

namespace WebTheCao.Controllers
{
    public class PageController : Controller
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICardRepository _cardRepository;
        private readonly IMenhGiaRepository _menhgiaRepository;
        private readonly IContactRepository _contactRepository;
        
        public PageController(IFeedbackRepository feedbackRepository,
            UserManager<ApplicationUser> userManager,
            ICardRepository cardRepository,
            IMenhGiaRepository menhgiaRepository,
            IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            _feedbackRepository = feedbackRepository;
            _userManager = userManager;
            _cardRepository = cardRepository;
            _menhgiaRepository = menhgiaRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContactPage()
        {
            var contact = _contactRepository.Contacts().Where(x => x.Status == true).FirstOrDefault();
            return View(contact);
        }
        public IActionResult PostFeedback(string feedback)
        {

            var status = false;
            string message = string.Empty;
            var data = JsonConvert.DeserializeObject<Feedback>(feedback);
            if (User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                data.UserId = userId;
                data.CreatedDate = DateTime.Now;
                _feedbackRepository.AddFeedback(data);
                _feedbackRepository.SaveChange();
                status = true;
            }
            else
            {
                var guestId = _userManager.Users.FirstOrDefault(x => x.UserName == "guest").Id;
                data.UserId = guestId;
                _feedbackRepository.AddFeedback(data);
                _feedbackRepository.SaveChange();
                status = true;
            }

            return Json(new
            {
                status = status,
                message = "Cảm ơn bạn đã gởi phản hồi! Chúng tôi sẻ trả lời bạn sớm nhất có thể"
            });
        }
        public async Task<IActionResult> BangGia()
        {
            var checkDaiLy = false;
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                checkDaiLy = _userManager.IsInRoleAsync(user,"Đại lý").Result;
            }
            var cards = _cardRepository.Cards().ToList();
            var menhgias = _menhgiaRepository
                .MenhGias().
                Where(x=>x.DaiLy==checkDaiLy).
                OrderBy(x=>x.Price).
                ToList();
            var menhgia_cardVM = new MenhGia_CardViewModels
            {
                Cards = cards,
                DsMenhGia = menhgias
            };
            ViewBag.data = menhgia_cardVM;
            return View();
        }
    }
}
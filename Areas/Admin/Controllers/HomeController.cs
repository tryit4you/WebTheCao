using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebTheCao.Areas.Admin.ViewModels;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.ViewModels;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly INopCardRepository _nopCardRepository;
        private readonly IMenhGiaRepository _menhgiaRepository;
        private readonly ICardRepository _cardRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(INopCardRepository nopCardRepository,
            ICardRepository cardRepository,
            IMenhGiaRepository menhgiaRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _nopCardRepository = nopCardRepository;
            _cardRepository = cardRepository;
            _menhgiaRepository = menhgiaRepository;
        }
        [Authorize]
        public IActionResult Index()
        {
            
            return View("Index");
        }
        [Authorize]
        public IActionResult LoadChartCart()
        {
            var nopcards = _nopCardRepository.NopCards();
            var cards = _cardRepository.Cards();
            var data = (from card in cards
                        select new ChartCardViewModel
                        {
                            Label = card.Name,
                            Data = nopcards.Where(x => x.cardId == card.Id).Count()
                        }).ToList();
            return Json(new
            {
                status = true,
                data = data
            });
        }
        [Authorize]
        public IActionResult LoadStatusChartCart()
        {
            var nopcards = _nopCardRepository.NopCards();

            var data = (from card in nopcards
                        group card by card.Status into s
                        select new ChartCardViewModel {
                            Label = s.Key == true ? "Đã nạp" : "Chưa nạp",
                            Data = s.Count()
                        }).ToList();
            return Json(new
            {
                status = true,
                data = data
            });
        }
        [Authorize]
        public IActionResult DoanhThuChartCart()
        {
            var nopcards = _nopCardRepository.NopCards().Where(x=>x.Status==true);
            var menhgia = _menhgiaRepository.MenhGias();
            var doanhthu = (from card in nopcards
                       join mg in menhgia on card.menhgiaId equals mg.Id
                       orderby card.NgayNopCard 
                       select new ThuNhapTheoNgay
                       {
                           LabelDate = card.NgayNopCard.ToString("d/M/yyyy"),
                           DoanhThu = mg.Price * card.warenty
                       })
                       .ToList();
            var data = (from dt in doanhthu
                        group dt by dt.LabelDate into g
                        select new
                        {
                            LabelDate = g.Key,
                            DoanhThuNgay = g.Sum(x => x.DoanhThu)
                        }).Take(30).ToList();
            return Json(new
            {
                status = true,
                data = data
            });
        }
    }
}
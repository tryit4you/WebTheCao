using WebTheCao.Areas.Admin.ViewModels;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebTheCao.Areas.Admin.Components
{
    [ViewComponent(Name = "NotificationViewComponent")]
    public class NotificationViewComponent:ViewComponent
    {
        private INopCardRepository _noptheRepository;
        private ICardRepository _cardRepository;
        private IMenhGiaRepository _menhgiaRepository;
        private UserManager<ApplicationUser> _userManager;
       
        public NotificationViewComponent(UserManager<ApplicationUser> userManager,
            ICardRepository cardRepository,
            IMenhGiaRepository menhgiaRepository,
            INopCardRepository nopCardRepository)
        {
            _noptheRepository = nopCardRepository;
            _userManager = userManager;
            _cardRepository = cardRepository;
            _menhgiaRepository = menhgiaRepository;
        }
        public IViewComponentResult Invoke()
        {
            var nopthetrongngay = _noptheRepository.NopCards().
                Where(x => x.NgayNopCard.Subtract(DateTime.Now.Date).Days == 0&&x.ViewStatus==false&&x.Status==false).ToList();
            var data = from napthe in nopthetrongngay
                       join user in _userManager.Users on napthe.UserId equals user.Id
                       join card in _cardRepository.Cards() on napthe.cardId equals card.Id
                       join mg in _menhgiaRepository.MenhGias() on napthe.menhgiaId equals mg.Id
                       select new NopTheViewModels
                       {
                           id=napthe.Id,
                           loaithe = card.Name,
                           menhgia = mg.Price,
                           ngaynop = String.Format("{0:d/M/yyyy h:mm:ss}", napthe.NgayNopCard),
                           userName = user.UserName,
                           avatar=user.UrlAvatar,
                           soluong=napthe.warenty
                       };
           
            return View(data);
        }
    }
}

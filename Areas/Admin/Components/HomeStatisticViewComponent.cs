using WebTheCao.Areas.Admin.ViewModels;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Areas.Admin.Components
{
    public class HomeStatisticViewComponent:ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly INopCardRepository _noptheRepository;
        private readonly IGiaoDichRepository _giaodichRepository;

        public HomeStatisticViewComponent(
            UserManager<ApplicationUser> userManager,
            IFeedbackRepository feedbackRepository,
            INopCardRepository noptheRepository,
            IGiaoDichRepository giaodichRepository)
        {
            _noptheRepository = noptheRepository;
            _giaodichRepository = giaodichRepository;
            _userManager = userManager;
            _feedbackRepository = feedbackRepository;

        }
   
        private FeedbackVm GetFeedbackVm()
        {
            var feedbackCount = _feedbackRepository.Feedbacks().Count();
            var feedbackToday = (from b in _feedbackRepository.Feedbacks()
                                 where DateTime.Now.Subtract(b.CreatedDate).Days <= 0
                                 select b
                             ).Count();
            var feedbackVm = new FeedbackVm
            {
                Total=feedbackCount,
                InToday=feedbackToday
            };
            return feedbackVm;
        }
     
        private AccountVm GetUserVm()
        {
            var accountCount = _userManager.Users.Count();
            var registerToday = (from u in _userManager.Users
                                 where DateTime.Now.Subtract(u.CreatedDate).Days <= 0
                                 select u
                             ).Count();
            var accountVm = new AccountVm
            {
                Total=accountCount,
                RegisterToday=registerToday
            };
            return accountVm;
        }
        private NopTheVM GetNopTheVm()
        {
            var noptheVM = _noptheRepository.NopCards().Count();
            var noptheToday = (from b in _noptheRepository.NopCards()
                                 where DateTime.Now.Subtract(b.NgayNopCard).Days <= 0
                                 select b
                             ).Count();
            var noptheVm = new NopTheVM
            {
                Total = noptheVM,
                InToday = noptheToday
            };
            return noptheVm;
        } private GiaoDichVM GetGiaoDichVm()
        {
            var giaodich = _giaodichRepository.giaoDiches().Count();
            var giaodichToDay = (from b in _giaodichRepository.giaoDiches()
                               where DateTime.Now.Subtract(b.CreatedDate).Days <= 0
                               select b
                             ).Count();
            var giaodichVm = new GiaoDichVM
            {
                Total=giaodich,
                InToday=giaodichToDay
            };
            return giaodichVm;
        }
        public IViewComponentResult Invoke()
        {

            var homeView = new HomeViewModels
            {
                NopTheVM=GetNopTheVm(),
                GiaoDichVM=GetGiaoDichVm(),
                AccountVm = GetUserVm(),
                FeedbackVm = GetFeedbackVm(),
            };
            return View(homeView);
        }
    }
}

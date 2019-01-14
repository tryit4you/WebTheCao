using WebTheCao.Areas.Admin.ViewModels;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.SharedComponents;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Areas.Admin.Components
{
    public class FeedbacksViewComponent:ViewComponent
    {
        private IFeedbackRepository feedbackRepository;
        private UserManager<ApplicationUser> userManager;
        public FeedbacksViewComponent(IFeedbackRepository feedbackRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.feedbackRepository = feedbackRepository;
            this.userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var feedbacks = feedbackRepository.Feedbacks();
            var data = (from fb in feedbacks
                        join
                        user in userManager.Users on fb.UserId equals user.Id
                        where fb.Status==false && DateTime.Now.Subtract(fb.CreatedDate).Days<=0
                        orderby fb.CreatedDate descending
                        select new FeedbackData
                        {
                            ID = fb.ID,
                            Message = fb.Message,
                            Subject = fb.Subject,
                            time = ConvertToTimeSpan.Convert(fb.CreatedDate),
                            UserName = user.UserName,
                            urlAvatar = user.UrlAvatar
                        }
                     ).ToList();
            return View(data);
        }
    }
}

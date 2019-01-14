using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTheCao.Data.Interfaces;

namespace WebTheCao.Components
{
    public class topViewsViewComponent:ViewComponent
    {
        private readonly IPostRepository _postRepository;
        public topViewsViewComponent(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public IViewComponentResult Invoke()
        {
            var getTopViews = (_postRepository.Posts().
                  Where(x => x.Status == true).
                  OrderByDescending(x => x.Views).
                  Take(10)).ToList();
            return View(getTopViews);
        }
    }
}

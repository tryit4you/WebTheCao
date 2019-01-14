using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.ViewModels;

namespace WebTheCao.Components
{
    public class SlideViewComponent : ViewComponent
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IPageRepository _pageRepository;
        public IMemoryCache _cache;
        public SlideViewComponent(ISlideRepository slideRepository,
            IPageRepository pageRepository,
            IMemoryCache cache)
        {
            _slideRepository = slideRepository;
            _pageRepository = pageRepository;
            _cache = cache;
        }

        public IViewComponentResult Invoke()
        {
            var notification = _pageRepository.Pages().Where(x => x.Status == true).FirstOrDefault();
            var slides = new List<Slide>();
            if (!_cache.TryGetValue("slide", out slides))
            {
                if (slides == null)
                {
                    slides = _slideRepository.Slides().
                                Where(x => x.Status == true).
                              OrderBy(x => x.DisplayOrder)
                                .ToList();
                }
                var cacheEntryOptions = new MemoryCacheEntryOptions()
           .SetSlidingExpiration(TimeSpan.FromMinutes(10));

                _cache.Set("slide", slides);
            }
            var bannerViewModel = new BannerViewModels
            {
                Notification = notification,
                Slides = slides
            };
            return View(bannerViewModel);
        }
    }
}

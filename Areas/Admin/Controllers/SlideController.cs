using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.SharedComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    public class SlideController : Controller
    {
        private readonly ISlideRepository _slideRepository;

        public SlideController(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(string filter, int page, int pageSize = 10)
        {
            var totalRows = 0;
            var footers = _slideRepository.Slides();
            totalRows = footers.Count();

            if (!string.IsNullOrEmpty(filter))
            {
                footers = footers.Where(p => p.Name.ToLower().Contains(filter)).OrderBy(x => x.Name).ToList();
                totalRows = footers.Count();
            }
            var model = footers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(new
            {
                data = model,
                total = totalRows,
                status = true
            });
        }

        [HttpPost]
        public IActionResult Post(string slide)
        {
            var status = false;
            string message = ResultState.Add_FALSE;
            var data = JsonConvert.DeserializeObject<Slide>(slide);
            if (User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                data.UserId = userId;
                _slideRepository.AddSlide(data);
                _slideRepository.SaveChange();
                status = true;
                message = ResultState.Add_SUCCESS;
            }
            return Json(new
            {
                message = message,
                status = status
            });
        }

        [HttpPost]
        public IActionResult Put(string slide)
        {
            var status = false;
            string message = ResultState.Update_FALSE;
            var data = JsonConvert.DeserializeObject<Slide>(slide);
            if (User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                data.UserId = userId;
                var result = _slideRepository.Update(data);
                if (result)
                {
                    _slideRepository.SaveChange();
                    status = true;
                    message = ResultState.Update_SUCCESS;
                }
                else
                    message = ResultState.Update_FALSE;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var status = false;
            string message = ResultState.Delete_FALSE;
            try
            {
                var result = _slideRepository.Delete(id);
                _slideRepository.SaveChange();
                status = true;
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

        [HttpPost]
        public IActionResult GetDetail(string id)
        {
            var slide = _slideRepository.GetSlide(id);
            return Json(new
            {
                data = slide,
                status = true
            });
        }

        [HttpPost]
        public IActionResult CheckExist(string name)
        {
            var result = _slideRepository.CheckName(name);
            return Json(new
            {
                result = !result
            });
        }

        public IActionResult ChangeStatus(string id)
        {
            bool status;
            string message = string.Empty;
            var slide = _slideRepository.GetSlide(id);
            if (slide == null)
            {
                status = false;
                message = ResultState.NotFound;
            }
            else
            {
                slide.Status = !slide.Status;
                _slideRepository.SaveChange();
                status = slide.Status;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }

        
    }
}
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
    public class PageController : Controller
    {
        private readonly IPageRepository _pageRepository;

        public PageController(IPageRepository pageRepository)
        {
            _pageRepository = pageRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(string filter, int page, int pageSize = 10)
        {
            var totalRows = 0;
            var pages = _pageRepository.Pages();
            totalRows = pages.Count();
            if (!string.IsNullOrEmpty(filter))
            {
                pages = pages.Where(p => p.Name.ToLower().Contains(filter)).OrderBy(x => x.Name).ToList();
                totalRows = pages.Count();
            }
            var model = pages.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(new
            {
                data = pages,
                total = totalRows,
                status = true
            });
        }

        [HttpPost]
        public IActionResult Post(string page)
        {
            var status = false;
            string message = string.Empty;
            var data = JsonConvert.DeserializeObject<Page>(page);
            if (User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                data.UserId = userId;
            }
            try
            {
                _pageRepository.AddPage(data);
                _pageRepository.SaveChange();
                status = true;
                message = ResultState.Add_SUCCESS;
            }
            catch
            {
                message = ResultState.Add_FALSE;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }

        [HttpPost]
        public IActionResult Put(string page)
        {
            var status = false;
            string message = string.Empty;
            var data = JsonConvert.DeserializeObject<Page>(page);
            try
            {
                var result = _pageRepository.Update(data);
                if (result)
                    _pageRepository.SaveChange();
                message = ResultState.Update_SUCCESS;
                status = true;
            }
            catch
            {
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
            string message = string.Empty;
            var result = _pageRepository.Delete(id);
            try
            {
                _pageRepository.SaveChange();
                status = true;
                message = ResultState.Delete_SUCCESS;
            }
            catch (Exception)
            {
                message = ResultState.Delete_FALSE;
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
            var book = _pageRepository.GetPage(id);
            return Json(new
            {
                data = book,
                status = true
            });
        }

        [HttpPost]
        public IActionResult CheckExist(string name)
        {
            var result = _pageRepository.CheckName(name);
            return Json(new
            {
                result = !result
            });
        }

        public IActionResult ChangeStatus(string id)
        {
            bool status;
            string message = string.Empty;
            var contact = _pageRepository.GetPage(id);
            if (contact == null)
            {
                status = false;
                message = ResultState.NotFound;
            }
            else
            {
                contact.Status = !contact.Status;
                _pageRepository.SaveChange();
                status = contact.Status;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }

        [HttpPost]
        public IActionResult DeleteMul(string[] ids)
        {
            var status = false;
            string message = string.Empty;
            try
            {
                foreach (var id in ids)
                {
                    _pageRepository.Delete(id);
                }
                status = true;
                message = ResultState.Delete_SUCCESS;
            }
            catch
            {
                status = false;
                message = ResultState.Delete_FALSE;
            }
            _pageRepository.SaveChange();
            return Json(new
            {
                status = status,
                message = message
            });
        }
    }
}
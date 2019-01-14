using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.SharedComponents;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    public class PartialController : Controller
    {
        private readonly IPartialRepository _partialRepository;

        public PartialController(IPartialRepository partialRepository)
        {
            _partialRepository = partialRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(string filter, int page, int pageSize = 10)
        {
            var partials = _partialRepository.Partials().Skip((page - 1) * pageSize).Take(pageSize).ToList();

           
            return Ok(new
            {
                data = partials,
                status = true
            });
        }

        [HttpPost]
        public IActionResult Post(string partial)
        {
            var status = false;
            string message = string.Empty;
            var data = JsonConvert.DeserializeObject<Partial>(partial);
            try
            {
                _partialRepository.AddPartial(data);
                _partialRepository.SaveChange();
                status = true;
                message = ResultState.Add_SUCCESS;
            }
            catch
            {
                status = false;
                message = ResultState.Add_FALSE;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }

        [HttpPost]
        public IActionResult Put(string partial)
        {
            var status = false;
            string message = string.Empty;
            var data = JsonConvert.DeserializeObject<Partial>(partial);
            try
            {
                var result = _partialRepository.Update(data);
                if (result)
                    _partialRepository.SaveChange();
                status = true;
                message = ResultState.Update_SUCCESS;
            }
            catch
            {
                status = false;
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
            var result = _partialRepository.Delete(id);
            _partialRepository.SaveChange();
            return Json(new
            {
                status = true,
                message = ResultState.Delete_SUCCESS
            });
        }

        [HttpPost]
        public IActionResult GetDetail(string id)
        {
            var partial = _partialRepository.GetPartial(id);
            return Json(new
            {
                data = partial,
                status = true
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
                    _partialRepository.Delete(id);
                }
                status = true;
                message = ResultState.Delete_SUCCESS;
            }
            catch
            {
                status = false;
                message = ResultState.Delete_FALSE;
            }
            _partialRepository.SaveChange();
            return Json(new
            {
                status = status,
                message = message
            });
        }
    }
}
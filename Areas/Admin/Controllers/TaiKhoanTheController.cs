using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.SharedComponents;
using WebTheCao.ViewModels;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    public class TaiKhoanTheController : Controller
    {
        private readonly ITKNHRepository _tknhRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public TaiKhoanTheController(ITKNHRepository tknhRepository,
            UserManager<ApplicationUser> userManager)
        {
            _tknhRepository = tknhRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            var tknh = _tknhRepository.TaiKhoans().ToList();
            var data = from tk in tknh
                       join user in _userManager.Users
                       on tk.UserId equals user.Id
                       select new TaiKhoanNganHangViewModel
                       {
                           Id= tk.Id,
                           TenNguoiThuHuong= tk.NguoiThuHuong,
                           SoTK= tk.SoTK,
                           TenChiNhanh= tk.TenChiNhanh,
                            TenNH=tk.TenNH,
                           Status= tk.Status,
                           UserName= user.UserName
                       };
            return View(data);
        }
        [HttpPost]
        public IActionResult Post(string tknh)
        {
            var status = false;

            string message = ResultState.Add_FALSE;
            var data = JsonConvert.DeserializeObject<TaiKhoanNganHang>(tknh);
            if (User.Identity.IsAuthenticated)
            {
                var adminId = _userManager.Users.Where(x=>x.UserName=="Administrator").SingleOrDefault().Id;
                data.UserId = adminId;
                _tknhRepository.AddTaiKhoan(data);
                _tknhRepository.SaveChange();
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
        public IActionResult Put(string tknh)
        {
            var status = false;
            string message = ResultState.Update_FALSE;
            var data = JsonConvert.DeserializeObject<TaiKhoanNganHang>(tknh);
            if (User.Identity.IsAuthenticated)
            {
                var result = _tknhRepository.Update(data);
                if (result)
                {
                    _tknhRepository.SaveChange();
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
                var result = _tknhRepository.Delete(id);
                //xoa lun cac menh gia
                _tknhRepository.SaveChange();
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
            var mg = _tknhRepository.GetTKhoan(id);
            return Json(new
            {
                data = mg,
                status = true
            });
        }
      
        public IActionResult ChangeStatus(string id)
        {
            bool status;
            string message = string.Empty;
            var tk = _tknhRepository.GetTKhoan(id);
            if (tk == null)
            {
                status = false;
                message = ResultState.NotFound;
            }
            else
            {
                tk.Status = !tk.Status;
                _tknhRepository.SaveChange();
                status = tk.Status;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }
        
       
    }
}
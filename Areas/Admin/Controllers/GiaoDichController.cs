using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.SharedComponents;
using WebTheCao.ViewModels;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    public class GiaoDichController : Controller
    {
        private readonly INopCardRepository _NopCardRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMenhGiaRepository _menhGiaRepository;
        private readonly ICardRepository _cardRepository;
        private readonly IGiaoDichRepository _giaodichRepository;
        public GiaoDichController(INopCardRepository NopCardRepository,
            UserManager<ApplicationUser> userManager,
            IMenhGiaRepository menhGiaRepository,
            ICardRepository cardRepository,
            IGiaoDichRepository giaodichRepository)
        {
            _NopCardRepository = NopCardRepository;
            _userManager = userManager;
            _menhGiaRepository = menhGiaRepository;
            _cardRepository = cardRepository;
            _giaodichRepository = giaodichRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region lịch sử nộp thẻ
        [HttpPost]
        public IActionResult GetAll(string filter, int page, int pageSize = 10, int statusRad = 0)
        {
            var totalRows = 0;
            var NopCard = _NopCardRepository.NopCards();
            var users = _userManager.Users;
            var menhgias = _menhGiaRepository.MenhGias();
            var cards = _cardRepository.Cards();
  
          
            var data = from nc in NopCard
                       join user in users on nc.UserId equals user.Id
                       join mg in menhgias on nc.menhgiaId equals mg.Id
                       join c in cards on nc.cardId equals c.Id
                       where (statusRad==1?nc.Status==true:nc.Status==false)
                       where (filter!=null?user.UserName.Contains(filter):true)
                       orderby nc.NgayNopCard descending
                       select new NopCardViewModels
                       {
                           Id = nc.Id,
                           UserName = user.UserName,
                           LoaiThe = c.Name,
                           MenhGia = mg.Price,
                           NgayNopThe = String.Format("{0:d/M/yyyy h:mm:ss}", nc.NgayNopCard),
                           SoDienThoai = nc.Phone,
                           requiredLabel = nc.Required=="0"? "không":"nhanh",
                           SoLuong = nc.warenty,
                           TrangThai = nc.Status
                       };
            totalRows = data.Count();
            var model = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Json(new
            {
                data = model,
                total = totalRows,
                status = true
            });
        }
        public IActionResult ExportToExcel()
        {
            var NopCard = _NopCardRepository.NopCards();
            var users = _userManager.Users;
            var menhgias = _menhGiaRepository.MenhGias();
            var cards = _cardRepository.Cards();


            var data = from nc in NopCard
                       join user in users on nc.UserId equals user.Id
                       join mg in menhgias on nc.menhgiaId equals mg.Id
                       join c in cards on nc.cardId equals c.Id                  
                       orderby nc.NgayNopCard descending
                       where nc.Status==false
                       select new NopCardViewModels
                       {
                           Id = nc.Id,
                           UserName = user.UserName,
                           LoaiThe = c.Name,
                           MenhGia = mg.Price,
                           NgayNopThe = String.Format("{0:d/M/yyyy h:mm:ss}", nc.NgayNopCard),
                           SoDienThoai = nc.Phone,
                           requiredLabel = nc.Required == "0" ? "không" : "nhanh",
                           SoLuong = nc.warenty,
                           TrangThai = nc.Status
                       };
            var comlumHeadrs = new string[]
           {
                "Tên tài khoản",
                "Điện thoại",
                "Ngày nạp",
                "Yêu cầu",
                "Mệnh giá thẻ",
                "Số lượng ",
                "Trạng thái "
           };

            byte[] result;

            using (var package = new ExcelPackage())
            {
                // add a new worksheet to the empty workbook

                var worksheet = package.Workbook.Worksheets.Add("ExportExcel"); //Worksheet name
                using (var cells = worksheet.Cells[1, 1, 1, 7]) //(1,1) (1,5)
                {
                    cells.Style.Font.Bold = true;
                }

                //First add the headers
                for (var i = 0; i < comlumHeadrs.Count(); i++)
                {
                    worksheet.Cells[1, i + 1].Value = comlumHeadrs[i];
                }

                //Add values
                var j = 2;
                foreach (var nc in data)
                {
                    worksheet.Cells["A" + j].Value = nc.UserName;
                    worksheet.Cells["B" + j].Value = nc.SoDienThoai;
                    worksheet.Cells["C" + j].Value = nc.NgayNopThe;
                    worksheet.Cells["D" + j].Value = nc.required;
                    worksheet.Cells["E" + j].Value = nc.MenhGia.ToString("#,###");
                    worksheet.Cells["F" + j].Value = nc.SoLuong;
                    worksheet.Cells["G" + j].Value = nc.TrangThai==true?"Đã nạp":"Chưa nạp";

                    j++;
                }
                result = package.GetAsByteArray();
            }

            return File(result, "application/ms-excel", $"yeu-cau-nap-the-{DateTime.Now}.xlsx");
        }

        [HttpPost]
        public IActionResult deleteAllHistory(string[] ids)
        {
            var status = false;
            string message = string.Empty;
            try
            {
                foreach (var id in ids)
                {
                    _NopCardRepository.Delete(id);
                }
                status = true;
                message = ResultState.Delete_SUCCESS;
                _NopCardRepository.SaveChange();
            }
            catch
            {
                status = false;
                message = ResultState.Delete_FALSE;
            }
            
            return Json(new
            {
                status = status,
                message = message
            });
        }
        [HttpPost]
        public IActionResult DeleteHistory(string id)
        {
            var status = false;
            string message = ResultState.Delete_FALSE;
            try
            {
                var result = _NopCardRepository.Delete(id);
                _NopCardRepository.SaveChange();
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
        public IActionResult DeleteMulti(string[] ids)
        {
            var status = false;
            string message = string.Empty;
            try
            {
                foreach (var id in ids)
                {
                    _giaodichRepository.Delete(id);
                }
                status = true;
                message = ResultState.Delete_SUCCESS;
                _NopCardRepository.SaveChange();
            }
            catch
            {
                status = false;
                message = ResultState.Delete_FALSE;
            }

            return Json(new
            {
                status = status,
                message = message
            });
        }
        #endregion
        [HttpPost]
        public IActionResult AllGiaoDich(string filter, int page, int pageSize = 10)
        {
            var totalRows = 0;
            var giaodichs = _giaodichRepository.giaoDiches();
            totalRows = giaodichs.Count();

            var data = (from gd in giaodichs
                        join user in _userManager.Users on
                        gd.UserId equals user.Id
                        orderby gd.CreatedDate descending
                        select new
                        {
                            gd.Id,
                            gd.Content,
                            gd.Notes,
                            gd.SoTien,
                            CreatedDate= String.Format("{0:d/M/yyyy h:mm:ss}", gd.CreatedDate),
                            userName = user.DisplayName ?? user.UserName,
                            user.PhoneNumber
                        });
            var model = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(new
            {
                data = model,
                total = totalRows,
                page = page,
                status = true
            });
        }
        [HttpPost]
        public IActionResult Post(string giaodich)
        {
            var status = false;
            string message = "";
            var data = JsonConvert.DeserializeObject<GiaoDich>(giaodich);
            if (User.Identity.IsAuthenticated)
            {
                var taikhoannop = _userManager.FindByIdAsync(data.UserId).Result;
                if (data.Content==1)
                {
                    taikhoannop.Points += data.SoTien;
                    taikhoannop.TaiKhoanChinh += data.SoTien;
                    message = "Đã nộp tiền vào tài khoản " + taikhoannop.UserName + "Số tiền " + taikhoannop.Points;
                }
                else
                {
                    taikhoannop.Points -= data.SoTien;
                    taikhoannop.TaiKhoanChinh -= data.SoTien;
                    message = "Đã Trừ tiền thành công tài khoản " + taikhoannop.UserName + "Số tiền " + taikhoannop.Points;
                }
              
                data.CreatedDate = DateTime.Now;
                _giaodichRepository.AddGiaoDich(data);
                _giaodichRepository.SaveChange();
                status = true;
               
            }
            return Json(new
            {
                message = message,
                status = status
            });
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            var status = false;
            string message = ResultState.Delete_FALSE;
            try
            {
                var result = _NopCardRepository.Delete(id);
                _NopCardRepository.SaveChange();
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
        public IActionResult getaccount()
        {
            //get all users
            var users = _userManager.Users.Where(x => x.Status == true&&x.EmailConfirmed==true).OrderByDescending(x=>x.TaiKhoanChinh);
            return Json(new {
                data=users
            });
        }
       
        public IActionResult GetCardInfor(string id)
        {
            bool status =false;
            string message = string.Empty;
            var nc = _NopCardRepository.GetNopCard(id);
            var data = new NopCardViewModels
            {
                Id = nc.Id,
                LoaiThe = _cardRepository.GetCard(nc.cardId).Name,
                GiaChietKhau = _menhGiaRepository.GetMenhGia(nc.menhgiaId).unit_Price,
                NgayNopThe = String.Format("{0:d/M/yyyy h:mm:ss}", nc.NgayNopCard),
                required = decimal.Parse(nc.Required),
                SoDienThoai = nc.Phone,
                MenhGia = _menhGiaRepository.GetMenhGia(nc.menhgiaId).Price,
                SoLuong = nc.warenty,
                TrangThai = nc.Status,
                UserName = _userManager.Users.FirstOrDefault(x => x.Id == nc.UserId).UserName
            };
            if (data!=null)
            {
                status = true;
            }
            else
            {
                message = "Không tìm thấy giao dịch này";
            };
            return Json(new
            {
                data = data,
                message=message,
                status = status
            });
        }
        public IActionResult ThanhToanThe(string id)
        {
            decimal tonggiaodich = 0;
            decimal total = 0;
            bool status = false;
            string message = string.Empty;
            var nc = _NopCardRepository.GetNopCard(id);
            var taikhoan = _userManager.Users.Where(x => x.Id == nc.UserId).SingleOrDefault();
         
            decimal menhgiathe = _menhGiaRepository.GetMenhGia(nc.menhgiaId).unit_Price;
            decimal khongchietkhau = _menhGiaRepository.GetMenhGia(nc.menhgiaId).Price;
            tonggiaodich = menhgiathe * nc.warenty;
            decimal phigd = decimal.Parse(nc.Required) * khongchietkhau ;
            total = tonggiaodich + phigd;
            if (taikhoan.TaiKhoanChinh >= total)
            {
                taikhoan.Points -= total;
                taikhoan.TaiKhoanChinh -= total;
                message = "Nạp thẻ thành công";
              
                //thay đổi trạng thái nạp thẻ
                nc.Status = true;
                _NopCardRepository.SaveChange();
                status = true;
            }
            else
            {
                message = "Tài khoản không đủ để thực hiện giao dịch";
            }
           
            return Json(new
            {
                message = message,
                status = status
            });
        }
        [HttpPost]
        public IActionResult MakeAllRead()
        {
            bool status;
            try
            {

                foreach (var item in _NopCardRepository.NopCards().Where(x => x.ViewStatus == false))
                {
                    item.ViewStatus = true;
                }
                _NopCardRepository.SaveChange();
                status = true;

            }
            catch
            {
                status = false;
            }
            return Json(new
            {
                status = status
            });
        }

        public IActionResult MakeItemRead(string id)
        {
            var status = false;
            var napthe = _NopCardRepository.GetNopCard(id);
            if (napthe==null)
            {
                status = false;
            }
            else
            {
                napthe.ViewStatus = true;
                _NopCardRepository.SaveChange();
                status = true;
            }
            return Json(new
            {
                status = status
            });
        }
    }
}
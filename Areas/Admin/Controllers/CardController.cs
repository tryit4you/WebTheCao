using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.SharedComponents;
using WebTheCao.ViewModels;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    public class CardController : Controller
    {
        private readonly ICardRepository _CardRepository;
        private readonly IMenhGiaRepository _menhgiaRepository;

        public CardController(ICardRepository CardRepository,
            IMenhGiaRepository menhgiaRepository)
        {
            _CardRepository = CardRepository;
            _menhgiaRepository = menhgiaRepository;
        }

        public IActionResult Index()
        {
            var cards = _CardRepository.Cards();
            var menhgias = (from mg in _menhgiaRepository.MenhGias()
                           orderby mg.Price
                           group mg by mg.DaiLy into dl
                           select new DaiLyThe
                           {
                               LoaiTaiKhoan = dl.Key  ? "Đại lý" : "Thường dân",
                               key=dl.Key?"true":"false",
                               MenhGias = dl.Where(x => x.DaiLy == dl.Key).ToList()
                           }).ToList();

            var cardVM = new CardViewModels
            {
                Cards = cards,
                DaiLyThes = menhgias
            };
            return View(cardVM);
        }
        [HttpPost]
        public IActionResult GetAll(string filter, int page, int pageSize = 10)
        {
            var totalRows = 0;
            var footers = _CardRepository.Cards();
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
        public IActionResult Post(string card)
        {
            var status = false;
            string message = ResultState.Add_FALSE;
            var data = JsonConvert.DeserializeObject<Card>(card);
            if (User.Identity.IsAuthenticated)
            {
                _CardRepository.AddCard(data);
                _CardRepository.SaveChange();
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
        public IActionResult PutMg(string mg)
        {
            var status = false;
            string message = ResultState.Update_FALSE;
            var data = JsonConvert.DeserializeObject<MenhGia>(mg);
            if (User.Identity.IsAuthenticated)
            {
                var result = _menhgiaRepository.Update(data);
                if (result)
                {
                    _menhgiaRepository.SaveChange();
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
        public IActionResult PutCard(string card)
        {
            var status = false;
            string message = ResultState.Update_FALSE;
            var data = JsonConvert.DeserializeObject<Card>(card);
            if (User.Identity.IsAuthenticated)
            {
                var result = _CardRepository.Update(data);
                if (result)
                {
                    _CardRepository.SaveChange();
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
        public IActionResult DeleteCard(string id)
        {
            var status = false;
            string message = ResultState.Delete_FALSE;
            try
            {
                var result = _CardRepository.Delete(id);
                //xoa lun cac menh gia
                var menhgia = _menhgiaRepository.MenhGias().Where(x => x.cardId == id);
                foreach (var mg in menhgia)
                {
                    _menhgiaRepository.Delete(mg.Id);
                }
                _CardRepository.SaveChange();
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
        public IActionResult DeleteMg(string id)
        {

            var status = false;
            string message = ResultState.Delete_FALSE;
            try
            {
                var result = _menhgiaRepository.Delete(id);
                _menhgiaRepository.SaveChange();
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
        public IActionResult GetMgDetail(string id)
        {
            var mg = _menhgiaRepository.GetMenhGia(id);
            return Json(new
            {
                data = mg,
                status = true
            });
        }
        [HttpPost]
        public IActionResult GetCardDetail(string id)
        {
            var card = _CardRepository.GetCard(id);
            return Json(new
            {
                data = card,
                status = true
            });
        }

        public IActionResult ChangeStatus(string id)
        {
            bool status;
            string message = string.Empty;
            var Card = _CardRepository.GetCard(id);
            if (Card == null)
            {
                status = false;
                message = ResultState.NotFound;
            }
            else
            {
                Card.Status = !Card.Status;
                _CardRepository.SaveChange();
                status = Card.Status;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }
        [HttpPost]
        public IActionResult AddMenhGia(string mg)
        {
            var data = JsonConvert.DeserializeObject<MenhGia>(mg);
            var status = false;
            var message = "";
            try
            {
                _menhgiaRepository.AddMenhGia(data);
                _menhgiaRepository.SaveChange();
                status = true;
                message = ResultState.Add_SUCCESS;
            }
            catch (Exception)
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
        
        [HttpGet]
        public IActionResult history()
        {
            return View();
        }
        
    }

}
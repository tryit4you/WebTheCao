using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.SharedComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(string filter, int page, int pageSize = 10)
        {
            var contacts = _contactRepository.Contacts().Skip((page - 1) * pageSize).Take(pageSize).ToList();
           
            var totalRows = contacts.Count;
            return Ok(new
            {
                data = contacts,
                total = totalRows,
                status = true
            });
        }

        [HttpPost]
        public IActionResult Post(string contact)
        {
            var status = false;
            string message = string.Empty;
            var data = JsonConvert.DeserializeObject<Contact>(contact);
        
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    data.UserId = userId;
                    _contactRepository.AddContact(data);
                    _contactRepository.SaveChange();
                    status = true;
                    message = ResultState.Add_SUCCESS;

                }
              
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
        public IActionResult Put(string contact)
        {
            var status = false;
            string message = string.Empty;
            var data = JsonConvert.DeserializeObject<Contact>(contact);
            try
            {
                if (User.Identity.IsAuthenticated)
                {
                    var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    data.UserId = userId;
                    var result = _contactRepository.Update(data);
                    if (result)
                        _contactRepository.SaveChange();
                }
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
            var result = _contactRepository.Delete(id);
            _contactRepository.SaveChange();
            return Json(new
            {
                status = true,
                message = ResultState.Delete_SUCCESS
            });
        }

        [HttpPost]
        public IActionResult GetDetail(string id)
        {
            var contact = _contactRepository.GetContact(id);
            return Json(new
            {
                data = contact,
                status = true
            });
        }

  
        public IActionResult ChangeStatus(string id)
        {
            bool status;
            string message = string.Empty;
            var contact = _contactRepository.GetContact(id);
            if (contact == null)
            {
                status = false;
                message = ResultState.NotFound;
            }
            else
            {
                contact.Status = !contact.Status;
                _contactRepository.SaveChange();
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
                    _contactRepository.Delete(id);
                }
                status = true;
                message = ResultState.Delete_SUCCESS;
            }
            catch
            {
                status = false;
                message = ResultState.Delete_FALSE;
            }
            _contactRepository.SaveChange();
            return Json(new
            {
                status = status,
                message = message
            });
        }
    }
}
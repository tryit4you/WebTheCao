using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.SharedComponents;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAll(string filter, int page, int pageSize = 10)
        {
            var totalRows = 0;
            var posts = _postRepository.Posts();
            totalRows = posts.Count();

            if (!string.IsNullOrEmpty(filter))
            {
                posts = posts.Where(p => p.Name.ToLower().Contains(filter)).OrderBy(x => x.Name).ToList();
                totalRows = posts.Count();
            }
            var model = posts.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(new
            {
                data = model,
                total = totalRows,
                status = true
            });
        }

        [HttpPost]
        public IActionResult Post(string post)
        {
            var status = false;
            string message = ResultState.Add_FALSE;
            var data = JsonConvert.DeserializeObject<Post>(post);
            if (User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                data.UserId = userId;
                _postRepository.AddPost(data);
                _postRepository.SaveChange();
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
        public IActionResult Put(string post)
        {
            var status = false;
            string message = ResultState.Update_FALSE;
            var data = JsonConvert.DeserializeObject<Post>(post);
            if (User.Identity.IsAuthenticated)
            {
                var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                data.UserId = userId;
                var result = _postRepository.Update(data);
                if (result)
                {
                    _postRepository.SaveChange();
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
                var result = _postRepository.Delete(id);
                _postRepository.SaveChange();
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
        public IActionResult DeleteMul(string[] ids)
        {
            var status = false;
            string message = string.Empty;
            try
            {
                foreach (var id in ids)
                {
                    _postRepository.Delete(id);
                }
                status = true;
                message = ResultState.Delete_SUCCESS;
            }
            catch
            {
                status = false;
                message = ResultState.Delete_FALSE;
            }
            _postRepository.SaveChange();
            return Json(new
            {
                status = status,
                message = message
            });
        }
        [HttpPost]
        public IActionResult GetDetail(string id)
        {
            var post = _postRepository.GetPost(id);
            return Json(new
            {
                data = post,
                status = true
            });
        }

        [HttpPost]
        public IActionResult CheckExist(string name)
        {
            var result = _postRepository.CheckName(name);
            return Json(new
            {
                result = result
            });
        }

        public IActionResult ChangeStatus(string id)
        {
            bool status;
            string message = string.Empty;
            var post = _postRepository.GetPost(id);
            if (post == null)
            {
                status = false;
                message = ResultState.NotFound;
            }
            else
            {
                post.Status = !post.Status;
                _postRepository.SaveChange();
                status = post.Status;
            }
            return Json(new
            {
                status = status,
                message = message
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using WebTheCao.SharedComponents;
using WebTheCao.ViewModels;

namespace WebTheCao.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public PostController(IPostRepository postRepository,
            UserManager<ApplicationUser> userManager)
        {
            _postRepository = postRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult GetAll(string filter, int page, int pageSize = 10)
        {
            var totalRows = 0;
            var posts = (from p in _postRepository.Posts()
                         where p.Status == true
                         orderby p.CreatedDate descending
                         select new PostViewModels
                         {
                             Id=p.Id,Name=p.Name,MetaName=p.MetaName,Avatar=p.Avatar,TimePost=ConvertToTimeSpan.Convert(p.CreatedDate)
                         }).ToList();
            totalRows = posts.Count();
            if (!string.IsNullOrEmpty(filter))
            {
                posts = posts.Where(p => EF.Functions.Like(p.Name, "%" + filter + "%") ).OrderBy(x => x.Name).ToList();
                totalRows = posts.Count();
            }
            posts = posts.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Ok(new
            {
                filter = filter,
                data = posts,
                total = totalRows,
                page = page,
                status = true
            });
        }
        public IActionResult Detail(string id)
        {
            string usersPost = string.Empty;
            var postDetail = _postRepository.GetPost(id);
            usersPost = _userManager.Users.SingleOrDefault(x=>x.Id==postDetail.UserId).UserName.ToString();
            
            var PostVM = new PostViewModels
            {
                Id = postDetail.Id,
                Content = postDetail.Content,
                LinkVia = postDetail.LinkVia,
                Name = postDetail.Name,
                TimePost = ConvertToTimeSpan.Convert(postDetail.CreatedDate),
                Via = postDetail.Via,
                UserName = usersPost
            };

            return View(PostVM);
        }
    }
}
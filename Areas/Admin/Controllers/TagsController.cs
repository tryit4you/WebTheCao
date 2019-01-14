using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebTheCao.Areas.Admin.Controllers
{
    public class TagsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
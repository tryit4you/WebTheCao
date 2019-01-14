using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Administrator")]
    [Route("admin/[controller]/[action]")]
    public class UploadFileManagerController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public UploadFileManagerController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var result = false;
            var path = Path.Combine(
                       _hostingEnvironment.WebRootPath + @"\images\", Path.GetFileName(file.FileName));
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    result = true;
                }
            }
            catch
            {
                result = false;
            }

            return Ok(new
            {
                status = result
            });
        }

        public IActionResult GetImgLib(string filter, bool sort = true)
        {
            string capacity = string.Empty;
            List<string> fileNames = new List<string>();

            string webRootPath = _hostingEnvironment.WebRootPath;
            fileNames.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(webRootPath + @"\images\");
            List<FileInfo> result = new List<FileInfo>();
            if (sort)
            {
                result = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories).OrderByDescending(x => x.CreationTime).ToList();
            }
            else
            {
                result = directoryInfo.GetFiles("*.*", SearchOption.AllDirectories).OrderBy(x => x.CreationTime).ToList();
            }

            foreach (var path in result)
            {
                if (!string.IsNullOrWhiteSpace(filter) && path.ToString().ToLower().Contains(filter))
                {
                    fileNames.Add(Path.GetFileName(path.ToString()));
                }
                if (string.IsNullOrWhiteSpace(filter))
                {
                    fileNames.Add(Path.GetFileName(path.ToString()));
                }
            }
            capacity = (result.Sum(x => x.Length) / 1024).ToString("N");
            var count = fileNames.Count;

            return Json(new
            {
                data = fileNames,
                count = count,
                capacity = capacity
            });
        }

        [HttpPost]
        //xóa hình ảnh trên thư mục gốc
        public IActionResult RemoveFileImage(string path)
        {
            bool status = false;
            var rootpath = _hostingEnvironment.WebRootPath;
            var filePath = rootpath + path;
            try
            {
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                    status = true;
                }
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
    }
}
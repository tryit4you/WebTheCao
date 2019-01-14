using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Areas.Admin.ViewModels
{
    public class SendMailViewModels
    {
        public string[] Ids { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Content { get; set; }

    }
}

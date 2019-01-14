using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Models
{
    public class Slide
    {
        [Key]
        public string Id { set; get; }

        [Required(ErrorMessage = "Yêu cầu nhập tên slide")]
        [MaxLength(256)]
        [DisplayName("Tên slide")]
        public string Name { set; get; }

        [Required]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Yêu cầu phải có hình ảnh")]
        [DisplayName("Hình ảnh ")]
        public string Image { set; get; }

        [MaxLength(256)]
        [DisplayName("Đường dẫn")]
        public string Url { set; get; }

        [DisplayName("Thứ tự hiển thị")]
        public int? DisplayOrder { set; get; }

        [DisplayName("Captant")]
        public string Captant { set; get; }
        [DisplayName("Vị trí tiêu để")]
        public string CaptantPostion { set; get; }
        

        [DisplayName("Nội dung")]
        public string Content { set; get; }
        [DisplayName("Trạng thái")]
        public bool Status { set; get; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

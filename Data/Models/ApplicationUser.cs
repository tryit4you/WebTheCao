using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        [DisplayName("Tên ")]
        public string DisplayName { get; set; }

        [DisplayName("Ghi chú")]
        public string Notes { get; set; }

        [Required]
        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        [DisplayName("Hình đại diện")]
        public string UrlAvatar { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [DisplayName("Sửa ngày cuối")]
        public DateTime LastModifiedDate { get; set; }
        [DisplayName("Tài khoản chính")]
        [DefaultValue(1)]
        public decimal TaiKhoanChinh { get; set; }
        [DisplayName("Tài khoản khuyến mãi")]
        [DefaultValue(1)]
        public decimal TaiKhoanKhuyenMai { get; set; }
        [DisplayName("Điểm")]
        [DefaultValue(1)]
        public decimal Points { get; set; }
        [DisplayName("Danh hiệu")]
        [DefaultValue(0)]
        public string DanhHieu { get; set; }
        public string Sdt { get; set; }
        [DefaultValue(1)]
        public bool Status { get; set; }
        public bool  ViewStatus { get; set; }
        public List<TaiKhoanNganHang> TaiKhoanNganHangs { get; set; }
        public virtual IEnumerable<Feedback> Feedbacks { get; set; }

    }
}

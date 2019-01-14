using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Models
{
    public class TaiKhoanNganHang
    {
        public string Id { get; set; }
        public string TenNH { get; set; }
        public string UserId { get; set; }
        public string SoTK { get; set; }
        public string NguoiThuHuong { get; set; }
        public string TenChiNhanh { get; set; }
        public bool Status { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

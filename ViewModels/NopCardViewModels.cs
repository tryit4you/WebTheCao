using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.ViewModels
{
    public class NopCardViewModels
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string LoaiThe { get; set; }
        public decimal MenhGia { get; set; }
        public decimal GiaChietKhau { get; set; }
        public int SoLuong { get; set; }
        public string NgayNopThe { get; set; }
        public string SoDienThoai { get; set; }
        public decimal required { get; set; }
        public string requiredLabel { get; set; }
        public string Notes { get; set; }
        public bool TrangThai { get; set; }
    }
}

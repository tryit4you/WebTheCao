using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface ITKNHRepository
    {
        IEnumerable<TaiKhoanNganHang> TaiKhoans();
        TaiKhoanNganHang GetTKhoan(string id);
        bool Delete(string id);
        bool Update(TaiKhoanNganHang tk);
        TaiKhoanNganHang AddTaiKhoan(TaiKhoanNganHang taikhoan);
        void SaveChange();
    }
}

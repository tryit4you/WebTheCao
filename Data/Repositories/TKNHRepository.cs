using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class TKNHRepository : ITKNHRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public TKNHRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public TaiKhoanNganHang AddTaiKhoan(TaiKhoanNganHang TKNH)
        {
            TKNH.Id = Guid.NewGuid().ToString();
            return _dbContext.TaiKhoanNganHangs.Add(TKNH).Entity;
        }

        public bool Delete(string id)
        {
            try
            {
                var TKNH = _dbContext.TaiKhoanNganHangs.FirstOrDefault(x => x.Id == id);
                _dbContext.TaiKhoanNganHangs.Remove(TKNH);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TaiKhoanNganHang GetTKhoan(string id) => _dbContext.TaiKhoanNganHangs.FirstOrDefault(x => x.Id == id);

        public IEnumerable<TaiKhoanNganHang> TKNHs() => _dbContext.TaiKhoanNganHangs.ToList();

        public bool Update(TaiKhoanNganHang TKNH)
        {
            try
            {
                var _TKNH = _dbContext.TaiKhoanNganHangs.FirstOrDefault(x => x.Id == TKNH.Id);
                _TKNH.TenNH = TKNH.TenNH;
                _TKNH.NguoiThuHuong = TKNH.NguoiThuHuong;
                _TKNH.TenChiNhanh = TKNH.TenChiNhanh;
                _TKNH.SoTK= TKNH.SoTK;
                _TKNH.Status = TKNH.Status;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SaveChange() => _dbContext.SaveChanges();

        public IEnumerable<TaiKhoanNganHang> TaiKhoans()
        => _dbContext.TaiKhoanNganHangs.ToList();

        public bool DeleteAll()
        {
            var data = _dbContext.TaiKhoanNganHangs.ToList();
            try
            {
                _dbContext.TaiKhoanNganHangs.RemoveRange(data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

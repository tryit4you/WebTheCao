using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class GiaoDichRepository : IGiaoDichRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public GiaoDichRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public GiaoDich AddGiaoDich(GiaoDich GiaoDich)
        {
            GiaoDich.Id = Guid.NewGuid().ToString();
            return _dbContext.GiaoDichs.Add(GiaoDich).Entity;
        }

        public bool Delete(string id)
        {
            try
            {
                var GiaoDich = _dbContext.GiaoDichs.FirstOrDefault(x => x.Id == id);
                _dbContext.GiaoDichs.Remove(GiaoDich);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public GiaoDich GetGiaoDich(string id) => _dbContext.GiaoDichs.FirstOrDefault(x => x.Id == id);

        public IEnumerable<GiaoDich> GiaoDichs() => _dbContext.GiaoDichs.ToList();

        public bool Update(GiaoDich GiaoDich)
        {
            try
            {
                var _GiaoDich = _dbContext.GiaoDichs.FirstOrDefault(x => x.Id == GiaoDich.Id);
                _GiaoDich.UserId = GiaoDich.UserId;
                _GiaoDich.CreatedDate = GiaoDich.CreatedDate;
                _GiaoDich.Content = GiaoDich.Content;
                _GiaoDich.SoTien = GiaoDich.SoTien;
                _GiaoDich.Notes = GiaoDich.Notes;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SaveChange() => _dbContext.SaveChanges();

        public IEnumerable<GiaoDich> giaoDiches()
        => _dbContext.GiaoDichs.OrderByDescending(x => x.CreatedDate).ToList();

        public bool DeleteAll()
        {
            var data = _dbContext.GiaoDichs.ToList();
            try
            {
                _dbContext.GiaoDichs.RemoveRange(data);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class MenhGiaRepository:IMenhGiaRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public MenhGiaRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MenhGia AddMenhGia(MenhGia MenhGia)
        {
            MenhGia.Id = Guid.NewGuid().ToString();
           return _dbContext.MenhGias.Add(MenhGia).Entity;
        }

        public bool Delete(string id)
        {
            try
            {
                var MenhGia = _dbContext.MenhGias.FirstOrDefault(x => x.Id == id);
                _dbContext.MenhGias.Remove(MenhGia);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MenhGia GetMenhGia(string id) => _dbContext.MenhGias.FirstOrDefault(x => x.Id == id);

        public IEnumerable<MenhGia> MenhGias() => _dbContext.MenhGias.ToList();

        public bool Update(MenhGia MenhGia)
        {
            try
            {
                var _MenhGia = _dbContext.MenhGias.FirstOrDefault(x => x.Id == MenhGia.Id);
                _MenhGia.cardId = MenhGia.cardId;
                _MenhGia.Point = MenhGia.Point;
                _MenhGia.Price = MenhGia.Price;
                _MenhGia.unit_Price = MenhGia.unit_Price;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SaveChange() => _dbContext.SaveChanges();
    }
}

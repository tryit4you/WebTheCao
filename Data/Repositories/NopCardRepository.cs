using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class NopCardRepository:INopCardRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public NopCardRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public NopCard AddNopCard(NopCard NopCard)
        {
            NopCard.Id = Guid.NewGuid().ToString();
           return _dbContext.NopCards.Add(NopCard).Entity;
        }

        public bool Delete(string id)
        {
            try
            {
                var NopCard = _dbContext.NopCards.FirstOrDefault(x => x.Id == id);
                _dbContext.NopCards.Remove(NopCard);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public NopCard GetNopCard(string id) => _dbContext.NopCards.FirstOrDefault(x => x.Id == id);

        public IEnumerable<NopCard> NopCards() => _dbContext.NopCards.ToList();

        public bool Update(NopCard NopCard)
        {
            try
            {
                var _NopCard = _dbContext.NopCards.FirstOrDefault(x => x.Id == NopCard.Id);
                _NopCard.UserId = NopCard.UserId;
                _NopCard.NgayNopCard = NopCard.NgayNopCard;
                _NopCard.NoiDung = NopCard.NoiDung;
                _NopCard.cardId= NopCard.cardId;
                _NopCard.Phone= NopCard.Phone;
                _NopCard.Email= NopCard.Email;
                _NopCard.menhgiaId= NopCard.menhgiaId;
                _NopCard.warenty= NopCard.warenty;

                _NopCard.Status = NopCard.Status;
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

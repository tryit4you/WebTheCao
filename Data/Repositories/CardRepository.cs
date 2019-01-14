using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class CardRepository:ICardRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public CardRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Card AddCard(Card card)
        {
            card.Id = Guid.NewGuid().ToString();
           return _dbContext.Cards.Add(card).Entity;
        }

        public bool Delete(string id)
        {
            try
            {
                var card = _dbContext.Cards.FirstOrDefault(x => x.Id == id);
                _dbContext.Cards.Remove(card);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Card GetCard(string id) => _dbContext.Cards.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Card> Cards() => _dbContext.Cards.ToList();

        public bool Update(Card card)
        {
            try
            {
                var _card = _dbContext.Cards.FirstOrDefault(x => x.Id == card.Id);
                _card.Name = card.Name;
                _card.thumbNail = card.thumbNail;
                _card.Status = card.Status;
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

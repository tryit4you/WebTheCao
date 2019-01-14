using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface ICardRepository
    {
        IEnumerable<Card> Cards();
        Card GetCard(string id);
        bool Delete(string id);
        bool Update(Card card);
        Card AddCard(Card card);
        void SaveChange();
    }
}

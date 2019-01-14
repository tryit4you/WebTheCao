using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface INopCardRepository
    {
        IEnumerable<NopCard> NopCards();
         NopCard GetNopCard(string id);
        bool Delete(string id);
        bool Update(NopCard NopCard);
        NopCard AddNopCard(NopCard NopCard);
        void SaveChange();
    }
}

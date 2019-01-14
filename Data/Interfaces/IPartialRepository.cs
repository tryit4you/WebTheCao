using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface IPartialRepository
    {
        IEnumerable<Partial> Partials();
        Partial GetPartial(string id);
        bool Delete(string id);
        bool Update(Partial Partial);
        Partial AddPartial(Partial Partial);
        void SaveChange();
    }
}

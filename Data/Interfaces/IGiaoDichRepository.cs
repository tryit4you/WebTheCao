using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface IGiaoDichRepository
    {
        IEnumerable<GiaoDich> giaoDiches();
        GiaoDich GetGiaoDich(string id);
        bool Delete(string id);
        bool DeleteAll();
        bool Update(GiaoDich giaodich);
        GiaoDich AddGiaoDich(GiaoDich giaodich);
        void SaveChange();
    }
}

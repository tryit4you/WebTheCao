using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface IMenhGiaRepository
    {
        IEnumerable<MenhGia> MenhGias();
        MenhGia GetMenhGia(string id);
        bool Delete(string id);
        bool Update(MenhGia menhgia);
        MenhGia AddMenhGia(MenhGia menhGia);
        void SaveChange();
    }
}

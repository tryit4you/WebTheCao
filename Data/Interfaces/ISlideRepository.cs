using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface ISlideRepository
    {
        IEnumerable<Slide> Slides();
        Slide GetSlide(string id);
        bool Delete(string id);
        bool Update(Slide slide);
        Slide AddSlide(Slide slide);
        bool CheckName(string name);
        void SaveChange();
    }
}

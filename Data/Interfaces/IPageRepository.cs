using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface IPageRepository
    {
        IEnumerable<Page> Pages();
        Page GetPage(string id);
        Page GetPageByName(string name);
        Page GetDefaultPage();
        bool Delete(string id);
        bool Update(Page Page);
        bool CheckName(string name);
        Page AddPage(Page Page);
        void SaveChange();
    }
}

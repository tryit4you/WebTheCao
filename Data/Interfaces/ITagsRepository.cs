using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface ITagsRepository
    {
        IEnumerable<Tags> Tags();
        Tags GetTag(string id);
        bool Delete(string id);
        bool Update(Tags tag);
        Tags AddTag(Tags tag);
        void SaveChange();
    }
}

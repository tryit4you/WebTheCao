using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Contacts();
        Contact GetContact(string id);
        bool Delete(string id);
        bool Update(Contact contact);
        Contact AddContact(Contact contact);
        void SaveChange();
    }
}

using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class ContactRepository:IContactRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public ContactRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Contact AddContact(Contact Contact)
        {
            Contact.Id = Guid.NewGuid().ToString();
           return _dbContext.Contacts.Add(Contact).Entity;
        }
    
        public bool Delete(string id)
        {
            try
            {
                var Contact = _dbContext.Contacts.FirstOrDefault(x => x.Id == id);
                _dbContext.Contacts.Remove(Contact);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Contact GetContact(string id) => _dbContext.Contacts.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Contact> Contacts() => _dbContext.Contacts.ToList();

        public bool Update(Contact Contact)
        {
            try
            {
                var _Contact = _dbContext.Contacts.FirstOrDefault(x => x.Id == Contact.Id);
                _Contact.PhoneNumber = Contact.PhoneNumber;
                _Contact.Email = Contact.Email;
                _Contact.Address = Contact.Address;
                _Contact.Facebook= Contact.Facebook;
                _Contact.FacebookLink= Contact.FacebookLink;
                _Contact.Zalo= Contact.Zalo;
                _Contact.UserId= Contact.UserId;
                _Contact.Status = Contact.Status;
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

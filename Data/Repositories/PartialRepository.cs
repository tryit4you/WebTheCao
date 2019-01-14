using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class PartialRepository:IPartialRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public PartialRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Partial AddPartial(Partial Partial)
        {
            Partial.Id = Guid.NewGuid().ToString();
           return _dbContext.Partials.Add(Partial).Entity;
        }

        public bool Delete(string id)
        {
            try
            {
                var Partial = _dbContext.Partials.FirstOrDefault(x => x.Id == id);
                _dbContext.Partials.Remove(Partial);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Partial GetPartial(string id) => _dbContext.Partials.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Partial> Partials() => _dbContext.Partials.ToList();

        public bool Update(Partial Partial)
        {
            try
            {
                var _Partial = _dbContext.Partials.FirstOrDefault(x => x.Id == Partial.Id);
                _Partial.Name = Partial.Name;
                _Partial.Content = Partial.Content;
                
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

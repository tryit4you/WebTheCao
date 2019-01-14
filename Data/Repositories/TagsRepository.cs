using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class TagsRepository:ITagsRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public TagsRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Tags AddTag(Tags Tags)
        {
            Tags.Id = Guid.NewGuid().ToString();
           return _dbContext.Tags.Add(Tags).Entity;
        }

        public bool Delete(string id)
        {
            try
            {
                var Tags = _dbContext.Tags.FirstOrDefault(x => x.Id == id);
                _dbContext.Tags.Remove(Tags);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Tags GetTag(string id) => _dbContext.Tags.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Tags> Tags() => _dbContext.Tags.ToList();

        public bool Update(Tags Tags)
        {
            try
            {
                var _Tags = _dbContext.Tags.FirstOrDefault(x => x.Id == Tags.Id);
                _Tags.MetaName = Tags.MetaName;
                _Tags.Name = Tags.Name;
                _Tags.Status = Tags.Status;
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

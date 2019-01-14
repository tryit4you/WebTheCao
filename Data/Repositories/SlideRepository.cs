using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class SlideRepository : ISlideRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public SlideRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Slide AddSlide(Slide slide)
        {
            slide.Id = Guid.NewGuid().ToString();
            return _dbContext.Slides.Add(slide).Entity;
        }
        public bool CheckName(string name)
        {
            var result = _dbContext.Slides.Where(x => x.Name.ToLower().Equals(name.ToLower())).SingleOrDefault();
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var slide = _dbContext.Slides.FirstOrDefault(x => x.Id == id);
                _dbContext.Slides.Remove(slide);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Slide GetSlide(string id)=> _dbContext.Slides.FirstOrDefault(x => x.Id == id);

        public void SaveChange() => _dbContext.SaveChanges();
        public IEnumerable<Slide> Slides() => _dbContext.Slides.ToList();

        public bool Update(Slide slide)
        {
            try
            {
                var _slide = _dbContext.Slides.FirstOrDefault(x => x.Id == slide.Id);
                _slide.Name = slide.Name;
                _slide.Image = slide.Image;
                _slide.Status = slide.Status;
                _slide.Captant = slide.Captant;
                _slide.CaptantPostion = slide.CaptantPostion;
                _slide.Content = slide.Content;
                _slide.UserId = slide.UserId;
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}

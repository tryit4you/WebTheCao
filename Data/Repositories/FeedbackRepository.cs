using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Repositories
{
    public class FeedbackRepository:IFeedbackRepository
    {
        private readonly WebTheCaoDbContext _dbContext;
        public FeedbackRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Feedback AddFeedback(Feedback feedback)
        {
            feedback.ID = Guid.NewGuid().ToString();
           return _dbContext.Feedbacks.Add(feedback).Entity;
        }

        public bool Delete(string id)
        {
            try
            {
                var feedback = _dbContext.Feedbacks.FirstOrDefault(x => x.ID == id);
                _dbContext.Feedbacks.Remove(feedback);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Feedback GetFeedback(string id) => _dbContext.Feedbacks.FirstOrDefault(x => x.ID == id);

        public IEnumerable<Feedback> Feedbacks() => _dbContext.Feedbacks.ToList();

        public bool Update(Feedback feedback)
        {
            try
            {
                var _feedback = _dbContext.Feedbacks.FirstOrDefault(x => x.ID == feedback.ID);
                _feedback.Subject = feedback.Subject;
                _feedback.Email = feedback.Email;
                _feedback.Message = feedback.Message;
                _feedback.Phone= feedback.Phone;
                _feedback.Status = feedback.Status;
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

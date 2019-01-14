using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface IFeedbackRepository
    {
        IEnumerable<Feedback> Feedbacks();
        Feedback GetFeedback(string id);
        bool Delete(string id);
        bool Update(Feedback Feedback);
        Feedback AddFeedback(Feedback Feedback);
        void SaveChange();
    }
}

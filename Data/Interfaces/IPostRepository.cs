using WebTheCao.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> Posts();
        Post GetPost(string id);
        bool Delete(string id);
        bool Update(Post post);
        Post AddPost(Post post);
        bool CheckName(string name);
        void SaveChange();
    }
}

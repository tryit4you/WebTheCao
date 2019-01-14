using System;
using System.Collections.Generic;
using System.Linq;
using WebTheCao.Data.Interfaces;
using WebTheCao.Data.Models;

namespace WebTheCao.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly WebTheCaoDbContext _dbContext;

        public PostRepository(WebTheCaoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Post AddPost(Post Post)
        {
            Post.Id = Guid.NewGuid().ToString();
            Post.CreatedDate = DateTime.Now;
            return _dbContext.Posts.Add(Post).Entity;
        }

        public bool Delete(string id)
        {
            try
            {
                var Post = _dbContext.Posts.FirstOrDefault(x => x.Id == id);
                _dbContext.Posts.Remove(Post);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Post GetPost(string id) => _dbContext.Posts.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Post> Posts() => _dbContext.Posts.ToList();

        public bool Update(Post Post)
        {
            try
            {
                var _Post = _dbContext.Posts.FirstOrDefault(x => x.Id == Post.Id);
                _Post.MetaName = Post.MetaName;
                _Post.Name = Post.Name;
                _Post.Avatar = Post.Avatar;
                _Post.Content = Post.Content;
                _Post.LastModified = DateTime.Now;
                _Post.Via = Post.Via;
                _Post.LinkVia = Post.LinkVia;
                _Post.Status = Post.Status;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SaveChange() => _dbContext.SaveChanges();

        public bool CheckName(string name)
        {
            var result= _dbContext.Posts.Where(x => x.Name.ToLower() == name.ToLower().Trim()).FirstOrDefault();
            if (result!=null)
            {
                return false;
            }
            return true;
        }
    }
}
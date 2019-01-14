using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTheCao.Data.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public List<Tags> Tags { get; set; }
        public string Name { get; set; }
        public string MetaName { get; set; }
        public string Avatar { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
        public string Via { get; set; }
        public string LinkVia { get; set; }
        public bool Status { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
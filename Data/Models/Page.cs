using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Models
{
    public class Page
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

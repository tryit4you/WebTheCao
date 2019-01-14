using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTheCao.Data.Models
{
    public class Feedback
    {

        [Key]
        public string ID { set; get; }
        public string FullName { get; set; }

        [StringLength(250)]
        [Required]
        public string Subject { set; get; }

        [Required]
        public string UserId { get; set; }

        [StringLength(250)]
        public string Email { set; get; }

        [StringLength(50)]
        public string Phone { set; get; }

        [StringLength(500)]
        public string Message { set; get; }

        public DateTime CreatedDate { set; get; }

        [Required]
        [DefaultValue(true)]
        public bool Status { set; get; }
        [Required]
        [DefaultValue(false)]
        public bool IsWaiting { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTheCao.Data.Models
{
    public class NopCard
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string cardId { get; set; }
        public string menhgiaId { get; set; }
        public int warenty { get; set; }
        public DateTime NgayNopCard { get; set; }
        public string NoiDung { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Required { get; set; }
        public bool Status { get; set; }
        public bool ViewStatus { get; set; }
        [ForeignKey("cardId")]
        public virtual Card Card { get; set; }

        [ForeignKey("menhgiaId")]
        public virtual MenhGia MenhGia { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
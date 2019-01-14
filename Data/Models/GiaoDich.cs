using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Models
{
    public class GiaoDich
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Content { get; set; }
        public decimal SoTien { get; set; }
        public string Notes { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

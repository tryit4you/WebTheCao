using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Models
{
    public class MenhGia
    {
        public string Id { get; set; }
        public string cardId { get; set; }
        [DisplayName("Mệnh giá thẻ")]
        [Required(ErrorMessage = "Yêu cầu nhập mệnh giá thẻ")]
        public decimal Price { get; set; }
        [DisplayName("Đơn giá")]
        [Required()]
        public decimal unit_Price { get; set; }
        [DisplayName("Điểm quy đổi")]
        public decimal Point { get; set; }
        [DisplayName("Đại lý")]
        public bool DaiLy { get; set; }
        [ForeignKey("cardId")]
        public virtual Card Card { get; set; }
    }
}

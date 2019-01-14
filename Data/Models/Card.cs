using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Models
{
    public class Card
    {
        [Key]
        public string Id { get; set; }
        [DisplayName("Tên thẻ")]
        public string Name { get; set; }
        public string thumbNail { get; set; }
        public List<MenhGia> MenhGias { get; set; }
        [DefaultValue(1)]
        public bool Status { get; set; }
    }
}

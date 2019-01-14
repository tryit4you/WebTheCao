using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Models
{
    public class Contact
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Facebook { get; set; }
        public string FacebookLink { get; set; }
        public string Zalo { get; set; }
        public string ZaloLink { get; set; }
        public bool  Status { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Data.Models
{
    public class Tags
    {
        [Key]
        public string Id { get; set; }
        [DisplayName("Tên tags:")]
        public string Name { get; set; }
        public string MetaName { get; set; }
        [DefaultValue(1)]
        public bool Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTheCao.Data.Models;

namespace WebTheCao.ViewModels
{
    public class CardViewModels
    {
        public IEnumerable<Card> Cards { get; set; }
        public List<DaiLyThe> DaiLyThes { get; set; }
    }
    public class DaiLyThe
    {
        public string LoaiTaiKhoan { get; set; }
        public string key { get; set; }
        public List<MenhGia> MenhGias { get; set; }
        public int CountItem { get; set; }
    }
}

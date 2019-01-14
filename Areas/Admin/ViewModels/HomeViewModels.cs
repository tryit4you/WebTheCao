using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Areas.Admin.ViewModels
{
    public class HomeViewModels
    {
        public AccountVm AccountVm { get; set; }
        public FeedbackVm FeedbackVm { get; set; }
        public NopTheVM NopTheVM { get; set; }
        public GiaoDichVM GiaoDichVM { get; set; }
    }
    public class NopTheVM
    {
        public int Total { get; set; }
        public int InToday { get; set; }
    }
    public class GiaoDichVM
    {
        public int Total { get; set; }
        public int InToday { get; set; }
    }
    public class AccountVm
    {
        public int Total { get; set; }
        public int RegisterToday { get; set; }
    }
    public class FeedbackVm
    {
        public int Total { get; set; }
        public int InToday { get; set; }
    }
   
}

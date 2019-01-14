using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebTheCao.Areas.Admin.ViewModels
{
    public class FeedbackViewModels
    {
        public IEnumerable<FeedbackData> FeedbackData { get; set; }
        public int InboxCount { get; set; }

    }
    public class FeedbackData
    {
        public string ID { get; set; }
        [Required(ErrorMessage ="Tiêu đề là bắt buộc nhập")]
        public string Subject { get; set; }
        [Required(ErrorMessage ="Email người nhận là bắt buộc")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Địa chỉ email không hợp lệ!")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Yêu cầu nội dung")]
        [MinLength(20)]
        public string Message { get; set; }
        public string UserName { get; set; }
        public string urlAvatar { get; set; }
        public string time { get; set; }
        public bool Status { get; set; }
        public bool IsWaiting { get; set; }
        public int InboxCount { get; set; }
        public int IsWaitingCount { get; set; }
    }
}
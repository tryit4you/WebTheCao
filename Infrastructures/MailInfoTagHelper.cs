//using WebTheCao.Data.Interfaces;
//using WebTheCao.Data.Models;
//using Microsoft.AspNetCore.Razor.TagHelpers;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebTheCao.Infrastructures
//{
//    [HtmlTargetElement("span",Attributes = "mail-info")]
//    public class MailInfoTagHelper:TagHelper
//    {
//        private readonly IFeedbackRepository _feedback;
//        public MailInfoTagHelper(IFeedbackRepository feedback)
//        {
//            _feedback = feedback;
//        }

//        [HtmlAttributeName("mail-info")]
//        public bool mailinfor { get; set; }
//        public override void Process(TagHelperContext context, TagHelperOutput output)
//        {
//            var countNewMess = _feedback.Feedbacks().Where(x => x.Status == false && DateTime.Now.Subtract(x.CreatedDate).Days<=0).Count();
//            var countWaitMess = _feedback.Feedbacks().Where(x => x.IsWaiting == true ).Count();
//            if (mailinfor)
//            {
//                string newMess=string.Empty,waitMess=string.Empty;
//                if (countNewMess!=0)
//                {
//                    newMess= "<span class='badge bg-green'>" + countNewMess + "</span>";
//                }
//                if (countWaitMess!=0)
//                {
//                    waitMess = "<span class='badge bg-orange'>" + countWaitMess + "</span>";
//                }
//                string outp = newMess + waitMess;
//                output.Content.SetHtmlContent(outp);
//            }
//            else
//            {
//                string outp = "";
//                output.Content.SetHtmlContent(outp);
//            }
//        }
//    }
//}

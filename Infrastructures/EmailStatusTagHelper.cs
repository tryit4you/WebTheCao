using WebTheCao.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Infrastructures
{
    [HtmlTargetElement("span",Attributes ="e-mail")]
    public class EmailStatusTagHelper:TagHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public EmailStatusTagHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HtmlAttributeName("e-mail")]
        public string Email { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var outp = string.Empty;
            var emailStatus = await _userManager.FindByEmailAsync(Email);
            if (emailStatus.EmailConfirmed)
            {
                outp = "<small class='label bg-green'>Active</small>";
            }
            else
            {
                outp = "<small class='label bg-orange'>NotActive</small>";
            }
             output.Content.SetHtmlContent(outp);
        }
    }
}

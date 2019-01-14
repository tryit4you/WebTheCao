using WebTheCao.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTheCao.Infrastructures
{
    [HtmlTargetElement("img", Attributes = "username")]
    public class AvatarTagHelper : TagHelper
    {
        private UserManager<ApplicationUser> _userManager;
        public AvatarTagHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HtmlAttributeName("username")]
        public string UserName { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var defaultAvatar = "/images/default-user.png";
            var result = await _userManager.FindByNameAsync(UserName);

            if (result.UrlAvatar != null)
            {
                output.Attributes.SetAttribute("src", result.UrlAvatar);
            }
            else
            {
                output.Attributes.SetAttribute("src", defaultAvatar);
            }

        }
    }
}

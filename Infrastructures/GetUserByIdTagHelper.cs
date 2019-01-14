using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using WebTheCao.Data.Models;

namespace WebTheCao.Infrastructures
{
    [HtmlTargetElement("td", Attributes = "userId")]
    public class GetUserByIdTagHelper : TagHelper
    {
        private UserManager<ApplicationUser> _userManager;

        public GetUserByIdTagHelper(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HtmlAttributeName("userId")]
        public string UserId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            var userName = user.DisplayName ?? user.UserName;
            output.Content.SetContent(userName);
        }
    }
}
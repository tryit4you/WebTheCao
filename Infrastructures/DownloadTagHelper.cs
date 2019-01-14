using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace WebTheCao.Infrastructures
{
    [HtmlTargetElement("span",Attributes ="count")]
    public class DownloadTagHelper:TagHelper
    {

        [HtmlAttributeName("count")]
        public int CountInput { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var outputCount = string.Empty;
            if (CountInput>=Math.Pow(10,3)&&CountInput<Math.Pow(10,6))
            {
                outputCount = Math.Floor((decimal)(CountInput / Math.Pow(10,3))).ToString() + "k";
            }
            else if(CountInput<Math.Pow(10,3))
            {
                outputCount = CountInput.ToString();
            }else if (CountInput >= Math.Pow(10, 6)){
                outputCount = Math.Floor((decimal)(CountInput / Math.Pow(10,6))).ToString() + "M";
            }
            output.Content.SetContent(outputCount);
            
        }
    }
}

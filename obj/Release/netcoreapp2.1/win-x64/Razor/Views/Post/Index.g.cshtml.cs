#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\Post\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d768f2a341cc87d804cdfdd43651d4acc2845e8c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Index), @"mvc.1.0.view", @"/Views/Post/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Post/Index.cshtml", typeof(AspNetCore.Views_Post_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\_ViewImports.cshtml"
using WebTheCao;

#line default
#line hidden
#line 2 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#line 3 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\_ViewImports.cshtml"
using WebTheCao.Data.Models;

#line default
#line hidden
#line 4 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\_ViewImports.cshtml"
using WebTheCao.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d768f2a341cc87d804cdfdd43651d4acc2845e8c", @"/Views/Post/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7be7b95835a93f517da478f2d45900646913a45c", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebTheCao.Data.Models.Post>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/components/postScript.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\Post\Index.cshtml"
  
    ViewData["Title"] = "Tin khuyến mãi";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(147, 172, true);
            WriteLiteral("<div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n\r\n        <div class=\"col-md-8 card-area\"  id=\"data-render\">\r\n        </div>\r\n        <div class=\"col-md-4\">\r\n            ");
            EndContext();
            BeginContext(320, 39, false);
#line 14 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\Post\Index.cshtml"
       Write(await Component.InvokeAsync("topViews"));

#line default
#line hidden
            EndContext();
            BeginContext(359, 163, true);
            WriteLiteral("\r\n\r\n        </div>\r\n       \r\n    </div>\r\n    <div class=\"pagination\" id=\"pagination\">\r\n    </div>\r\n</div>\r\n<script id=\"data-template\" type=\"x-tmpl-mustache\">\r\n    ");
            EndContext();
            BeginContext(523, 43, false);
#line 23 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\Post\Index.cshtml"
Write(await Html.PartialAsync("_postItemSummary"));

#line default
#line hidden
            EndContext();
            BeginContext(566, 13, true);
            WriteLiteral("\r\n</script>\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(596, 3, true);
                WriteLiteral(" \r\n");
                EndContext();
                BeginContext(599, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b5464f25d71f41539fc7b2f677db6fb0", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(656, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebTheCao.Data.Models.Post>> Html { get; private set; }
    }
}
#pragma warning restore 1591

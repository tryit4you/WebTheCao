#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\Shared\_postItemSummary.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67cf6f18c436f40c60a4bc0375913ec7c5b9b758"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__postItemSummary), @"mvc.1.0.view", @"/Views/Shared/_postItemSummary.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_postItemSummary.cshtml", typeof(AspNetCore.Views_Shared__postItemSummary))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67cf6f18c436f40c60a4bc0375913ec7c5b9b758", @"/Views/Shared/_postItemSummary.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7be7b95835a93f517da478f2d45900646913a45c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__postItemSummary : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 460, true);
            WriteLiteral(@"

<div class=""card post-items"">
    <div class=""card-image post_item col-md-4"">
        <img src=""{{thumbnailUrl}}"" title=""{{name}}"">
    </div>
    <div class=""post-content col-md-8"">
        <h4><a href=""{{url}}"" title=""{{name}}"">{{name}}</a></h4>
        <div class=""desc"">
            <span class=""desc-time""> 

                <i class=""material-icons"">access_time</i> {{TimePost}}
            </span>

        </div>
    </div>

</div>
");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

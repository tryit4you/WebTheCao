#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71f3fd5946c25eb822db26d637267b3ba1f2367e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Home/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Home_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71f3fd5946c25eb822db26d637267b3ba1f2367e", @"/Areas/Admin/Views/Home/Index.cshtml")]
    public class Areas_Admin_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/dist/js/controller/homechartController.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Trang chủ";

#line default
#line hidden
            BeginContext(96, 64, true);
            WriteLiteral("\r\n\r\n<div class=\"alert alert-info align-center\">\r\n    Xin chào!! ");
            EndContext();
            BeginContext(161, 18, false);
#line 9 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Home\Index.cshtml"
          Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(179, 35, true);
            WriteLiteral("\r\n</div>\r\n\r\n<div class=\"row\">\r\n    ");
            EndContext();
            BeginContext(215, 44, false);
#line 13 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Home\Index.cshtml"
Write(await Component.InvokeAsync("HomeStatistic"));

#line default
#line hidden
            EndContext();
            BeginContext(259, 3330, true);
            WriteLiteral(@"
</div>
<div class=""clearfix"">
    <div class=""card"">
        <div class=""row"">
            <div class=""col-md-4"">
                <div class=""box box-solid bg-teal-gradient"">
                    <div class=""box-header"">
                        <i class=""fa fa-th""></i>
                        <h3 class=""box-title"">Thống kê nạp thẻ</h3>
                        <div class=""box-tools pull-right"">
                            <button type=""button"" class=""btn bg-teal btn-sm"" data-widget=""collapse"">
                                <i class=""fa fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn bg-teal btn-sm"" data-widget=""remove"">
                                <i class=""fa fa-times""></i>
                            </button>
                        </div>
                    </div>
                    <div class=""box-body border-radius-none"">
                        <canvas id=""colChartCardCount"" width=""400"" height=""400""></canvas>
");
            WriteLiteral(@"                    </div>
                </div>
            </div>     
            <div class=""col-md-4"">
                <div class=""box box-solid bg-teal-gradient"">
                    <div class=""box-header"">
                        <i class=""fa fa-th""></i>
                        <h3 class=""box-title"">Trạng thái nạp thẻ hôm nay</h3>
                        <div class=""box-tools pull-right"">
                            <button type=""button"" class=""btn bg-teal btn-sm"" data-widget=""collapse"">
                                <i class=""fa fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn bg-teal btn-sm"" data-widget=""remove"">
                                <i class=""fa fa-times""></i>
                            </button>
                        </div>
                    </div>
                    <div class=""box-body border-radius-none"">
                        <canvas id=""statusChartCardCount"" width=""400"" height=""400""></canv");
            WriteLiteral(@"as>
                    </div>
                </div>
            </div> 
           
        </div>
    </div>

</div>
<div class=""clearfix"">
    <div class=""card"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""box box-solid bg-aqua-gradient"">
                    <div class=""box-header"">
                        <i class=""fa fa-th""></i>
                        <h3 class=""box-title"">Biểu đồ doanh số bán thẻ điện thoại theo ngày</h3>
                        <div class=""box-tools pull-right"">
                            <button type=""button"" class=""btn bg-teal btn-sm"" data-widget=""collapse"">
                                <i class=""fa fa-minus""></i>
                            </button>
                            <button type=""button"" class=""btn bg-teal btn-sm"" data-widget=""remove"">
                                <i class=""fa fa-times""></i>
                            </button>
                        </div>
                    </div>
     ");
            WriteLiteral(@"               <div class=""box-body border-radius-none"">
                        <canvas id=""thunhapChartCard"" width=""400"" height=""130""></canvas>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
#line 87 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Home\Index.cshtml"
 if (User?.Identity?.IsAuthenticated ?? false)
{

#line default
#line hidden
            BeginContext(3640, 4, true);
            WriteLiteral("    ");
            EndContext();
            BeginContext(3644, 92, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb7843ba78ee4cb8a11326eb799d423f", async() => {
                BeginContext(3723, 9, true);
                WriteLiteral("Đăng xuất");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3736, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 91 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Home\Index.cshtml"
}

#line default
#line hidden
            DefineSection("jsFooter", async() => {
                BeginContext(3759, 12, true);
                WriteLiteral("\r\n    \r\n    ");
                EndContext();
                BeginContext(3771, 77, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2efb0a0ccf942ae9557d19163335931", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3848, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

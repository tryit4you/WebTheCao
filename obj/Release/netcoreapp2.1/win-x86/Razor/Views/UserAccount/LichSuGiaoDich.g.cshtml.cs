#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0db1b01d38a29d436ef3f1f76314f628ff79f772"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserAccount_LichSuGiaoDich), @"mvc.1.0.view", @"/Views/UserAccount/LichSuGiaoDich.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UserAccount/LichSuGiaoDich.cshtml", typeof(AspNetCore.Views_UserAccount_LichSuGiaoDich))]
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
#line 7 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0db1b01d38a29d436ef3f1f76314f628ff79f772", @"/Views/UserAccount/LichSuGiaoDich.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7be7b95835a93f517da478f2d45900646913a45c", @"/Views/_ViewImports.cshtml")]
    public class Views_UserAccount_LichSuGiaoDich : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebTheCao.Data.Models.ApplicationUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/components/giaodichScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
  
    ViewData["Title"] = "Lịch sử giao dịch";
    Layout = "~/Views/Shared/_Layout.cshtml";
    CultureInfo c = CultureInfo.GetCultureInfo("vi-VN");

#line default
#line hidden
            BeginContext(233, 302, true);
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-12""><h4 class=""header""> Thông tin giao dịch</h4> </div>
        <hr />
        <div class=""col-md-12"">


            <ul class=""list-group list-group-flush"">
                <input type=""hidden"" name=""userId"" id=""txtId""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 535, "\"", 552, 1);
#line 17 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
WriteAttributeValue("", 543, Model.Id, 543, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(553, 64, true);
            WriteLiteral(" />\r\n                <li class=\"list-group-item\">Tên tài khoản: ");
            EndContext();
            BeginContext(618, 14, false);
#line 18 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
                                                      Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(632, 66, true);
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">Số điện thoại: ");
            EndContext();
            BeginContext(699, 9, false);
#line 19 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
                                                      Write(Model.Sdt);

#line default
#line hidden
            EndContext();
            BeginContext(708, 68, true);
            WriteLiteral("</li>\r\n                <li class=\"list-group-item\">Tài khoản chính: ");
            EndContext();
#line 20 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
                                                               string tkc=Model.TaiKhoanChinh==0?"0 ":Model.TaiKhoanChinh.ToString("#,###", c.NumberFormat);

#line default
#line hidden
            BeginContext(873, 3, false);
#line 20 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
                                                                                                                                                        Write(tkc);

#line default
#line hidden
            EndContext();
            BeginContext(876, 92, true);
            WriteLiteral("<sup><u>đ</u></sup></li>\r\n                <li class=\"list-group-item\">Tài khoản Khuyến mãi: ");
            EndContext();
#line 21 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
                                                                    string tkkm = Model.TaiKhoanKhuyenMai == 0 ? "0 " : Model.TaiKhoanKhuyenMai.ToString("#,###", c.NumberFormat);

#line default
#line hidden
            BeginContext(1082, 4, false);
#line 21 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
                                                                                                                                                                              Write(tkkm);

#line default
#line hidden
            EndContext();
            BeginContext(1086, 85, true);
            WriteLiteral("<sup><u>đ</u></sup></li>\r\n                <li class=\"list-group-item\">Điểm tích lũy: ");
            EndContext();
#line 22 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
                                                             string point = Model.Points == 0 ? "0 " : Model.Points.ToString("#,###", c.NumberFormat);

#line default
#line hidden
            BeginContext(1264, 5, false);
#line 22 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\LichSuGiaoDich.cshtml"
                                                                                                                                                  Write(point);

#line default
#line hidden
            EndContext();
            BeginContext(1269, 1112, true);
            WriteLiteral(@"</li>
            </ul>
            <br />


            <a href=""/giao-dich/nap-tien"" class=""btn btn-primary waves-effect light-blue"">Nạp tiền</a>
            <br />

        </div>



    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <h4 class=""header"">Danh sách các lần giao dịch gần đây nhất</h4>
        </div>
        <div class=""col-md-12"">
            <table class=""highlight"">
                <thead>
                    <tr>
                        <th>Thời gian</th>
                        <th>Số tiền</th>
                        <th>Nội Dung</th>
                        <th>Ghi chú</th>
                    </tr>
                </thead>

                <tbody id=""dataRender""></tbody>
            </table>
        </div>

    </div>
    <div class=""pagination"" id=""pagination"">
    </div>
</div>
<script id=""data-template"" type=""x-tmpl-mustache"">
    <tr class=""row_item"" data-id=""{{Id}}"">

        <td>{{Time}}</td>
        <td>{{SoTien}}<");
            WriteLiteral("/td>\r\n        <td>{{Content}}</td>\r\n        <td>{{Notes}}</td>\r\n    </tr>\r\n</script>\r\n\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(2399, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(2405, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88fd30deb8b44450858bf58b069f838e", async() => {
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
                BeginContext(2462, 4, true);
                WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebTheCao.Data.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591

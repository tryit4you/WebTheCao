#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a64ab966a66154402191f8d603773a4aa1de9cc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserAccount_Profile), @"mvc.1.0.view", @"/Views/UserAccount/Profile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UserAccount/Profile.cshtml", typeof(AspNetCore.Views_UserAccount_Profile))]
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
#line 7 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a64ab966a66154402191f8d603773a4aa1de9cc8", @"/Views/UserAccount/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7be7b95835a93f517da478f2d45900646913a45c", @"/Views/_ViewImports.cshtml")]
    public class Views_UserAccount_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("frmEditAccount"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/components/userAccountScripts.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
  
    ViewData["Title"] = "Trang cá nhân";
    Layout = "~/Views/Shared/_Layout.cshtml";
    CultureInfo c = CultureInfo.GetCultureInfo("vi-VN");

#line default
#line hidden
            BeginContext(207, 201, true);
            WriteLiteral("\r\n\r\n<div class=\"container\">\r\n\r\n    <div id=\"thongtinTK\" class=\"col s12\">\r\n        <div class=\"frofile\">\r\n            <div class=\"avatar-frofile\">\r\n                <img class=\"materialboxed\" width=\"200\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 408, "\"", 430, 1);
#line 15 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
WriteAttributeValue("", 414, Model.UrlAvatar, 414, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 431, "\"", 452, 1);
#line 15 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
WriteAttributeValue("", 437, Model.UserName, 437, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(453, 805, true);
            WriteLiteral(@">

                <a class=""upload-Icon"" href=""#""> <i class=""material-icons"">collections</i></a>
                <input type=""file"" accept=""png/*"" name=""Image"" value=""Chọn hình"" class=""btn btn-primary upload-avatar"" />

            </div>
            <div class=""crop-avatar hidden"">
                <div id=""upload-demo"">

                </div>
                <div class=""footer center "" style=""margin-bottom:15px"">
                    <button class=""btn btn-primary wave-effect "" id=""cancelCropBtn"">Hủy</button>
                    <button class=""btn btn-default wave-effect "" id=""cropImageBtn"">Cắt ảnh &amp; lưu lại</button>
                </div>
            </div>

            <ul class=""list-group list-group-flush"">
                <input type=""hidden"" name=""userId"" id=""txtId""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1258, "\"", 1275, 1);
#line 32 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
WriteAttributeValue("", 1266, Model.Id, 1266, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1276, 81, true);
            WriteLiteral(" />\r\n                <li class=\"list-group-item\"><strong>Họ tên: </strong> <span>");
            EndContext();
            BeginContext(1359, 53, false);
#line 33 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
                                                                        Write(Model.DisplayName == null ? "___" : Model.DisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(1413, 99, true);
            WriteLiteral(" </span> </li>\r\n                <li class=\"list-group-item\"><strong>Tên tài khoản: </strong> <span>");
            EndContext();
            BeginContext(1513, 14, false);
#line 34 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
                                                                              Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1527, 101, true);
            WriteLiteral(" </span> </li>\r\n                <li class=\"list-group-item\"><strong> Số điện thoại: </strong><span>  ");
            EndContext();
            BeginContext(1629, 9, false);
#line 35 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
                                                                                Write(Model.Sdt);

#line default
#line hidden
            EndContext();
            BeginContext(1638, 99, true);
            WriteLiteral("</span></li>\r\n                <li class=\"list-group-item\"><strong> Tài khoản chính: </strong><span>");
            EndContext();
#line 36 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
                                                                                       string tkc = Model.TaiKhoanChinh == 0 ? "0 " : Model.TaiKhoanChinh.ToString("#,###", c.NumberFormat);

#line default
#line hidden
            BeginContext(1842, 3, false);
#line 36 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
                                                                                                                                                                                        Write(tkc);

#line default
#line hidden
            EndContext();
            BeginContext(1845, 125, true);
            WriteLiteral(" </span><sup><u>đ</u></sup> </li>\r\n                <li class=\"list-group-item\"><strong> Tài khoản Khuyến mãi: </strong><span>");
            EndContext();
#line 37 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
                                                                                            string tkkm = Model.TaiKhoanKhuyenMai == 0 ? "0 " : Model.TaiKhoanKhuyenMai.ToString("#,###", c.NumberFormat);

#line default
#line hidden
            BeginContext(2084, 4, false);
#line 37 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
                                                                                                                                                                                                      Write(tkkm);

#line default
#line hidden
            EndContext();
            BeginContext(2088, 119, true);
            WriteLiteral("</span><sup><u>đ</u></sup>  </li>\r\n                <li class=\"list-group-item\"><strong> Điểm tích lũy: </strong> <span>");
            EndContext();
#line 38 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
                                                                                      string point = Model.Points == 0 ? "0 " : Model.Points.ToString("#,###", c.NumberFormat);

#line default
#line hidden
            BeginContext(2300, 5, false);
#line 38 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
                                                                                                                                                                           Write(point);

#line default
#line hidden
            EndContext();
            BeginContext(2305, 132, true);
            WriteLiteral("</span></li>\r\n            </ul>\r\n\r\n        </div>\r\n        <br />\r\n        <div class=\"footer center \" style=\"margin-bottom:15px\">\r\n");
            EndContext();
#line 44 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
             if (User.IsInRole("Administrator"))
            {

#line default
#line hidden
            BeginContext(2502, 134, true);
            WriteLiteral("                <a href=\"/admin/home/index\">Đi đến quản trị<span class=\"material-icons\" aria-hidden=\"true\">developer_mode</span></a>\r\n");
            EndContext();
#line 47 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
            }

#line default
#line hidden
            BeginContext(2651, 266, true);
            WriteLiteral(@"            <a class=""waves-effect waves-light btn modal-trigger"" href=""#editModal"">Chỉnh sửa</a>
        </div>
    </div>



</div>

<div class=""modal"" id=""editModal"">
    <div class=""modal-content editModal"">
        <div class=""editform"">
            ");
            EndContext();
            BeginContext(2917, 1486, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a63cf3a8c5e149dc8a35474d93e51147", async() => {
                BeginContext(2943, 102, true);
                WriteLiteral("\r\n                <div class=\"row\">\r\n                    <input type=\"hidden\" name=\"userId\" id=\"txtId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3045, "\"", 3062, 1);
#line 61 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
WriteAttributeValue("", 3053, Model.Id, 3053, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3063, 142, true);
                WriteLiteral(" />\r\n\r\n                    <div class=\"input-field col s12\">\r\n                        <input placeholder=\"Họ tên\" id=\"displayName\" name=\"Name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3205, "\"", 3231, 1);
#line 64 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
WriteAttributeValue("", 3213, Model.DisplayName, 3213, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3232, 327, true);
                WriteLiteral(@" type=""text"" class=""validate"">
                        <label for=""displayName"">Họ tên</label>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""input-field col s12"">
                        <input placeholder=""Số điện thoại"" id=""phoneNumber"" name=""Phone""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3559, "\"", 3585, 1);
#line 70 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
WriteAttributeValue("", 3567, Model.PhoneNumber, 3567, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3586, 311, true);
                WriteLiteral(@" type=""text"" class=""validate"">
                        <label for=""phoneNumber"">Số điện thoại</label>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""input-field col s12"">
                        <input placeholder=""Địa chỉ"" id=""address""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 3897, "\"", 3919, 1);
#line 76 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
WriteAttributeValue("", 3905, Model.Address, 3905, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3920, 297, true);
                WriteLiteral(@" type=""text"" class=""validate"">
                        <label for=""address"">Địa chỉ</label>
                    </div>
                </div>
                <div class=""row"">
                    <div class=""input-field col s12"">
                        <input placeholder=""Email"" id=""Email""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4217, "\"", 4237, 1);
#line 82 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\Profile.cshtml"
WriteAttributeValue("", 4225, Model.Email, 4225, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4238, 158, true);
                WriteLiteral(" type=\"text\" class=\"validate\">\r\n                        <label for=\"address\">Email</label>\r\n                    </div>\r\n                </div>\r\n\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4403, 262, true);
            WriteLiteral(@"
        </div>
    </div>
    <div class=""modal-footer"">
        <a href=""#!"" class=""modal-close waves-effect waves-green btn-flat"">Hủy</a>
        <a href=""#"" class=""btn waves-effect waves-green btn-flat btnUpdate"">Cập nhật</a>
    </div>
</div>



");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4682, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(4690, 65, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a6d478405bc42299b1256424c0b9644", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4755, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591

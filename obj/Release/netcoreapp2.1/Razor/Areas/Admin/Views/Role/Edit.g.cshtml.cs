#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26e5f0cbc17f1f83b0835cd94680b8b127bb5b46"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Role_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Role/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Role/Edit.cshtml", typeof(AspNetCore.Areas_Admin_Views_Role_Edit))]
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
#line 2 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
using WebTheCao.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26e5f0cbc17f1f83b0835cd94680b8b127bb5b46", @"/Areas/Admin/Views/Role/Edit.cshtml")]
    public class Areas_Admin_Views_Role_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebTheCao.ViewModels.RoleViewModels>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Role", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(127, 142, true);
            WriteLiteral("<div class=\"alert alert-info align-center\">\r\n    Chỉnh sửa phân quyền\r\n</div>\r\n<div class=\"clearfix\">\r\n    <h6 class=\"bg-info alert\">Thêm vào ");
            EndContext();
            BeginContext(270, 15, false);
#line 8 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                                  Write(Model.Role.Name);

#line default
#line hidden
            EndContext();
            BeginContext(285, 11, true);
            WriteLiteral("</h6>\r\n    ");
            EndContext();
            BeginContext(296, 474, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "570d7a37b8ef43e5b083f99215d3f737", async() => {
                BeginContext(355, 234, true);
                WriteLiteral("\r\n        <div class=\"form-group form-inline\">\r\n            <div class=\"col-md-4\">\r\n                <input type=\"text\" name=\"userName\" placeholder=\"Tìm tài khoản\" class=\"form-control\" />\r\n                <input type=\"hidden\" name=\"id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 589, "\"", 611, 1);
#line 13 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
WriteAttributeValue("", 597, Model.Role.Id, 597, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(612, 151, true);
                WriteLiteral(" />\r\n                <input type=\"submit\" value=\"Tìm \" class=\"btn btn-primary\" />\r\n            </div>\r\n        </div><div class=\"clearfix\"></div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(770, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(776, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a87b144a7e4a47828831321036347647", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#line 18 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(836, 6, true);
            WriteLiteral("\r\n    ");
            EndContext();
            BeginContext(842, 2217, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78b13ee433fe40ffba785fcc9cab04a2", async() => {
                BeginContext(880, 46, true);
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"roleName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 926, "\"", 950, 1);
#line 20 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
WriteAttributeValue("", 934, Model.Role.Name, 934, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(951, 47, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"roleId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 998, "\"", 1020, 1);
#line 21 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
WriteAttributeValue("", 1006, Model.Role.Id, 1006, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1021, 244, true);
                WriteLiteral(" />\r\n        <table class=\"table table-hover table-sm\">\r\n            <tr>\r\n                <th>Tên tài khoản</th>\r\n                <th>Tên người dùng</th>\r\n                <th>Email</th>\r\n                <th>Thêm quyền</th>\r\n            </tr>\r\n");
                EndContext();
#line 29 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
             if (Model.NonMembers.Count() == 0)
            {

#line default
#line hidden
                BeginContext(1329, 68, true);
                WriteLiteral("                <tr><td colspan=\"2\">Tất cả là thành viên</td></tr>\r\n");
                EndContext();
#line 32 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
            }
            else
            {
                

#line default
#line hidden
#line 35 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                 foreach (ApplicationUser user in Model.NonMembers)
                {


#line default
#line hidden
                BeginContext(1535, 54, true);
                WriteLiteral("                    <tr>\r\n                        <td>");
                EndContext();
                BeginContext(1590, 13, false);
#line 39 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                       Write(user.UserName);

#line default
#line hidden
                EndContext();
                BeginContext(1603, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1639, 16, false);
#line 40 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                       Write(user.DisplayName);

#line default
#line hidden
                EndContext();
                BeginContext(1655, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(1691, 10, false);
#line 41 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                       Write(user.Email);

#line default
#line hidden
                EndContext();
                BeginContext(1701, 103, true);
                WriteLiteral("</td>\r\n                        <td>\r\n                            <input type=\"checkbox\" name=\"IdsToAdd\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1804, "\"", 1820, 1);
#line 43 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
WriteAttributeValue("", 1812, user.Id, 1812, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1821, 61, true);
                WriteLiteral(">\r\n                        </td>\r\n                    </tr>\r\n");
                EndContext();
#line 46 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                }

#line default
#line hidden
#line 46 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                 
            }

#line default
#line hidden
                BeginContext(1916, 56, true);
                WriteLiteral("        </table>\r\n        <h6 class=\"bg-info alert\">Xóa ");
                EndContext();
                BeginContext(1973, 15, false);
#line 49 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                                 Write(Model.Role.Name);

#line default
#line hidden
                EndContext();
                BeginContext(1988, 247, true);
                WriteLiteral("</h6>\r\n        <table class=\"table table-hover table-sm\">\r\n\r\n            <tr>\r\n                <th>Tên tài khoản</th>\r\n                <th>Tên người dùng</th>\r\n                <th>Email</th>\r\n                <th>Hủy quyền</th>\r\n            </tr>\r\n");
                EndContext();
#line 58 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
             if (Model.Members.Count() == 0)
            {

#line default
#line hidden
                BeginContext(2296, 77, true);
                WriteLiteral("                <tr><td colspan=\"2\">Không có tài khoản thành viên</td></tr>\r\n");
                EndContext();
#line 61 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
            }
            else
            {
                

#line default
#line hidden
#line 64 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                 foreach (ApplicationUser user in Model.Members)
                {

#line default
#line hidden
                BeginContext(2506, 54, true);
                WriteLiteral("                    <tr>\r\n                        <td>");
                EndContext();
                BeginContext(2561, 13, false);
#line 67 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                       Write(user.UserName);

#line default
#line hidden
                EndContext();
                BeginContext(2574, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2610, 16, false);
#line 68 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                       Write(user.DisplayName);

#line default
#line hidden
                EndContext();
                BeginContext(2626, 35, true);
                WriteLiteral("</td>\r\n                        <td>");
                EndContext();
                BeginContext(2662, 10, false);
#line 69 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                       Write(user.Email);

#line default
#line hidden
                EndContext();
                BeginContext(2672, 106, true);
                WriteLiteral("</td>\r\n                        <td>\r\n                            <input type=\"checkbox\" name=\"IdsToDelete\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2778, "\"", 2794, 1);
#line 71 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
WriteAttributeValue("", 2786, user.Id, 2786, 8, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2795, 61, true);
                WriteLiteral(">\r\n                        </td>\r\n                    </tr>\r\n");
                EndContext();
#line 74 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                }

#line default
#line hidden
#line 74 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Role\Edit.cshtml"
                 
            }

#line default
#line hidden
                BeginContext(2890, 98, true);
                WriteLiteral("        </table>\r\n        <button type=\"submit\" class=\"btn btn-primary\">Lưu lại</button>\r\n        ");
                EndContext();
                BeginContext(2988, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b6aa167127d472aaabbf1660c13edf1", async() => {
                    BeginContext(3036, 6, true);
                    WriteLiteral("Hủy bỏ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3046, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3059, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebTheCao.ViewModels.RoleViewModels> Html { get; private set; }
    }
}
#pragma warning restore 1591

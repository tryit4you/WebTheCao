#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Page\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e378aa3685a0a2edf3e86c6efc9ba74d67959ecf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Page_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Page/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Page/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Page_Index))]
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
#line 5 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Page\Index.cshtml"
using WebTheCao.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e378aa3685a0a2edf3e86c6efc9ba74d67959ecf", @"/Areas/Admin/Views/Page/Index.cshtml")]
    public class Areas_Admin_Views_Page_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/dist/js/controller/pageController.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Page\Index.cshtml"
  
    ViewBag.Title = "Quản lý nội dung footer";

#line default
#line hidden
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(87, 2859, true);
            WriteLiteral(@"

<div class=""alert alert-info align-center"">
    Nội dung footer
</div>

<div class=""clearfix"">
    <div class=""card "">
        <div class=""cart-in"">


            <ul class=""nav nav-tabs tab-col-teal"" role=""tablist"">
                <li role=""presentation"" class=""active"">
                    <a href=""#home"" data-toggle=""tab"">
                        <i class=""fa fa-table col-blue""></i> Nội dung
                    </a>
                </li>
                <li role=""presentation"">
                    <a href=""#create"" data-toggle=""tab"">
                        <i class=""fa fa-plus-circle col-green""></i> Tạo mới
                    </a>
                </li>
                <li role=""presentation"">
                    <a href=""#Edit"" data-toggle=""tab"">
                        <i class=""fa fa-edit col-orange""></i> Chỉnh sửa
                    </a>
                </li>


            </ul>
            <div class=""body"">
                <div class=""tab-content"">
                ");
            WriteLiteral(@"    <div role=""tabpanel"" class=""tab-pane fade in active"" id=""home"">

                        <div class=""form-content"">
                            <div class=""form-group form-inline pull-left"">
                                <div class=""form-line"">
                                    <input type=""text"" class=""form-control"" placeholder=""Tìm kiếm..."" name=""Search"" id=""txtSearch"">
                                    <button class=""btn bg-blue""><i class=""fa fa-search""></i></button>  <button class=""btn btn-danger"" id=""btn-Deletemulti""><i class=""fa fa-trash""></i>Xóa</button>
                                </div>
                                <hr />
                            </div>

                        </div>
                        <table class=""table table-hover"">
                            <thead>
                                <tr>
                                    <th style=""width:10%""><label><input type=""checkbox"" name=""selectAll"" value="""" id=""selectAll"" />Tất cả</label></th>
   ");
            WriteLiteral(@"                                 <th>Tên </th>
                                    <th>Trạng thái</th>
                                    <td>Thao tác</td>
                                </tr>
                            </thead>
                            <tbody id=""tbData""></tbody>
                        </table>
                        <div class=""col-sm-7"">
                            <div class=""dataTables_paginate paging_simple_numbers"" id=""DataTables_Table_0_paginate"">
                                <div class=""pagination"" id=""pagination"">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div role=""tabpanel"" class=""tab-pane fade in "" id=""create"">

                        ");
            EndContext();
            BeginContext(2947, 41, false);
#line 70 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Page\Index.cshtml"
                   Write(await Html.PartialAsync("_CreatePartial"));

#line default
#line hidden
            EndContext();
            BeginContext(2988, 133, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div role=\"tabpanel\" class=\"tab-pane fade in \" id=\"Edit\">\r\n                        ");
            EndContext();
            BeginContext(3122, 39, false);
#line 73 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Page\Index.cshtml"
                   Write(await Html.PartialAsync("_EditPartial"));

#line default
#line hidden
            EndContext();
            BeginContext(3161, 1150, true);
            WriteLiteral(@"
                    </div>
                </div>

            </div>
        </div>
    </div>

</div>
<script id=""data-template"" type=""x-tmpl-mustache"">
    <tr class=""row_item"" data-id=""{{ID}}"">
        <td>
            <input type=""checkbox"" id=""select-{{ID}}"" name=""selectAll"" data-id=""{{ID}}"" class=""chk-col-red selectedItem"" />
            <label for=""select-{{ID}}""></label>
        </td>
        <td>{{Name}}</td>
        <td >{{{Status}}}</td>

        <td>
            <a class=""col-green waves-effect btn-view"" href=""#"" data-toggle=""tool-tip"" data-placement=""top"" data-original-title=""Xóa hồ sơ"" data-id=""{{ID}}"">
                <i class=""fa fa-globe""></i>Xem
            </a>
            <a class=""col-pink waves-effect btn-delete"" href=""#"" data-toggle=""tool-tip"" data-placement=""top"" data-original-title=""Xóa hồ sơ"" data-id=""{{ID}}"">
                <i class=""fa fa-trash""></i>Xóa
            </a>
            <a href=""#Edit "" data-toggle=""tab"" class=""col-orange waves-effect btn-edi");
            WriteLiteral("t\" data-id=\"{{ID}}\">\r\n                <i class=\"fa fa-edit\"></i>Sửa\r\n            </a>\r\n        </td>\r\n    </tr>\r\n</script>\r\n\r\n");
            EndContext();
            DefineSection("jsFooter", async() => {
                BeginContext(4329, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4335, 72, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d74a9b999364a4fbf0d890d93ff2c3b", async() => {
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
                BeginContext(4407, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(4412, 1042, true);
            WriteLiteral(@"

<div class=""modal fade"" id=""pageViewModel"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"">
                    <span id=""modal-title""></span>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </h5>
            </div>
            <div class=""modal-body"">
                <div id=""content"">
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Hủy</button>
                    <button type=""button"" class=""btn btn-primary btnBrowser"">Chỉnh sửa</button>
                </div>
            </div>
        </div>
  ");
            WriteLiteral("  </div>\r\n</div>\r\n");
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

#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\history.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a40157c5bab8fe886204f7e7e9c760f6b7df2a66"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Card_history), @"mvc.1.0.view", @"/Areas/Admin/Views/Card/history.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Card/history.cshtml", typeof(AspNetCore.Areas_Admin_Views_Card_history))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a40157c5bab8fe886204f7e7e9c760f6b7df2a66", @"/Areas/Admin/Views/Card/history.cshtml")]
    public class Areas_Admin_Views_Card_history : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/dist/js/controller/lichsuController.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\history.cshtml"
  
    ViewBag.Title = "Lịch sử nộp thẻ";

#line default
#line hidden
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(102, 7397, true);
            WriteLiteral(@"
<div class=""alert alert-info align-center"">
    Lịch sử nộp thẻ
</div>
<div class=""clearfix"">
    <div class=""card "">
        <div class=""cart-in"">


            <ul class=""nav nav-tabs tab-col-teal"" role=""tablist"">
                <li role=""presentation"" class=""active"">
                    <a href=""#home"" data-toggle=""tab"">
                        <i class=""fa fa-table col-blue""></i> Thẻ cào
                    </a>
                </li>

            </ul>
            <div class=""body"">
                <div class=""tab-content"">
                    <div role=""tabpanel"" class=""tab-pane fade in active"" id=""home"">
                        <div class=""form-content col-md-12"">

                            <div class=""form-group pull-left form-line col-md-6"">

                                <h4>Lọc kết quả</h4>
                             
                                <div class=""col-md-6"">
                                    <div class=""radio"">
                                     ");
            WriteLiteral(@"   <label><input type=""radio"" class=""statusRad"" name=""trangthainap"" value=""1"">Đã nạp</label>
                                    </div>
                                    <div class=""radio"">
                                        <label><input type=""radio"" class=""statusRad"" name=""trangthainap"" value=""0"" checked>Chưa nạp</label>
                                    </div>
                                </div>


                            </div>
                            <div class=""form-group pull-right col-md-6"">
                                <div class=""form-line"">
                                    <div class=""col-md-8"">
                                        <input type=""text"" class=""form-control"" placeholder=""Tên tài khoản..."" name=""Search"" id=""txtSearch"">
                                    </div>
                                    <div class=""col-md-4"">
                                        <button class=""btn bg-blue btn-search""><i class=""fa fa-search""></i></button>
         ");
            WriteLiteral(@"                               <button class=""btn btn-danger"" id=""btn-Deletemulti""><i class=""fa fa-trash""></i>Xóa</button>
                                    </div>

                                </div>

                            </div>
                            <div class=""clearfix""></div>
                            <hr />
                        </div>
                        <table class=""table table-hover"">
                            <thead>
                                <tr>
                                    <th style=""width:10%""><label><input type=""checkbox"" name=""selectAll"" value="""" id=""selectAll"" />Tất cả</label></th>
                                    <th>Tên TK</th>
                                    <th>Điện thoại</th>
                                    <th>Ngày nộp</th>
                                    <th>Loại thẻ</th>
                                    <th>Mệnh giá thẻ</th>
                                    <th>Số lượng </th>
                             ");
            WriteLiteral(@"       <th>Trạng thái</th>
                                    <th>####</th>

                                </tr>
                            </thead>
                            <tbody id=""tbData""></tbody>
                        </table>


                    </div>

                </div>
                <div class=""paging-area"">
                    <div class=""col-sm-5"">
                        <div class=""dataTables_info"" id=""DataTables_Table_0_info"" role=""status"" aria-live=""polite"">
                            <p>Trang <mark><span id=""currentpage""></span></mark> /<mark><span id=""totalpage""></span></mark></p>
                        </div>
                    </div>

                    <div class=""col-sm-7"">
                        <div class=""dataTables_paginate paging_simple_numbers"" id=""DataTables_Table_0_paginate"">
                            <div class=""pagination"" id=""pagination"">
                            </div>
                        </div>
                    </div>");
            WriteLiteral(@"
                </div>
            </div>
        </div>
    </div>

</div>
<script id=""data-template"" type=""x-tmpl-mustache"">
    <tr class=""row_item"" data-id=""{{Id}}"">
        <td>
            <input type=""checkbox"" id=""select-{{ID}}"" name=""selectAll"" data-id=""{{ID}}"" class=""chk-col-red selectedItem"" />
            <label for=""select-{{ID}}""></label>
        </td>
        <td>{{UserName}}</td>
        <td>{{SoDienThoai}}</td>
        <td>{{NgayNopThe}}</td>

        <td>{{LoaiThe}}</td>
        <td>{{MenhGia}}</td>
        <td>{{SoLuong}}</td>

        <td>{{{TrangThai}}}</td>
        <td>
            <a class=""col-pink waves-effect btn-delete"" href=""#"" data-toggle=""tool-tip"" data-id=""{{Id}}"">
                <i class=""fa fa-trash""></i>Xóa
            </a>
        </td>
    </tr>
</script>

<div class=""modal fade"" id=""naptheModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered bg-white"">
     ");
            WriteLiteral(@"   <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""myModalLabel"">Thông tin thẻ nạp</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
            </div>
            <div class=""modal-body"">
                <div id=""naptheContent"" class=""center-block clearfix"">
                    <table class=""table table-hover"">
                        <input type=""hidden"" id=""hiddenId"" value="""" />
                        <tr>
                            <th>Tên TK</th>
                            <td id=""userName""></td>
                        </tr>
                        <tr>
                            <th>Điện thoại</th>
                            <td id=""phoneNumber""></td>
                        </tr>
                        <tr>
                            <th>Ngày nộp</th>
                            <td id=""createdDate""></td>
             ");
            WriteLiteral(@"           </tr>

                        <tr>
                            <th>Loại thẻ</th>
                            <td id=""typeCard""></td>
                        </tr>
                        <tr>
                            <th>Giá chiết khấu</th>

                            <td id=""unit_price""></td>
                        </tr>
                    
                        <tr>
                            <th>Số lượng </th>
                            <td id=""waranty""></td>
                        </tr>
                        <tr>
                            <th>Phí dịch vụ </th>
                            <td id=""phidichvu""></td>
                        </tr>
                   
                        <tr>
                            <th>Tổng cộng </th>
                            <td id=""totals""></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class=""modal-footer"">
                <button typ");
            WriteLiteral("e=\"button\" class=\"btn btn-default\" data-dismiss=\"modal\">Hủy</button>\r\n                <button type=\"button\" id=\"btnThanhToan\" class=\"btn btn-primary\">Thanh toán</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("jsFooter", async() => {
                BeginContext(7517, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(7548, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(7552, 70, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c2598e72ea34db0b3c78307f856fc60", async() => {
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
                BeginContext(7622, 4, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

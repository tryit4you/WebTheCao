#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\GiaoDich\CreatePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e7c60de127642127d6d00059824fa4b6e40c521"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_GiaoDich_CreatePartial), @"mvc.1.0.view", @"/Areas/Admin/Views/GiaoDich/CreatePartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/GiaoDich/CreatePartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_GiaoDich_CreatePartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e7c60de127642127d6d00059824fa4b6e40c521", @"/Areas/Admin/Views/GiaoDich/CreatePartial.cshtml")]
    public class Areas_Admin_Views_GiaoDich_CreatePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1843, true);
            WriteLiteral(@"<div class=""header"">
    <h3 id=""roomHeader"">Tạo mới Thông tin thẻ cào</h3>
</div>
<div class=""body"">
    <form role=""form"" id=""frmAddNew"">
        <input type=""hidden"" id=""txtId"">
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Category"">Tên tài khoản</label>
                <select id=""txtAccountName"" name=""AccountName"" aria-hidden=""true"" data-select2-id=""1"" tabindex=""-1"" class=""js-example-templating"">
                    <option value="""">Chọn tài khoản</option>
                </select>
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Content"">Số tiền  </label>
                <input type=""text"" class=""form-control"" name=""price"" id=""txtPrice"">
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""SoTien"">Nội dung giao dịch</label>
                <select id=""txtNoiDung"" name=""Con");
            WriteLiteral(@"tent"" aria-hidden=""true"" class=""js-example-templating"">
                    <option value=""1"">Nộp tiền vào tài khoản</option>
                    <option value=""0"">Thu hồi tiền của tài khoản</option>
                </select>
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Content"">Ghi chú </label>
                <textarea type=""text"" class=""form-control"" name=""Notes"" id=""txtNotes"" rows=""3""></textarea>
            </div>
        </div>

    </form>
    <div class=""form-group"">

        <button type=""button"" class=""btn btn-secondary waves-effect"" id=""btnCancle"" data-dismiss=""modal"">Hủy</button>
        <button type=""button"" class=""btn btn-primary waves-effect"" id=""btnAdd"">Thực hiện</button>
    </div>
</div>");
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

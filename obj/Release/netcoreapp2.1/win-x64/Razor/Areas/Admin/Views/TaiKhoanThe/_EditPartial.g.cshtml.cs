#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\TaiKhoanThe\_EditPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1eacb9e7ea0c6021cd521ffe1e9120c9caafe4da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_TaiKhoanThe__EditPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/TaiKhoanThe/_EditPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/TaiKhoanThe/_EditPartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_TaiKhoanThe__EditPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1eacb9e7ea0c6021cd521ffe1e9120c9caafe4da", @"/Areas/Admin/Views/TaiKhoanThe/_EditPartial.cshtml")]
    public class Areas_Admin_Views_TaiKhoanThe__EditPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1825, true);
            WriteLiteral(@"<div class=""header"">
    <h3 id=""Header"">Chỉnh sửa thông tin tài khoản thẻ</h3>
</div>

<div class=""body"">
    <form role=""form"" id=""frmUpdate"">
        <input type=""hidden"" id=""EditId"">
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Name"">Tên ngân hàng</label>
                <input type=""text"" class=""form-control"" name=""EditName"" id=""EditName"">
            </div>
        </div> <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Name"">Số tài khoản</label>
                <input type=""text"" class=""form-control"" name=""EditSoTK"" id=""EditSoTK"">
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Name"">Người thụ hưởng</label>
                <input type=""text"" class=""form-control"" name=""EditNguoiThuHuong"" id=""EditNguoiThuHuong"">
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-l");
            WriteLiteral(@"ine"">
                <label for=""Name"">Tên chi nhánh</label>
                <input type=""text"" class=""form-control"" name=""EditTenChiNhanh"" id=""EditTenChiNhanh"">
            </div>
        </div>
     
        <div class=""form-group"">
            <div class=""demo-switch-title"">Trạng thái</div>
            <div class=""switch"">
                <label><input type=""checkbox"" name=""Status"" id=""EditStatus""><span class=""lever switch-col-lime""></span></label>
            </div>
        </div>
    </form>
    <br />
    <div class=""form-group"">

        <button type=""button"" class=""btn btn-secondary waves-effect"" id=""btnCancle"" data-dismiss=""modal"">Hủy</button>
        <button type=""button"" class=""btn btn-primary waves-effect"" id=""SaveEdit"">Lưu thay đổi</button>
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

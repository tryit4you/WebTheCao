#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Contact\_CreatePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05049e35d0392e97207a848f6f9877d3c90395c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Contact__CreatePartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Contact/_CreatePartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Contact/_CreatePartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_Contact__CreatePartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"05049e35d0392e97207a848f6f9877d3c90395c3", @"/Areas/Admin/Views/Contact/_CreatePartial.cshtml")]
    public class Areas_Admin_Views_Contact__CreatePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2206, true);
            WriteLiteral(@"<div class=""header"">
    <h3 id=""roomHeader"">Tạo mới liên hệ</h3>
</div>
<div class=""body"">
    <form role=""form"" id=""frmAddNew"">
     
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Phone"">Điện thoại</label>
                <input type=""text"" class=""form-control"" name=""Phone"" id=""txtPhone"">
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Email"">Email</label>
                <input type=""email"" class=""form-control"" name=""Email"" id=""txtEmail"">
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Address"">Địa chỉ </label>
                <input type=""text"" class=""form-control"" name=""Address"" id=""txtAddress"">
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Facebook"">Tên facebook </label>
         ");
            WriteLiteral(@"       <input type=""text"" class=""form-control"" name=""Facebook"" id=""txtFacebookName"">
            </div>
        </div> <div class=""form-group"">
            <div class=""form-line"">
                <label for=""FacebookLink"">Link facebook </label>
                <input type=""text"" class=""form-control"" name=""FacebookLink"" id=""txtFacebookLink"">
            </div>
        </div><div class=""form-group"">
    <div class=""form-line"">
        <label for=""ZaloName"">Tên Zalo </label>
        <input type=""text"" class=""form-control"" name=""ZaloName"" id=""txtZaloName"">
    </div>
</div>
        <div class=""form-group"">
            <div class=""demo-switch-title"">Trạng thái</div>
            <div class=""switch"">
                <label><input type=""checkbox"" id=""txtStatus"" checked><span class=""lever switch-col-lime""></span></label>
            </div>
        </div>
    </form>
    <br />

    <br />
    <div class=""form-group"">

        <button type=""button"" class=""btn btn-secondary waves-effect"" id=""btn");
            WriteLiteral("Cancle\" data-dismiss=\"modal\">Hủy</button>\r\n        <button type=\"button\" class=\"btn btn-primary waves-effect\" id=\"btnAdd\">Tạo mới</button>\r\n    </div>\r\n</div>");
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

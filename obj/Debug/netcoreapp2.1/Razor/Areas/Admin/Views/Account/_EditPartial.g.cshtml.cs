#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Account\_EditPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "453856426f6fc61f3be33a38b9776a45f2338563"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Account__EditPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Account/_EditPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Account/_EditPartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_Account__EditPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"453856426f6fc61f3be33a38b9776a45f2338563", @"/Areas/Admin/Views/Account/_EditPartial.cshtml")]
    public class Areas_Admin_Views_Account__EditPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2040, true);
            WriteLiteral(@"<div class=""header"">
    <h3 id=""Header"">Chỉnh sửa</h3>
</div>

<div class=""body"">
    <form role=""form"" id=""frmUpdate"">
        <input type=""hidden"" id=""EditId"">
     <div class=""form-group"">
            <div class=""form-line"">
                <label for=""DisplayName"">Họ và Tên</label>
                <input type=""text"" class=""form-control"" name=""DisplayName"" id=""editName"">
            </div>
        </div> 
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""UserName"">Tên tài khoản</label>
                <input type=""text"" class=""form-control"" disabled name=""UserName"" id=""editUserName"">
            </div>
        </div> 
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""PhoneNumber"">Số điện thoại</label>
                <input type=""text"" class=""form-control"" name=""PhoneNumber"" id=""editPhone"">
            </div>
        </div>
       <div class=""form-group"">
            <div class=""form-lin");
            WriteLiteral(@"e"">
                <label for=""Email"">Email</label>
                <input type=""email"" class=""form-control""  name=""Email"" id=""editEmail"">
            </div>
        </div>   
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Email"">Mật khẩu</label>
                <input type=""password"" class=""form-control"" name=""Password"" id=""editPassword"">
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line""> 
                <label for=""Email"">Xác thực Mật khẩu</label>
                <input type=""password"" class=""form-control"" name=""ConfirmPassword"" id=""editConfirmPassword"">
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
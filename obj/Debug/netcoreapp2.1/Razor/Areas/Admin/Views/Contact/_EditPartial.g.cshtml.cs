#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Contact\_EditPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b273070dfdc720c7a1f47953b864f653d85bea1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Contact__EditPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Contact/_EditPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Contact/_EditPartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_Contact__EditPartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b273070dfdc720c7a1f47953b864f653d85bea1", @"/Areas/Admin/Views/Contact/_EditPartial.cshtml")]
    public class Areas_Admin_Views_Contact__EditPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2432, true);
            WriteLiteral(@"<div class=""header"">
    <h3 id=""roomHeader"">Chỉnh sửa</h3>
</div>

<div class=""body"">
    <form role=""form"" id=""frmUpdate"">
        <input type=""hidden"" id=""EditId"">
      
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Phone"">Điện thoại (<span class=""col-pink"">*</span>)</label>
                <input type=""text"" class=""form-control"" name=""Phone"" id=""EditPhone"" />
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Email"">Email</label>
                <input type=""email"" class=""form-control"" name=""Email"" id=""EditEmail"" />
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Address"">Địa chỉ </label>
                <input type=""text"" class=""form-control"" name=""Address"" id=""EditAddress"">
            </div>
        </div>
        <div class=""form-group"">
            <div class=""fo");
            WriteLiteral(@"rm-line"">
                <label for=""Facebook"">Tên facebook </label>
                <input type=""text"" class=""form-control"" name=""Facebook"" id=""editFacebookName"">
            </div>
        </div> <div class=""form-group"">
            <div class=""form-line"">
                <label for=""FacebookLink"">Link facebook </label>
                <input type=""text"" class=""form-control"" name=""FacebookLink"" id=""editFacebookLink"">
            </div>
        </div><div class=""form-group"">
            <div class=""form-line"">
                <label for=""ZaloName"">Tên Zalo </label>
                <input type=""text"" class=""form-control"" name=""ZaloName"" id=""editZaloName"">
            </div>
        </div>
        <div class=""form-group"">
            <div class=""demo-switch-title"">Trạng thái</div>
            <div class=""switch"">
                <label><input type=""checkbox"" id=""EditStatus"" checked><span class=""lever switch-col-lime""></span></label>
            </div>
        </div>
    </form>
    <br /");
            WriteLiteral(@">
    <span> Các trường được đánh dấu (<span class=""col-pink"">*</span>) được yêu cầu nhập</span>
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

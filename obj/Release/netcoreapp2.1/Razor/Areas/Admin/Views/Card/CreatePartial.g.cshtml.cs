#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\CreatePartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df21f22db14f97ace31c0adfa10095e47432cc85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Card_CreatePartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Card/CreatePartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Card/CreatePartial.cshtml", typeof(AspNetCore.Areas_Admin_Views_Card_CreatePartial))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df21f22db14f97ace31c0adfa10095e47432cc85", @"/Areas/Admin/Views/Card/CreatePartial.cshtml")]
    public class Areas_Admin_Views_Card_CreatePartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1435, true);
            WriteLiteral(@"<div class=""header"">
    <h3 id=""roomHeader"">Tạo mới Thông tin thẻ cào</h3>
</div>
<div class=""body"">
    <form role=""form"" id=""frmAddNew"">
        <input type=""hidden"" id=""txtId"">
        <div class=""form-group"">
            <div class=""form-line"">
                <label for=""Name"">Chọn loại thẻ cào</label>
                <input type=""text"" class=""form-control"" name=""Name"" id=""txtName"">
                <span class=""validate""></span>
            </div>
        </div>
        <div class=""form-group"">
            <div class=""form-inline"">
                <input type=""button""  value=""Chọn hình"" class=""btn btn-primary UploadModal"" />
            </div>
            <div class=""form-inline"">
                <img src="""" id=""txtImage"" name=""Image"" class=""Image"" style=""margin-top:20px"" width=""100"" />
            </div>

        </div>
    
        <div class=""form-group"">
            <div class=""demo-switch-title"">Trạng thái</div>
            <div class=""switch"">
                <label><inpu");
            WriteLiteral(@"t type=""checkbox"" id=""txtStatus"" checked><span class=""lever switch-col-lime""></span></label>
            </div>
        </div>
    </form>

    <div class=""form-group"">

        <button type=""button"" class=""btn btn-secondary waves-effect"" id=""btnCancle"" data-dismiss=""modal"">Hủy</button>
        <button type=""button"" class=""btn btn-primary waves-effect"" id=""btnAdd"">Tạo mới</button>
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

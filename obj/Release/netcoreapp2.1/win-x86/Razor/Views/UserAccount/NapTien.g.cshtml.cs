#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\NapTien.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b5c754f94d856f02e44aab7bfa7396be8cb2611"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserAccount_NapTien), @"mvc.1.0.view", @"/Views/UserAccount/NapTien.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/UserAccount/NapTien.cshtml", typeof(AspNetCore.Views_UserAccount_NapTien))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b5c754f94d856f02e44aab7bfa7396be8cb2611", @"/Views/UserAccount/NapTien.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7be7b95835a93f517da478f2d45900646913a45c", @"/Views/_ViewImports.cshtml")]
    public class Views_UserAccount_NapTien : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<WebTheCao.Data.Models.TaiKhoanNganHang>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\NapTien.cshtml"
  
    ViewData["Title"] = "Thông tin chuyển khoản";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(165, 52, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 10 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\NapTien.cshtml"
         foreach (var tk in Model)
        {


#line default
#line hidden
            BeginContext(266, 97, true);
            WriteLiteral("            <div class=\"col-md-6 group_tk\">\r\n                <h4 class=\"header\">Chuyển khoản qua ");
            EndContext();
            BeginContext(364, 8, false);
#line 14 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\NapTien.cshtml"
                                               Write(tk.TenNH);

#line default
#line hidden
            EndContext();
            BeginContext(372, 154, true);
            WriteLiteral("</h4>\r\n                <ul class=\"list-group list-group-flush\">\r\n                    <li class=\"list-group-item\"><strong> Số tài khoản: </strong> <span>  ");
            EndContext();
            BeginContext(527, 7, false);
#line 16 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\NapTien.cshtml"
                                                                                    Write(tk.SoTK);

#line default
#line hidden
            EndContext();
            BeginContext(534, 103, true);
            WriteLiteral("</span></li>\r\n                    <li class=\"list-group-item\"><strong> Người thụ hưởng:</strong><span> ");
            EndContext();
            BeginContext(638, 16, false);
#line 17 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\NapTien.cshtml"
                                                                                    Write(tk.NguoiThuHuong);

#line default
#line hidden
            EndContext();
            BeginContext(654, 98, true);
            WriteLiteral("</span></li>\r\n                    <li class=\"list-group-item\"><strong> Ngân hàng: </strong> <span>");
            EndContext();
            BeginContext(753, 14, false);
#line 18 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\NapTien.cshtml"
                                                                               Write(tk.TenChiNhanh);

#line default
#line hidden
            EndContext();
            BeginContext(767, 188, true);
            WriteLiteral("</span></li>\r\n                    <li class=\"list-group-item\"><strong> Nội dung chuyển khoản:</strong><span>Nạp tiền vào tài khoản</span> </li>\r\n                </ul>\r\n            </div>\r\n");
            EndContext();
#line 22 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Views\UserAccount\NapTien.cshtml"
        } 

#line default
#line hidden
            BeginContext(967, 26, true);
            WriteLiteral("    </div>\r\n    \r\n</div>  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<WebTheCao.Data.Models.TaiKhoanNganHang>> Html { get; private set; }
    }
}
#pragma warning restore 1591

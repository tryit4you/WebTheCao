#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\_loadByCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4962c6c3a454479b2e2b9c1a0a3a97bf13648c5b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Card__loadByCard), @"mvc.1.0.view", @"/Areas/Admin/Views/Card/_loadByCard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Card/_loadByCard.cshtml", typeof(AspNetCore.Areas_Admin_Views_Card__loadByCard))]
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
#line 2 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\_loadByCard.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4962c6c3a454479b2e2b9c1a0a3a97bf13648c5b", @"/Areas/Admin/Views/Card/_loadByCard.cshtml")]
    public class Areas_Admin_Views_Card__loadByCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebTheCao.Data.Models.MenhGia>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\_loadByCard.cshtml"
  

    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");

#line default
#line hidden
            BeginContext(137, 32, true);
            WriteLiteral("\r\n<tr class=\"row_item\" data-id=\"");
            EndContext();
            BeginContext(170, 8, false);
#line 8 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\_loadByCard.cshtml"
                         Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(178, 16, true);
            WriteLiteral("\">\r\n\r\n<td>\r\n    ");
            EndContext();
            BeginContext(195, 47, false);
#line 11 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\_loadByCard.cshtml"
Write(Model.Price.ToString("#,###", cul.NumberFormat));

#line default
#line hidden
            EndContext();
            BeginContext(242, 19, true);
            WriteLiteral("\r\n</td>\r\n<td>\r\n    ");
            EndContext();
            BeginContext(262, 52, false);
#line 14 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\_loadByCard.cshtml"
Write(Model.unit_Price.ToString("#,###", cul.NumberFormat));

#line default
#line hidden
            EndContext();
            BeginContext(314, 19, true);
            WriteLiteral("\r\n</td>\r\n<td>\r\n    ");
            EndContext();
            BeginContext(334, 29, false);
#line 17 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\_loadByCard.cshtml"
Write(Model.Point.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(363, 76, true);
            WriteLiteral("\r\n</td>\r\n\r\n<td>\r\n\r\n    <a class=\"badge bg-red btn-delete\" href=\"#\" data-id=\"");
            EndContext();
            BeginContext(440, 8, false);
#line 22 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\_loadByCard.cshtml"
                                                    Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(448, 120, true);
            WriteLiteral("\">\r\n        <i class=\"fa fa-trash\"></i>Xóa\r\n    </a>\r\n    <a href=\"# \" class=\"badge bg-orange-active btn-edit\" data-id=\"");
            EndContext();
            BeginContext(569, 8, false);
#line 25 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Card\_loadByCard.cshtml"
                                                             Write(Model.Id);

#line default
#line hidden
            EndContext();
            BeginContext(577, 67, true);
            WriteLiteral("\">\r\n        <i class=\"fa fa-edit\"></i>Sửa\r\n    </a>\r\n</td>\r\n</tr>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebTheCao.Data.Models.MenhGia> Html { get; private set; }
    }
}
#pragma warning restore 1591

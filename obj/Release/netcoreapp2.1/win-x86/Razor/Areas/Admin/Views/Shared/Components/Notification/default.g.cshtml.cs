#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e4ebee221183e23df8090f0fafc3a2d38b9cb2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Components_Notification_default), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Components/Notification/default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/Components/Notification/default.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared_Components_Notification_default))]
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
#line 2 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
using WebTheCao.Areas.Admin.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e4ebee221183e23df8090f0fafc3a2d38b9cb2b", @"/Areas/Admin/Views/Shared/Components/Notification/default.cshtml")]
    public class Areas_Admin_Views_Shared_Components_Notification_default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NopTheViewModels>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(79, 142, true);
            WriteLiteral("\r\n<li class=\"dropdown messages-menu\">\r\n    <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">\r\n        <i class=\"fa fa-bell-o\"></i>\r\n");
            EndContext();
#line 7 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
         if (Model.Count() != 0)
        {

#line default
#line hidden
            BeginContext(266, 46, true);
            WriteLiteral("            <span class=\"label label-success\">");
            EndContext();
            BeginContext(313, 13, false);
#line 9 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                                         Write(Model.Count());

#line default
#line hidden
            EndContext();
            BeginContext(326, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 10 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
        }

#line default
#line hidden
            BeginContext(346, 76, true);
            WriteLiteral("    </a>\r\n    <ul class=\"dropdown-menu\">\r\n        <li class=\"header\">Bạn có ");
            EndContext();
            BeginContext(423, 13, false);
#line 13 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                             Write(Model.Count());

#line default
#line hidden
            EndContext();
            BeginContext(436, 128, true);
            WriteLiteral(" yêu cầu nạp thẻ!</li>\r\n        <li>\r\n            <!-- inner menu: contains the actual data -->\r\n            <ul class=\"menu\">\r\n");
            EndContext();
#line 17 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(629, 165, true);
            WriteLiteral("                    <li>\r\n                        <!-- start message -->\r\n                        <a href=\"/admin/card/history\">\r\n                            <div>\r\n");
            EndContext();
#line 23 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                                 if (item.avatar != null)
                                {

#line default
#line hidden
            BeginContext(888, 40, true);
            WriteLiteral("                                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 928, "\"", 946, 1);
#line 25 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
WriteAttributeValue("", 934, item.avatar, 934, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(947, 19, true);
            WriteLiteral(" class=\"img-circle\"");
            EndContext();
            BeginWriteAttribute("alt", " alt=\"", 966, "\"", 986, 1);
#line 25 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
WriteAttributeValue("", 972, item.userName, 972, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(987, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
#line 26 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(1098, 50, true);
            WriteLiteral("                                    <span><strong>");
            EndContext();
            BeginContext(1149, 13, false);
#line 29 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                                             Write(item.userName);

#line default
#line hidden
            EndContext();
            BeginContext(1162, 35, true);
            WriteLiteral(" </strong> yêu cầu nộp thẻ</span>\r\n");
            EndContext();
#line 30 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                                }

#line default
#line hidden
            BeginContext(1232, 104, true);
            WriteLiteral("                            </div>\r\n                            <span>\r\n                                ");
            EndContext();
            BeginContext(1337, 12, false);
#line 33 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                           Write(item.loaithe);

#line default
#line hidden
            EndContext();
            BeginContext(1349, 34, true);
            WriteLiteral("\r\n                                ");
            EndContext();
            BeginContext(1384, 30, false);
#line 34 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                           Write(item.menhgia.ToString("#,###"));

#line default
#line hidden
            EndContext();
            BeginContext(1414, 2, true);
            WriteLiteral(" -");
            EndContext();
            BeginContext(1417, 12, false);
#line 34 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                                                            Write(item.soluong);

#line default
#line hidden
            EndContext();
            BeginContext(1429, 143, true);
            WriteLiteral(" cái\r\n                            </span>\r\n                            <br />\r\n                            <small><i class=\"fa fa-clock-o\"></i>");
            EndContext();
            BeginContext(1573, 12, false);
#line 37 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                                                           Write(item.ngaynop);

#line default
#line hidden
            EndContext();
            BeginContext(1585, 69, true);
            WriteLiteral("</small>\r\n\r\n                        </a>\r\n                    </li>\r\n");
            EndContext();
#line 41 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\Notification\default.cshtml"
                }

#line default
#line hidden
            BeginContext(1673, 138, true);
            WriteLiteral("\r\n            </ul>\r\n        </li>\r\n        <li class=\"footer\"><a href=\"/admin/card/history\">Xem tất cả</a></li>\r\n    </ul>\r\n</li>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NopTheViewModels>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14db1cf2c29258a497ede8d969b9a4f399c6058c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Components_UserRegister_default), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Components/UserRegister/default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/Components/UserRegister/default.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared_Components_UserRegister_default))]
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
#line 2 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml"
using WebTheCao.Areas.Admin.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14db1cf2c29258a497ede8d969b9a4f399c6058c", @"/Areas/Admin/Views/Shared/Components/UserRegister/default.cshtml")]
    public class Areas_Admin_Views_Shared_Components_UserRegister_default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserRegiterViewModels>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(71, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml"
   
    var count = Model.Users.Count();

#line default
#line hidden
            BeginContext(119, 146, true);
            WriteLiteral("\r\n<li class=\"dropdown notifications-menu\">\r\n    <a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">\r\n        <i class=\"fa fa-users\"></i>\r\n");
            EndContext();
#line 11 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml"
         if (count != 0)
        {

#line default
#line hidden
            BeginContext(302, 46, true);
            WriteLiteral("            <span class=\"label label-warning\">");
            EndContext();
            BeginContext(349, 5, false);
#line 13 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml"
                                         Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(354, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 14 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml"

        }

#line default
#line hidden
            BeginContext(376, 76, true);
            WriteLiteral("    </a>\r\n    <ul class=\"dropdown-menu\">\r\n        <li class=\"header\">Bạn có ");
            EndContext();
            BeginContext(453, 5, false);
#line 18 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml"
                             Write(count);

#line default
#line hidden
            EndContext();
            BeginContext(458, 126, true);
            WriteLiteral(" người dùng mới</li>\r\n        <li>\r\n            <!-- inner menu: contains the actual data -->\r\n            <ul class=\"menu\">\r\n");
            EndContext();
#line 22 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml"
                 foreach (var user in Model.Users)
                {

#line default
#line hidden
            BeginContext(655, 149, true);
            WriteLiteral("                    <li>\r\n                        <a href=\"/admin/account/index\">\r\n                            <i class=\"fa fa-users text-aqua\"></i> ");
            EndContext();
            BeginContext(805, 13, false);
#line 26 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml"
                                                             Write(user.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(818, 72, true);
            WriteLiteral(" vừa đăng ký.\r\n                        </a>\r\n                    </li>\r\n");
            EndContext();
#line 29 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\Components\UserRegister\default.cshtml"
                }

#line default
#line hidden
            BeginContext(909, 131, true);
            WriteLiteral("            </ul>\r\n        </li>\r\n        <li class=\"footer\"><a href=\"/admin/account/index\">Xem tất cả</a></li>\r\n    </ul>\r\n</li>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserRegiterViewModels> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\_navigation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f29119b41e095f5cedc40064dfbc90a8a0076e8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__navigation), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_navigation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Shared/_navigation.cshtml", typeof(AspNetCore.Areas_Admin_Views_Shared__navigation))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f29119b41e095f5cedc40064dfbc90a8a0076e8b", @"/Areas/Admin/Views/Shared/_navigation.cshtml")]
    public class Areas_Admin_Views_Shared__navigation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::WebTheCao.Infrastructures.AvatarTagHelper __WebTheCao_Infrastructures_AvatarTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(28, 156, true);
            WriteLiteral("<aside class=\"main-sidebar\">\r\n    <!-- sidebar: style can be found in sidebar.less -->\r\n    <section class=\"sidebar\">\r\n        <!-- Sidebar user panel -->\r\n");
            EndContext();
#line 6 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\_navigation.cshtml"
         if (User.Identity.IsAuthenticated)
        {



#line default
#line hidden
            BeginContext(244, 105, true);
            WriteLiteral("            <div class=\"user-panel\">\r\n                <div class=\"pull-left image\">\r\n                    ");
            EndContext();
            BeginContext(349, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "eef824e1dd084bac9be3a8366947b20c", async() => {
            }
            );
            __WebTheCao_Infrastructures_AvatarTagHelper = CreateTagHelper<global::WebTheCao.Infrastructures.AvatarTagHelper>();
            __tagHelperExecutionContext.Add(__WebTheCao_Infrastructures_AvatarTagHelper);
            BeginWriteTagHelperAttribute();
#line 12 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\_navigation.cshtml"
                       WriteLiteral(User.Identity.Name);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __WebTheCao_Infrastructures_AvatarTagHelper.UserName = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("username", __WebTheCao_Infrastructures_AvatarTagHelper.UserName, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "alt", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 12 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\_navigation.cshtml"
AddHtmlAttributeValue("", 416, User.Identity.Name, 416, 19, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(438, 95, true);
            WriteLiteral("\r\n                </div>\r\n                <div class=\"pull-left info\">\r\n                    <p>");
            EndContext();
            BeginContext(534, 18, false);
#line 15 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\_navigation.cshtml"
                  Write(User.Identity.Name);

#line default
#line hidden
            EndContext();
            BeginContext(552, 136, true);
            WriteLiteral("</p>\r\n                    <a href=\"#\"><i class=\"fa fa-circle text-success\"></i> Online</a>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 19 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\_navigation.cshtml"
        }

#line default
#line hidden
            BeginContext(699, 1929, true);
            WriteLiteral(@"        <!-- search form -->
        <form action=""#"" method=""get"" class=""sidebar-form"">
            <div class=""input-group"">
                <input type=""text"" name=""q"" class=""form-control"" placeholder=""Search..."">
                <span class=""input-group-btn"">
                    <button type=""submit"" name=""search"" id=""search-btn"" class=""btn btn-flat"">
                        <i class=""fa fa-search""></i>
                    </button>
                </span>
            </div>
        </form>
        <!-- /.search form -->
        <!-- sidebar menu: : style can be found in sidebar.less -->
        <ul class=""sidebar-menu"" data-widget=""tree"">
            <li class=""header"">Quản trị </li>
            <li>
                <a href=""/admin/Home/Index"">
                    <i class=""fa fa-home""></i> <span>Trang chủ</span>
                </a>
            </li>
            <li class=""treeview"">
                <a href=""#"">
                    <i class=""fa  fa-expeditedssl""></i>
             ");
            WriteLiteral(@"       <span>Tài khoản &amp; Bảo mật</span>
                    <span class=""pull-right-container"">
                        <i class=""fa fa-angle-left pull-right""></i>
                    </span>
                </a>
                <ul class=""treeview-menu"">
                    <li><a href=""/admin/account/index""><i class=""fa fa-circle-o""></i> Tài khoản</a></li>
                    <li><a href=""/admin/role/index""><i class=""fa fa-circle-o""></i> Phân quyền</a></li>
                    <li><a href=""/admin/taikhoanthe/index""><i class=""fa fa-paypal ""></i> Tài khoản ngân hàng</a></li>
                </ul>
            </li>

            <li class=""treeview"">
                <a href=""#"">
                    <i class=""fa fa-credit-card ""></i> <span>Thẻ cào &amp; Nạp thẻ</span>
                    <span class=""pull-right-container"">
                        <span class=""mail-info""><span");
            EndContext();
            BeginWriteAttribute("mail-info", " mail-info=\"", 2628, "\"", 2645, 1);
#line 59 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\_navigation.cshtml"
WriteAttributeValue("", 2640, true, 2640, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2646, 1558, true);
            WriteLiteral(@"></span> </span>
                        <i class=""fa fa-angle-left pull-right""></i>
                    </span>
                </a>
                <ul class=""treeview-menu"" style="""">
                    <li class=""active"">
                        <a href=""/admin/card/history"">
                            <i class=""fa fa-history""></i> <span>Lịch sử nạp thẻ</span>

                        </a>
                    </li>
                    <li>
                        <a href=""/admin/card/index"">
                            <i class=""fa fa-credit-card-alt""></i> <span>Thẻ cào &amp; Mệnh giá thẻ</span>

                        </a>
                    </li>
                   
                </ul>
            </li>

            <li>
                <a href=""/admin/giaodich/index"">
                    <i class=""fa fa-handshake-o ""></i> <span>Quản lý giao dịch</span>
                    <span class=""pull-right-container"">
                    </span>
                </a>
            </l");
            WriteLiteral(@"i>
            <li>
                <a href=""/admin/post/index"">
                    <i class=""fa fa-book""></i> <span>Bài viết</span>
                    <span class=""pull-right-container"">
                    </span>
                </a>
            </li>
            

            <li class=""treeview"">
                <a href=""#"">
                    <i class=""fa fa-envelope""></i> <span>Thư phản hồi</span>
                    <span class=""pull-right-container"">
                        <span class=""mail-info""><span");
            EndContext();
            BeginWriteAttribute("mail-info", " mail-info=\"", 4204, "\"", 4221, 1);
#line 100 "D:\IDE-VisualStudio\WebTheCao\WebTheCao\Areas\Admin\Views\Shared\_navigation.cshtml"
WriteAttributeValue("", 4216, true, 4216, 5, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4222, 2034, true);
            WriteLiteral(@"></span> </span>
                        <i class=""fa fa-angle-left pull-right""></i>
                    </span>
                </a>
                <ul class=""treeview-menu"" style="""">
                    <li class=""active"">
                        <a href=""/admin/feedback/mailbox?opt=compose"">
                            <i class=""fa fa-commenting-o""></i> <span>Tất cả</span>

                        </a>
                    </li>
                    <li>
                        <a href=""/admin/feedback/mailbox?opt=news-message"">
                            <i class=""fa fa-envelope-o""></i> <span>Tin nhắn mới</span>

                        </a>
                    </li>
                    <li>
                        <a href=""/admin/feedback/mailbox?opt=sends-message"">
                            <i class=""fa fa-envelope""></i> <span>Tin nhắn đã gởi</span>

                        </a>
                    </li>
                    <li>
                        <a href=""/admin/feedback/");
            WriteLiteral(@"mailbox?opt=waits-message"">
                            <i class=""fa fa-spinner""></i> <span>Đang chờ</span>
                        </a>
                    </li>
                </ul>
            </li>

            <li class=""treeview"">
                <a href=""#"">
                    <i class=""fa fa-files-o""></i>
                    <span>Quản lý trang</span>
                    <span class=""pull-right-container"">
                        <i class=""fa fa-angle-left pull-right""></i>
                    </span>
                </a>
                <ul class=""treeview-menu"">
                    <li><a href=""/admin/Page/Index""><i class=""fa fa-circle-o""></i> Thông báo</a></li>
                    <li><a href=""/admin/Contact/Index""><i class=""fa fa-circle-o""></i> Liên hệ</a></li>
                    <li><a href=""/admin/Slide/Index""><i class=""fa fa-circle-o""></i> Slide</a></li>
                </ul>
            </li>

        </ul>
    </section>
    <!-- /.sidebar -->
</aside>");
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

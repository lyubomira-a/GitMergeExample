#pragma checksum "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9a7936cf5c8c8c13c6358fc19040ac876b2f2ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_Index), @"mvc.1.0.view", @"/Views/Users/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9a7936cf5c8c8c13c6358fc19040ac876b2f2ca", @"/Views/Users/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25fd987d7388ad707b6b8d314dfa2b63ad979348", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MovieManager.Models.Users.IndexVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Site.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Users</h1>\r\n\r\n<a class=\"btn btn-primary\" href=\"/Users/Edit\">Add New</a>\r\n<br />\r\n\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 16 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Items[0].FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 19 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Items[0].LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 22 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Items[0].Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 25 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Items[0].Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 29 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
     foreach (var item in Model.Items)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 33 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 39 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1148, "\"", 1178, 2);
            WriteAttributeValue("", 1155, "/Users/Edit?Id=", 1155, 15, true);
#nullable restore
#line 45 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
WriteAttributeValue("", 1170, item.Id, 1170, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 1210, "\"", 1242, 2);
            WriteAttributeValue("", 1217, "/Users/Delete?Id=", 1217, 17, true);
#nullable restore
#line 46 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
WriteAttributeValue("", 1234, item.Id, 1234, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                   onclick=\"return confirm(\'Delete item?\')\">Delete\r\n                </a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 51 "C:\Users\lyubo\OneDrive\Работен плот\ASP.NET\MovieManager - Copy\MovieManager\Views\Users\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MovieManager.Models.Users.IndexVM> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\labs\EComm\EComm.Web\Views\Shared\_Products.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f62ff20c3bbcd768adf15f7c9ddda33201b8ded0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Products), @"mvc.1.0.view", @"/Views/Shared/_Products.cshtml")]
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
#nullable restore
#line 1 "C:\labs\EComm\EComm.Web\Views\_ViewImports.cshtml"
using EComm.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\labs\EComm\EComm.Web\Views\_ViewImports.cshtml"
using EComm.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\labs\EComm\EComm.Web\Views\_ViewImports.cshtml"
using EComm.Web.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f62ff20c3bbcd768adf15f7c9ddda33201b8ded0", @"/Views/Shared/_Products.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a94081ea97bb2c19109025e7394407434501b9e8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Products : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EComm.Web.Models.Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\r\n    Product Count: ");
#nullable restore
#line 3 "C:\labs\EComm\EComm.Web\Views\Shared\_Products.cshtml"
              Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <table class=\"table table-bordered table-striped\">\r\n        <tr>\r\n            <th>Id</th>\r\n            <th>Name</th>\r\n        </tr>\r\n        ");
#nullable restore
#line 10 "C:\labs\EComm\EComm.Web\Views\Shared\_Products.cshtml"
   Write(Html.ActionLink("Create","Create","Demo"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 12 "C:\labs\EComm\EComm.Web\Views\Shared\_Products.cshtml"
         foreach (var product in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr><td>");
#nullable restore
#line 14 "C:\labs\EComm\EComm.Web\Views\Shared\_Products.cshtml"
               Write(product.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td><td>");
#nullable restore
#line 14 "C:\labs\EComm\EComm.Web\Views\Shared\_Products.cshtml"
                                   Write(product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td></tr>\r\n");
#nullable restore
#line 15 "C:\labs\EComm\EComm.Web\Views\Shared\_Products.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EComm.Web.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
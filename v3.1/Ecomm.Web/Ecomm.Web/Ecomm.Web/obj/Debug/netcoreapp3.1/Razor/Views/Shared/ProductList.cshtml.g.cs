#pragma checksum "C:\git\aspnetcore-demos\v3.1\Ecomm.Web\Ecomm.Web\Ecomm.Web\Views\Shared\ProductList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0572c15c82c4b5c379275f9cd4e9358a2369b610"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ProductList), @"mvc.1.0.view", @"/Views/Shared/ProductList.cshtml")]
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
#line 1 "C:\git\aspnetcore-demos\v3.1\Ecomm.Web\Ecomm.Web\Ecomm.Web\Views\_ViewImports.cshtml"
using Ecomm.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\git\aspnetcore-demos\v3.1\Ecomm.Web\Ecomm.Web\Ecomm.Web\Views\_ViewImports.cshtml"
using Ecomm.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\git\aspnetcore-demos\v3.1\Ecomm.Web\Ecomm.Web\Ecomm.Web\Views\_ViewImports.cshtml"
using Ecomm.Data.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\git\aspnetcore-demos\v3.1\Ecomm.Web\Ecomm.Web\Ecomm.Web\Views\_ViewImports.cshtml"
using Ecomm.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0572c15c82c4b5c379275f9cd4e9358a2369b610", @"/Views/Shared/ProductList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"624aebce68adf4b1a5f388d04e76a3ce960bb699", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ProductList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\git\aspnetcore-demos\v3.1\Ecomm.Web\Ecomm.Web\Ecomm.Web\Views\Shared\ProductList.cshtml"
 foreach (var item in Model)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\git\aspnetcore-demos\v3.1\Ecomm.Web\Ecomm.Web\Ecomm.Web\Views\Shared\ProductList.cshtml"
Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n");
#nullable restore
#line 6 "C:\git\aspnetcore-demos\v3.1\Ecomm.Web\Ecomm.Web\Ecomm.Web\Views\Shared\ProductList.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591

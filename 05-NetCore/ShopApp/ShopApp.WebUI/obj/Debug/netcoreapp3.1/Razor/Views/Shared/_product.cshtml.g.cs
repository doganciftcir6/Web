#pragma checksum "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Shared\_product.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c90f2564e32d452f66dd1088359a559bf86ad38d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__product), @"mvc.1.0.view", @"/Views/Shared/_product.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c90f2564e32d452f66dd1088359a559bf86ad38d", @"/Views/Shared/_product.cshtml")]
    public class Views_Shared__product : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopApp.WebUI.Models.Product>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
    <div class=""card"">
        <img class=""card-img-top"" src=""https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-card-40-iphone14-202209_FMT_WHH?wid=508&hei=472&fmt=p-jpg&qlt=95&.v=1661958160494"" alt=""Alternate Text"" />
        <div class=""card-body"">
            <h5 class=""card-title"">");
#nullable restore
#line 6 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Shared\_product.cshtml"
                              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <p class=\"card-text\">");
#nullable restore
#line 7 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Shared\_product.cshtml"
                            Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <a class=\"btn btn-primary\" href=\"#\">İncele</a>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopApp.WebUI.Models.Product> Html { get; private set; }
    }
}
#pragma warning restore 1591

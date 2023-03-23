#pragma checksum "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9318c43e3f204616e30c68893a6049e352be6673"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_List), @"mvc.1.0.view", @"/Views/Product/List.cshtml")]
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
#line 1 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\_ViewImports.cshtml"
using ShopApp.WebUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\_ViewImports.cshtml"
using ShopApp.WebUI.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9318c43e3f204616e30c68893a6049e352be6673", @"/Views/Product/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3db0163b660b5f430c950a5f452030d97ac15e93", @"/Views/Product/_ViewImports.cshtml")]
    public class Views_Product_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_header", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 6 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
  
    var popularClass = Model.Products.Count > 2 ? "popular" : "";
    var categories = Model.Categories;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9318c43e3f204616e30c68893a6049e352be66734047", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <title>Product</title>
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css"" integrity=""sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"" crossorigin=""anonymous"">
    <style>
        .popular {
            color: green;
            font-weight: 700;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9318c43e3f204616e30c68893a6049e352be66735412", async() => {
                WriteLiteral("\r\n\r\n");
                WriteLiteral("    ");
#nullable restore
#line 28 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
Write(await Html.PartialAsync("_navbar"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
                WriteLiteral("    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9318c43e3f204616e30c68893a6049e352be66736008", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <main>\r\n            <div class=\"container\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-3\">\r\n");
                WriteLiteral("                        <div class=\"list-group\">\r\n");
#nullable restore
#line 39 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                             foreach (var category in categories)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <a class=\"list-group-item list-group-item-action\" href=\"#\">");
#nullable restore
#line 41 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                                                                                      Write(category.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a>\r\n");
#nullable restore
#line 42 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </div>\r\n\r\n                    </div>\r\n                    <div class=\"col-md-9\">\r\n");
                WriteLiteral("\r\n");
                WriteLiteral("\r\n");
#nullable restore
#line 64 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                         if (Model.Products.Count == 0)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                       Write(await Html.PartialAsync("_noproduct"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 66 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                                                                  
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <div class=\"row\">\r\n");
#nullable restore
#line 71 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                                 foreach (var product in Model.Products)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <div class=\"col-md-3\">\r\n                                        ");
#nullable restore
#line 74 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                                   Write(await Html.PartialAsync("_product", product));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                    </div>\r\n");
#nullable restore
#line 76 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            </div>\r\n");
#nullable restore
#line 78 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n\r\n\r\n\r\n");
                WriteLiteral("            <div>\r\n                <p>");
#nullable restore
#line 93 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
              Write(Model.Products[1].Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                <p>");
#nullable restore
#line 94 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
              Write(Model.Products[1].Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                <p>");
#nullable restore
#line 95 "C:\Users\dogan\OneDrive\Masaüstü\05-NetCore\ShopApp\ShopApp.WebUI\Views\Product\List.cshtml"
              Write(Model.Products[1].Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            </div>\r\n\r\n        </main>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
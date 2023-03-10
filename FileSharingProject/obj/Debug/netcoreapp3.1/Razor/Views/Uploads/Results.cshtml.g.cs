#pragma checksum "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9320bd904150f0210397571341125b625d33f82d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Uploads_Results), @"mvc.1.0.view", @"/Views/Uploads/Results.cshtml")]
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
#line 1 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\_ViewImports.cshtml"
using FileSharingProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\_ViewImports.cshtml"
using FileSharingProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9320bd904150f0210397571341125b625d33f82d", @"/Views/Uploads/Results.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"251f978fdb73f0bcee87aedec7239dab40af67b0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Uploads_Results : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FileSharingProject.Models.UploadViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Download", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Uploads", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
  
    ViewData["Title"] = "Results";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h4>Search Results</h4>\r\n<hr />\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
#nullable restore
#line 10 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card mb-3 col-md-8\">\r\n                <div class=\"row g-0\">\r\n                    <div class=\"col-md-4\">\r\n");
#nullable restore
#line 15 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
                         if (item.ContentType.ToLower().StartsWith("image"))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <img");
            BeginWriteAttribute("src", " src=\"", 504, "\"", 533, 2);
            WriteAttributeValue("", 510, "/Uploads/", 510, 9, true);
#nullable restore
#line 17 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
WriteAttributeValue("", 519, item.FileName, 519, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid rounded-start\" alt=\"...\" style=\"min-height:145px; min-width:200px; max-height:145px; max-width:200px;\">\r\n");
#nullable restore
#line 18 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"

                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                    <div class=\"col-md-8\">\r\n                        <div class=\"card-body\">\r\n                            <h5 class=\"card-title\">");
#nullable restore
#line 23 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
                                              Write(item.OriginalFileName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
            WriteLiteral("                            <p class=\"card-text\"><small class=\"text-muted\">");
#nullable restore
#line 25 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
                                                                      Write(item.UploadDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n                            <p class=\"card-text\">Download count: ");
#nullable restore
#line 26 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
                                                            Write(item.DownloadCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <div class=\"text-right\">\r\n\r\n\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9320bd904150f0210397571341125b625d33f82d7415", async() => {
                WriteLiteral("Download");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 30 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
                                                                                    WriteLiteral(item.FileName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 37 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-12 text-center\">\r\n            <div>\r\n");
#nullable restore
#line 41 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
                 if (ViewBag.CurrentPage - 1 > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1657, "\"", 1720, 2);
            WriteAttributeValue("", 1664, "/Uploads/Browse/?RequiredPage=", 1664, 30, true);
#nullable restore
#line 43 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
WriteAttributeValue("", 1694, ViewBag.CurrentPage - 1, 1694, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary btn-lg align-left\">Prev</a>\r\n");
#nullable restore
#line 44 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
                 if (ViewBag.CurrentPage + 1 <= ViewBag.PagesCount)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=\"", 1911, "\"", 1974, 2);
            WriteAttributeValue("", 1918, "/Uploads/Browse/?RequiredPage=", 1918, 30, true);
#nullable restore
#line 47 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
WriteAttributeValue("", 1948, ViewBag.CurrentPage + 1, 1948, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary btn-lg align-right\">Next</a>\r\n");
#nullable restore
#line 48 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Results.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<FileSharingProject.Models.UploadViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

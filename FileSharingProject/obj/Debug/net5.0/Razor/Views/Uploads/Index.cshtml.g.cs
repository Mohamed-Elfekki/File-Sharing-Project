#pragma checksum "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b454a594420919d250ea026f9dca8c6a865ae0d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Uploads_Index), @"mvc.1.0.view", @"/Views/Uploads/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b454a594420919d250ea026f9dca8c6a865ae0d6", @"/Views/Uploads/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"251f978fdb73f0bcee87aedec7239dab40af67b0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Uploads_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<FileSharingProject.Models.UploadViewModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
  
    ViewData["Title"] = "Index";
    var imagesContentType = new[] { "image/jpeg", "image/png", "image/jpg" };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>My Uploads</h1>\r\n\r\n<p style=\"text-align:right\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b454a594420919d250ea026f9dca8c6a865ae0d64251", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>Preview</th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Size));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ContentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UploadDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DownloadCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 36 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n");
#nullable restore
#line 39 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
                     if (item.ContentType.ToLower().StartsWith("image/"))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <img");
            BeginWriteAttribute("src", " src=\"", 1154, "\"", 1183, 2);
            WriteAttributeValue("", 1160, "/Uploads/", 1160, 9, true);
#nullable restore
#line 41 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
WriteAttributeValue("", 1169, item.FileName, 1169, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" width=\"100\" height=\"100\" class=\"img-thumbnail\" />\r\n");
#nullable restore
#line 42 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OriginalFileName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 49 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
                      
                        var size = item.Size / 1024; //KB
                        if (size < 1024)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>Size: ");
#nullable restore
#line 53 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
                                   Write(Math.Floor(size));

#line default
#line hidden
#nullable disable
            WriteLiteral(" KB</span>\r\n");
#nullable restore
#line 54 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
                        }
                        else
                        {
                            size = size / 1024; //MB

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span>Size: ");
#nullable restore
#line 58 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
                                   Write(Math.Floor(size));

#line default
#line hidden
#nullable disable
            WriteLiteral(" MB</span>\n");
#nullable restore
#line 59 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
                        }
                      

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 63 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ContentType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n             <td>\r\n                    ");
#nullable restore
#line 66 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.UploadDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n             </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 69 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.DownloadCount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n            <td>\r\n                ");
#nullable restore
#line 73 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { id=item.Id}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 76 "D:\VisualStudioProjects\FileSharingProject\FileSharingProject\Views\Uploads\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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

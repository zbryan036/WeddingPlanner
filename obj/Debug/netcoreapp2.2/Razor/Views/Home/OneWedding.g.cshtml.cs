#pragma checksum "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\Home\OneWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "684c742f3111de426248b4fc52a3fcc338065c0f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OneWedding), @"mvc.1.0.view", @"/Views/Home/OneWedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/OneWedding.cshtml", typeof(AspNetCore.Views_Home_OneWedding))]
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
#line 1 "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#line 2 "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"684c742f3111de426248b4fc52a3fcc338065c0f", @"/Views/Home/OneWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OneWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 170, true);
            WriteLiteral("<div class=\"Container\">\r\n    <div class=\"row\" style=\"margin-top:50px\">\r\n        <div class=\"col-3\"></div>\r\n        <div class=\"col-6\">\r\n            <h2 class=\"display-5\">");
            EndContext();
            BeginContext(171, 23, false);
#line 5 "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\Home\OneWedding.cshtml"
                             Write(ViewBag.Wedding.Wedder1);

#line default
#line hidden
            EndContext();
            BeginContext(194, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(198, 23, false);
#line 5 "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\Home\OneWedding.cshtml"
                                                        Write(ViewBag.Wedding.Wedder2);

#line default
#line hidden
            EndContext();
            BeginContext(221, 331, true);
            WriteLiteral(@"'s Wedding</h2>
        </div>
        <div class=""col-1"">
            <a href=""/"">Dashboard </a>
        </div>
        <div class=""col-2"">
            <a href=""/logout""> Log Out</a>
        </div>
        <div class=""row"">
            <div class=""col-3""></div>
            <div class=""col-6"">
                <p>Date: ");
            EndContext();
            BeginContext(553, 42, false);
#line 16 "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\Home\OneWedding.cshtml"
                    Write(ViewBag.Wedding.Date.ToString("dd/M/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(595, 61, true);
            WriteLiteral("</p>\r\n                <p>Guests: </p>\r\n                <ul>\r\n");
            EndContext();
#line 19 "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\Home\OneWedding.cshtml"
                     foreach(RSVP r in ViewBag.Wedding.RSVPs) {

#line default
#line hidden
            BeginContext(721, 28, true);
            WriteLiteral("                        <li>");
            EndContext();
            BeginContext(750, 13, false);
#line 20 "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\Home\OneWedding.cshtml"
                       Write(r.U.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(763, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(765, 12, false);
#line 20 "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\Home\OneWedding.cshtml"
                                      Write(r.U.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(777, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 21 "C:\Users\Avery Admin\Desktop\dojo\c#\entity\WeddingPlanner\Views\Home\OneWedding.cshtml"
                    }

#line default
#line hidden
            BeginContext(807, 108, true);
            WriteLiteral("                </ul>\r\n            </div>\r\n            <div class=\"col-3\"></div>\r\n        </div>\r\n    </div>");
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
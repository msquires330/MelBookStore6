using MelBookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MelBookStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]

    // Inherit from the Microsoft Built in Tag Helper 
    public class PageLinkTagHelper : TagHelper
    {
        // urlHelperFactory is of the IUrlHelperFactory type and will hold the information we need 
        private IUrlHelperFactory urlHelperFactory; 

        // an instance of the class (the constructor). 
        public PageLinkTagHelper (IUrlHelperFactory hp)
        {
            urlHelperFactory = hp; 
        }

        [ViewContext]
        [HtmlAttributeNotBound]

        // 3 different properties 
        public ViewContext ViewContext { get; set; }
        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        // any time someone enters "page - url -", add it to the dictionary 
        // asp.net groups things together with a common prefix 
        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        // pairs values together 
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        // as a default set it to false
        public bool PageClassesEnabled { get; set; }
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Overriding the process of this
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div"); 
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                // Build an instance of the TagBuilder object 
                TagBuilder tag = new TagBuilder("a");
                PageUrlValues["page"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                // if i is equal to the Page Model of the current page, then set i to PageClassSelected. Otherwise, DO PageClassNormal. This is to make the current page turn blue. 
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}

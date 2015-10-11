using System;
using System.Text;
using Codeflyers.EC.MVC.Models;
using Microsoft.AspNet.Mvc.Rendering;

namespace Codeflyers.EC.MVC.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static HtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag);
            }
            //return MvcHtmlString.Create(result.ToString());
            var pageLinks = new HtmlString(result.ToString());
            return pageLinks;
        }
    }
}
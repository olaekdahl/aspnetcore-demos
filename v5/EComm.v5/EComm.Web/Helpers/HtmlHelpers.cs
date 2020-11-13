using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.Helpers
{
    public static class HtmlHelpers
    {
        public static HtmlString Image(this IHtmlHelper html, string src, string alt)
        {
            string str = $"<img src=\"{src}\" alt=\"{alt}\" />";
            return new HtmlString(str);
        }
    }
}

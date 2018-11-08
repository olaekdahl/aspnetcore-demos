using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebDemo.Helpers
{
    public static class HtmlHelpers
    {
        public static HtmlString Image(this IHtmlHelper html,
                               string src, string alt)
        {
            string str = String.Format("<img src=\"{0}\" alt=\"{1}\" />",
                                       src, alt);
            return new HtmlString(str);
        }

    }
}

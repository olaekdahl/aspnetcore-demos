using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_app.Shared.Models;

namespace web_app.TagHelpers
{
    [HtmlTargetElement("product-table", Attributes = "products")]
    public class ProductTableTagHelper : TagHelper
    {
        public IEnumerable<Product> Products { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string tableHead = $@"<table class=table table-striped>
                <thead>
                    <tr>
                        <th>
                            Id
                        </th>
                        <th>
                            Product Name
                        </th>
                        <th>
                            Price
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>";
            string tableBody = "";
            foreach (var item in Products)
            {
                tableBody += @$"
                        <tr>
                            <td>
                                 { item.Id }
                            </td>
                            <td>
                                { item.ProductName }
                            </td>
                            <td>
                                { item.Price }
                            </td>
                           
                        </tr>";
            }
            string tableEnd = "</tbody></table>";
            //output.TagName = "table";
            output.Content.SetHtmlContent(tableHead + tableBody + tableEnd);
            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SportsStore.Web.Models;

namespace SportsStore.Web.HtmlHelpers
{
    public static class SortingHelpers
    {
        public static MvcHtmlString getHeaderLink(this HtmlHelper html, SortingPagingInfo pagingInfo,
            IEnumerable<string> headerNames, Func<string, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            foreach (var headerName in headerNames)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(headerName));

                //          <th>
                //    @Html.ActionLink("Category", "List", new { category = Model.CurrentCategory, sortHeader = "Category", sortDirection = Model.SortingPagingInfo.SortField == this. && Model.SortingPagingInfo.SortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending })
                //</th>


                TagBuilder tag2 = new TagBuilder("th");
            }

            return MvcHtmlString.Create("".ToString());

        }
    }
}
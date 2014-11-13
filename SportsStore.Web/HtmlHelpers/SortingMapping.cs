using System.Collections.Generic;

namespace SportsStore.Web.HtmlHelpers
{
    public class SortingMapping
    {
        public static Dictionary<string, string> ProductHeaders =
          new Dictionary<string, string>()
            {
                {"Product Name", "Name"},
                {"Identifier", "ProductID"},
                {"More Info", "Description"},
            };



    }
}
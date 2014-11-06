using System;
using System.Web.Helpers;

namespace SportsStore.Web.Models
{
    public class SortingPagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }

        public string SortField { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CatalogItem = WebMvc.Models.CatalogItem;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        // int? category, int? location, int? page, int? itemsOnPage)

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }


        public IEnumerable<CatalogItem> ItemsOnPage { get; set; }
        //                 CategoryFilterApplied = category LocationFilterApplied = location ?? 0

        public int? CategoryFilterApplied { get; set; }
        public int? LocationFilterApplied { get; set; }
    }
}

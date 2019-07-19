using EventBriteCatalog.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        // int? category, int? location, int? page, int? itemsOnPage)

        public IEnumerable<SelectListItem> Category { get; set; }
        public IEnumerable<SelectListItem> Location { get; set; }
        public IEnumerable<SelectListItem> Page { get; set; }

        public IEnumerable<CatalogItem> ItemOnPage { get; set; }
        //                 CategoryFilterApplied = category LocationFilterApplied = location ?? 0

        public int? CategoryFilterApplied { get; set; }
        public int? LocationFilterApplied { get; set; }
    }
}

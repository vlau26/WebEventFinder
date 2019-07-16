using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Catalog
        {
            // get categories, locations, and catalog items
            public static string GetAllCategories(string baseUri)
            {
                // will return localhost/api/catalog/catalogcategories
                return $"{baseUri}catalogcategories";
            }
             public static string GetAllLocations(string baseUri)
            {
                // will return localhost/api/catalog/cataloglocations
                return $"{baseUri}cataloglocations";
            }

            // api path for catalog
            public static string GetAllCatalogItems(string baseUri, int page, int take, int? category, int? location)
            {
                var filterQueries = string.Empty;

                if(category.HasValue || location.HasValue)
                {
                    // if category has value, convert to a string, otherwise return null string
                    var categoryQuery = (category.HasValue) ? category.Value.ToString() : "null";
                    var locationQuery = (location.HasValue) ? location.Value.ToString() : "null";
                    filterQueries = $"/category/{categoryQuery}/location/{locationQuery}";
                }

                return $"{baseUri}items{filterQueries}?pageSize={take}&pageIndex={page}";
            }
        }
    }
}
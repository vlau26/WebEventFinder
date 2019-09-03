using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IHttpClient _client;
        private readonly string _baseUri;

        public CatalogService(IHttpClient httpClient, IConfiguration config)
        {

            _client = httpClient;
            _baseUri = $"{config["CatalogUrl"]}/api/catalog/";
 
        }

        public  async Task<Catalog> GetCatalogItemsAsync(int page, int size, int? category, int? location)
        {
           var catalogItemsUri = ApiPaths.Catalog.GetAllCatalogItems(_baseUri, page, size, category, location);
           var dataString = await _client.GetStringAsync(catalogItemsUri);
           var response = JsonConvert.DeserializeObject<Catalog>(dataString);
           return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
           var categoryUri = ApiPaths.Catalog.GetAllCategories(_baseUri);
           var dataString = await _client.GetStringAsync(categoryUri);
           var items = new List<SelectListItem>
           {
               new SelectListItem
               {
                   Value="0",
                   Text ="All",
                   Selected =true
               }
           };

           var categories = JArray.Parse(dataString);
            foreach (var category in categories)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = category.Value<string>("id"),
                        Text = category.Value<string>("category")
                    }
                   );
            }
            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetLocationsAsync()
        {

            var locationUri = ApiPaths.Catalog.GetAllLocations(_baseUri);
            var dataString = await _client.GetStringAsync(locationUri);
            var items = new List<SelectListItem>
           {
               new SelectListItem
               {
                   Value="0",
                   Text ="All",
                   Selected =true
               }
           };

            var locations = JArray.Parse(dataString);
            foreach (var location in locations)
            {
                items.Add
                    
                   (
                    new SelectListItem
                    {
                        Value = location.Value<string>("id"),
                        Text = location.Value<string>("location")
                    }
                   );
            }
            return items;
        }
    }
}

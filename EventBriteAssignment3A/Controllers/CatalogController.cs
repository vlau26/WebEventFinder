using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBriteAssignment3A.Data;
using EventBriteAssignment3A.ViewModels;
using EventBriteCatalog.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventBriteAssignment3A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _catalogContext;
        private readonly IConfiguration _configuration;

        public CatalogController(CatalogContext catalogContext, IConfiguration configuration)
        {
            _catalogContext = catalogContext;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogCategories()
        {
            var events = await _catalogContext.CatalogCategories.ToListAsync();
            return Ok(events);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> CatalogLocations()
        {
            var events = await _catalogContext.CatalogLocations.ToListAsync();
            return Ok(events);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Events([FromQuery]int pageSize = 6, [FromQuery]int pageIndex = 0)
        {
            var eventsCount = await _catalogContext.CatalogItems.LongCountAsync();

            var events = await _catalogContext.CatalogItems
                 .OrderBy(c => c.EventStartTime)
                 .Skip(pageSize * pageIndex)
                 .Take(pageSize)
                 .ToListAsync();
            events = ChangePictureUrl(events);
            var model = new PaginatedItemsViewModel<CatalogItem>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = eventsCount,
                Data = events
            };
            return Ok(model);
        }

        private List<CatalogItem> ChangePictureUrl(List<CatalogItem> events)
        {
            events.ForEach(c => c.PictureUrl = c.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _configuration["ExternalCatalogBaseUrl"]));
            return events;
        }


        [HttpGet]
        [Route("events/{id:int}")]

        public async Task<IActionResult> GetEventsById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Incorrect Id!");
            }

            var catalogItem = await _catalogContext.CatalogItems.SingleOrDefaultAsync(c => c.EventId == id);
            if (catalogItem == null)
            {
                return NotFound("Event not found");
            }
            catalogItem.PictureUrl = catalogItem.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _configuration["ExternalCatalogBaseurl"]);
            return Ok(catalogItem);
        }

        /*        [HttpGet]
                [Route("[action]/EventName/{EventName:minlength(1)}")]
                public async Task<IActionResult> Events(
                     string? EventName, int? EventId,
                     [FromQuery]int pageSize = 6,
                     [FromQuery]int pageIndex = 0)
                {
                    var root = (IQueryable<CatalogItem>)_catalogContext.CatalogItems;

                    if (EventId.HasValue)
                    {
                        root = root.Where(c => c.EventId == EventId);
                    }

                    if (EventName.HasValue)
                    {
                        root = root.Where(c => c.EventName == EventName);
                    }

                    var totalEvents = await root.LongCountAsync();

                    var eventsOnPage = await root
                                       .OrderBy(c => c.EventName)
                                       .Skip(pageSize * pageIndex)
                                       .Take(pageSize)
                                       .ToListAsync();
                    eventsOnPage = ChangePictureUrl(eventsOnPage);
                    var model = new PaginatedItemsViewModel<CatalogItem>
                    {
                        PageSize = pageSize,
                        PageIndex = pageIndex,
                        Count = eventsCount,
                        Data = events
                    };
                    return Ok(model);
                }

        */
    }
}
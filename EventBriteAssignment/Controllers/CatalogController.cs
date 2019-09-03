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

        // GET api/catalog/events?pagesize=5&pageIndex=2
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

        // GET api/Catalog/Events/category/1/location/null[?pageSize=6&pageIndex=0]
        [HttpGet]
        [Route("[action]/category/{catalogCategoryId}/location/{catalogLocationId}")]
        public async Task<IActionResult> Events(int? catalogCategoryId, int? catalogLocationId,
            [FromQuery]int pageSize = 6,
            [FromQuery]int pageIndex = 0)
        {
            var root = (IQueryable<CatalogItem>)_catalogContext.CatalogItems;

            if (catalogCategoryId.HasValue && catalogCategoryId.Value > 0)
            {
                root = root.Where(c => c.CatalogCategoryId == catalogCategoryId);
            }

            if (catalogLocationId.HasValue && catalogLocationId.Value > 0)
            {
                root = root.Where(c => c.CatalogLocationId == catalogLocationId);
            }

            var totalEvents = await root.LongCountAsync();
            var eventsOnPage = await root.OrderBy(c => c.EventStartTime)
                                       .Skip(pageSize * pageIndex)
                                       .Take(pageSize)
                                       .ToListAsync();
            eventsOnPage = ChangePictureUrl(eventsOnPage);
            var model = new PaginatedItemsViewModel<CatalogItem>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = totalEvents,
                Data = eventsOnPage
            };
            return Ok(model);
        }

        // GET api/Catalog/events/withname/GroupHikeInChicago?pageSize=2&pageIndex=0
        [HttpGet]
        [Route("[action]/withname/{EventName:minlength(1)}")]
        public async Task<IActionResult> Events(string eventName,
            [FromQuery]int pageSize = 6,
            [FromQuery]int pageIndex = 0)
        {
            var totalEvents = await _catalogContext.CatalogItems
                                    .Where(c => c.EventName.StartsWith(eventName))
                                    .LongCountAsync();
            var eventsOnPage = await _catalogContext.CatalogItems
                                    .Where(c => c.EventName.StartsWith(eventName))
                                    .OrderBy(c => c.EventStartTime)
                                    .Skip(pageSize * pageIndex)
                                    .Take(pageSize)
                                    .ToListAsync();
            eventsOnPage = ChangePictureUrl(eventsOnPage);
            var model = new PaginatedItemsViewModel<CatalogItem>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = totalEvents,
                Data = eventsOnPage
            };

            return Ok(model);
        }

        [HttpPost]
        [Route("events")]
        public async Task<IActionResult> CreateEvent([FromBody] CatalogItem _event)
        {
            var eventCreate = new CatalogItem
            {
                EventName = _event.EventName,
                Price = _event.Price,
                EventStartTime = _event.EventStartTime,
                EventEndTime = _event.EventEndTime,
                Description = _event.Description,
                PictureUrl = _event.PictureUrl,
                CatalogCategoryId = _event.CatalogCategoryId,
                CatalogLocationId = _event.CatalogLocationId
            };
            _catalogContext.CatalogItems.Add(eventCreate);
            await _catalogContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEventsById), new { id = eventCreate.EventId });
        }

        [HttpPut]
        [Route("events")]
        public async Task<IActionResult> UpdateEvent([FromBody] CatalogItem eventToUpdate)
        {
            var catalogItem = await _catalogContext.CatalogItems.SingleOrDefaultAsync(i => i.EventId == eventToUpdate.EventId);
            if (catalogItem == null)
            {
                return NotFound(new { Message = $"Event with Id {eventToUpdate.EventId} not found." });
            }
            catalogItem = eventToUpdate;
            _catalogContext.CatalogItems.Update(catalogItem);
            await _catalogContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEventsById), new { id = eventToUpdate.EventId });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            var eventToDelete = await _catalogContext.CatalogItems.SingleOrDefaultAsync(e => e.EventId == eventId);

            if (eventToDelete == null)
            {
                return NotFound();
            }
            _catalogContext.CatalogItems.Remove(eventToDelete);
            await _catalogContext.SaveChangesAsync();
            return NoContent();
        }


    }
}
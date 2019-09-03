using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service) => _service = service;
                   
        public async Task<IActionResult> Index(int? categoryFilterApplied, int? locationFilterApplied, int? page)
        {
            var itemsOnPage = 8;
            var catalog = await _service.GetCatalogItemsAsync(page ?? 0, itemsOnPage, categoryFilterApplied, locationFilterApplied);

            var viewModel = new CatalogIndexViewModel
            {
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / (itemsOnPage))
                },
                CatalogItems = catalog.Data,
                Categories = await _service.GetCategoriesAsync(),
                Locations = await _service.GetLocationsAsync(),
                CategoryFilterApplied = categoryFilterApplied ?? 0,
                LocationFilterApplied = locationFilterApplied ?? 0
            };
            // if actual page is first page(0), then disable previous in html, otherwise leave as empty/no style
            viewModel.PaginationInfo.Previous = (viewModel.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";
            // if actual page is the last page(size-1), then disable next feature, otherwise leave alone
            viewModel.PaginationInfo.Next = (viewModel.PaginationInfo.ActualPage == viewModel.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            return View(viewModel);
        }

        // used for testing purposes to ensure authentication code works
        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "This is the application description page.";

            return View();
        }
    }
}
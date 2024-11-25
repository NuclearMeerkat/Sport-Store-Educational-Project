using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SportsStore.Models.Repository;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        public const int PageSize = 6;

        private readonly IStoreRepository repository;

        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ViewResult Index(string? category, int productPage = 1)
        {
            if (this.ModelState.IsValid)
            {
                return this.View(new ProductsListViewModel
                {
                    Products = this.repository.Products
                          .Where(p => category == null || p.Category == category)
                          .OrderBy(p => p.ProductId)
                          .Skip((productPage - 1) * PageSize)
                          .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = productPage,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ? this.repository.Products.Count() : this.repository.Products.Where(e => e.Category == category).Count(),
                    },

                    CurrentCategory = category,
                });
            }

            return this.View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View();
        }
    }
}

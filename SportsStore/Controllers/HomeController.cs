﻿using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SportsStore.Models.Repository;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        public const int PageSize = 4;

        private readonly IStoreRepository repository;

        public HomeController(IStoreRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index(int productPage = 1)
        {
            return this.View(new ProductsListViewModel
            {
                Products = this.repository.Products
                               .OrderBy(p => p.ProductId)
                               .Skip((productPage - 1) * PageSize)
                               .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = this.repository.Products.Count(),
                },
            });
        }
    }
}

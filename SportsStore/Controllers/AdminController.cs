﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Filters;
using SportsStore.Models;
using SportsStore.Models.Repository;

namespace SportsStore.Controllers
{
    [Authorize]
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IStoreRepository storeRepository;
        private readonly IOrderRepository orderRepository;

        public AdminController(IStoreRepository storeRepository, IOrderRepository orderRepository)
            => (this.storeRepository, this.orderRepository) = (storeRepository, orderRepository);

        [HttpGet]
        [Route("Orders")]
        public ViewResult Orders() => this.View(this.orderRepository.Orders);

        [HttpGet]
        [Route("Products")]
        public ViewResult Products() => this.View(this.storeRepository.Products);

        [HttpGet]
        [Route("Details/{productId:int}")]
        [ValidateModel]
        public ViewResult Details(int productId)
            => this.View(this.storeRepository.Products.FirstOrDefault(p => p.ProductId == productId));

        [HttpGet]
        [Route("Products/Edit/{productId:long}")]
        [ValidateModel]
        public ViewResult Edit(int productId)
        {
            return this.View(this.storeRepository.Products.FirstOrDefault(p => p.ProductId == productId));
        }

        [HttpPost]
        [Route("Products/Edit/{productId:long}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (this.ModelState.IsValid)
            {
                this.storeRepository.SaveProduct(product);
                return this.RedirectToAction("Products");
            }

            return this.View(product);
        }

        [HttpGet]
        [Route("Products/Create")]
        public ViewResult Create()
        {
            return this.View(new Product());
        }

        [HttpPost]
        [Route("Products/Create")]
        [ValidateModel]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (this.ModelState.IsValid)
            {
                this.storeRepository.SaveProduct(product);
                return this.RedirectToAction("Products");
            }

            return this.View(product);
        }

        [HttpPost]
        [Route("MarkShipped")]
        [ValidateModel]
        [ValidateAntiForgeryToken]
        public IActionResult MarkShipped(int orderId)
        {
            Order? order = this.orderRepository.Orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order != null)
            {
                order.Shipped = true;
                this.orderRepository.SaveOrder(order);
            }

            return this.RedirectToAction("Orders");
        }

        [HttpPost]
        [Route("Reset")]
        [ValidateModel]
        [ValidateAntiForgeryToken]
        public IActionResult Reset(int orderId)
        {
            Order? order = this.orderRepository.Orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order != null)
            {
                order.Shipped = false;
                this.orderRepository.SaveOrder(order);
            }

            return this.RedirectToAction("Orders");
        }

        [HttpGet]
        [Route("Products/Delete/{productId:long}")]
        [ValidateModel]
        public IActionResult Delete(int productId)
            => this.View(this.storeRepository.Products.FirstOrDefault(p => p.ProductId == productId));

        [HttpPost]
        [Route("Products/Delete/{productId:long}")]
        [ValidateModel]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProduct(int productId)
        {
            var product = this.storeRepository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product is not null)
            {
                this.storeRepository.DeleteProduct(product);
            }

            return this.RedirectToAction("Products");
        }
    }
}

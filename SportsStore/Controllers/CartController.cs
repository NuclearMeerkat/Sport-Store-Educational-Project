using Microsoft.AspNetCore.Mvc;
using SportsStore.Filters;
using SportsStore.Infrastructure;
using SportsStore.Models;
using SportsStore.Models.Repository;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IStoreRepository repository;

        public CartController(IStoreRepository repository, Cart cart)
        {
            this.repository = repository;
            this.Cart = cart;
        }

        public Cart Cart
        {
            [HttpGet]
            get;

            [HttpPost]
            [ValidateAntiForgeryToken]
            set;
        }

        [HttpGet]
        [ValidateModel]
        public IActionResult Index(Uri returnUrl)
        {
            return this.View(new CartViewModel
            {
                ReturnUrl = returnUrl ?? new Uri("/", UriKind.Relative),
                Cart = this.HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(),
            });
        }

        [HttpPost]
        [ValidateModel]
        [ValidateAntiForgeryToken]
        public IActionResult Index(long productId, Uri returnUrl)
        {
            Product? product = this.repository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                this.Cart.AddItem(product, 1);

                return this.View(new CartViewModel
                {
                    Cart = this.Cart,
                    ReturnUrl = returnUrl,
                });
            }

            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("Cart/Remove")]
        [ValidateModel]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(long productId, Uri returnUrl)
        {
            this.Cart.RemoveLine(this.Cart.Lines.First(cl => cl.Product.ProductId == productId).Product);
            return this.View("Index", new CartViewModel
            {
                Cart = this.Cart,
                ReturnUrl = returnUrl ?? new Uri("/", UriKind.Relative),
            });
        }
    }
}

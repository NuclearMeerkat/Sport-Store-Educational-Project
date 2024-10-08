using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Components
{
    public class AdminNavigationMenuViewComponent : ViewComponent
    {
        private static readonly string[] Model = new string[] { "Orders", "Products" };

        public IViewComponentResult Invoke()
        {
            this.ViewBag.Selection = this.Request.Path.Value ?? "Products";

            return this.View(Model);
        }
    }
}

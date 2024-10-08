using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class IdentitySeedData
    {
        private const string AdminUser = "Admin";
        private const string AdminPassword = "Secret123$";

        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            // Parameter check in a separate method
            ValidateParameters(app);

            await PopulateIdentityDataAsync(app);
        }

        private static void ValidateParameters(IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app);
        }

        // Method for handling async logic
        private static async Task PopulateIdentityDataAsync(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();

            var migrations = await context.Database.GetPendingMigrationsAsync();
            if (migrations.Any())
            {
                await context.Database.MigrateAsync();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser? user = await userManager.FindByNameAsync(AdminUser);

            if (user is null)
            {
                user = new IdentityUser(AdminUser)
                {
                    Email = "admin@example.com",
                    PhoneNumber = "555-1234",
                };

                await userManager.CreateAsync(user, AdminPassword);
            }
        }
    }
}

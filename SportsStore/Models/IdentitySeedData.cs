﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class IdentitySeedData
    {
        private const string AdminUser = "Admin";
        private const string AdminPassword = "Secret123$";

        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app);

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
                user = new IdentityUser("Admin")
                {
                    Email = "admin@example.com",
                    PhoneNumber = "555-1234",
                };

                await userManager.CreateAsync(user, AdminPassword);
            }
        }
    }
}

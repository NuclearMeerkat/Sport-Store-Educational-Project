using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices
                        .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Category = "Watersports",
                        Price = 275,
                        PictureUrl = "https://w7.pngwing.com/pngs/420/270/png-transparent-boat-sea-kayak-recreational-kayak-watercraft-paddle-sports-equipment-vehicle-sports-thumbnail",
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports",
                        Price = 48.95m,
                        PictureUrl = "https://w7.pngwing.com/pngs/646/324/png-transparent-gilets-life-jackets-sport-livery-life-jacket-sport-livery-life-jacket-thumbnail.png",
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m,
                        PictureUrl = "https://img.freepik.com/premium-psd/realistic-soccer-ball-png_679658-11799.jpg",
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field a professional touch",
                        Category = "Soccer",
                        Price = 34.95m,
                        PictureUrl = "https://e7.pngegg.com/pngimages/465/128/png-clipart-flag-of-the-united-states-corner-flag-flag-triangle.png",
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79500,
                        PictureUrl = "https://img.freepik.com/free-psd/beautiful-3d-isometric-stadium-isolated-transparent-background_191095-9012.jpg",
                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Chess",
                        Price = 16,
                        PictureUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQxExGOdWnDouBJ9qVp2jC2b3SSRfajFtClw&s",
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m,
                        PictureUrl = "https://png.pngtree.com/png-vector/20241109/ourlarge/pngtree-sturdy-wooden-chair-with-natural-finish-png-image_14339638.png",
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",
                        Category = "Chess",
                        Price = 75,
                        PictureUrl = "https://e7.pngegg.com/pngimages/827/531/png-clipart-chessboard-staunton-chess-set-chess-piece-szachy-king-board-game.png",
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200,
                        PictureUrl = "https://w7.pngwing.com/pngs/92/270/png-transparent-gold-chess-piece-chess-kids-xiangqi-king-chess-king-chess-game-sports.png",
                    });

                context.SaveChanges();
            }
        }
    }
}

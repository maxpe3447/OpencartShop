using Api.Storage;
using Api.Storage.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Storage;

public class DataSeed
{
    public static async Task Load(UserManager<User> userManager, AppDbContext dbContext)
    {
        if (!userManager.Users.Any(x => x.UserName == "admin"))
        {
            var user = new User
            {
                Email = "admin@gmail.com",
                UserName = "admin",
                LastName = "admin",
                FirstName = "admin",
                Phone = "+38-(123)-456-78-90"
            };
            await userManager.CreateAsync(user, "Pa$$w0rd");

            await userManager.AddToRoleAsync(user, Roles.ADMIN);
        }

        if (!dbContext.Products.Any())
        {
            string GetProductTitle(int index)
            {
                var titles = new[]
                {
            "Smartphone",
            "Laptop",
            "Headphones",
            "E-Book Reader",
            "Coffee Maker",
            "Toaster",
            "Blender",
            "Washing Machine",
            "Sneakers",
            "Jacket",
            "Sunglasses",
            "Toys",
            "Board Games",
            "Kids Puzzle",
            "Cookbook",
            "Novel",
            "Science Fiction",
            "Biography",
            "Wireless Charger",
            "Smartwatch",
            "Bluetooth Speaker",
            "Keyboard",
            "Mouse",
            "Gaming Console",
            "Action Figure"
        };

                return titles[(index) % titles.Length];
            }
            string GetProductDescription(int categoryId)
            {
                var descriptions = new[]
                {
            "High-quality product with excellent features.",
            "Durable and reliable with a modern design.",
            "Perfect for everyday use and highly recommended.",
            "Affordable yet high performance.",
            "Sleek design with advanced technology.",
            "Must-have item with great functionality.",
            "Top-rated product with great customer feedback."
        };

                return descriptions[categoryId % descriptions.Length];
            }
            decimal GetProductPrice(int index)
            {
                return 10.99m + (index * 2.50m);
            }
            decimal? GetPromotionPrice(int index)
            {
                return (index % 5 == 0) ? (decimal?)(10.99m + (index * 1.50m)) : (decimal?)null;
            }
            for (int i = 1; i <= 25; i++)
            {
                dbContext.Add(new Product
                {
                    Title = GetProductTitle(i),
                    Description = GetProductDescription(i),
                    Price = GetProductPrice(i),
                    InStock = (i % 2 == 0),
                    PromotionPrice = GetPromotionPrice(i),
                    AddedDate = DateTime.Now.AddDays(-i),
                    Images = new List<Image>
                {
                    new Image { Url = $"https://random.imagecdn.app/500/150",  IsMain = true },
                    new Image { Url = $"https://random.imagecdn.app/500/150",  IsMain = false }
                },
                    Count = (i % 20) + 1,
                    CategoryId = 1,
                });
            }
            dbContext.SaveChanges();
        }
    }
}

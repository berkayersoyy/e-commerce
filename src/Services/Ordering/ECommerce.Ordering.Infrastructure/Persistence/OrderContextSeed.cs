using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Ordering.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace ECommerce.Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext context, ILogger<OrderContextSeed> logger)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(GetPreconfiguredOrders());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}",nameof(OrderContext));
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order
                {
                    Email = "berkay@hotmail.com",
                    FirstName = "Berkay",
                    LastName = "Ersoy",
                    AddressLine = "Maltepe",
                    Country = "Turkey",
                    TotalPrice = 350
                }
            };
        }
    }
}
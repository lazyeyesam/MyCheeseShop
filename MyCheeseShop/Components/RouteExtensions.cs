using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Context;
using MyCheeseShop.Model;
using System.Security.Claims;

namespace MyCheeseShop.Components
{
    public static class RouteExtensions
    {
        public static IEndpointConventionBuilder MapAdditionalRoutes(this IEndpointRouteBuilder endpoints)
        {
            ArgumentNullException.ThrowIfNull(endpoints);

            var group = endpoints.MapGroup("/");

            group.MapGet("/reset", async (DatabaseContext context, DatabaseSeeder seeder) =>
            {
                // Remove all orders
                var orders = context.Orders.Include(order => order.Items).ToList();
                context.Orders.RemoveRange(orders);
                await context.SaveChangesAsync();

                // Remove all ratings
                var ratings = context.Ratings.ToList();
                context.Ratings.RemoveRange(ratings);
                await context.SaveChangesAsync();

                // Remove all cheeses
                var cheeses = context.Cheeses.ToList();
                context.Cheeses.RemoveRange(cheeses);
                await context.SaveChangesAsync();

                // Remove all users
                var users = context.Users.ToList();
                context.Users.RemoveRange(users);
                await context.SaveChangesAsync();

                // Seed the database
                await seeder.Seed();

                return TypedResults.LocalRedirect("/Account/Logout");
            });

            return group;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using System.Runtime.CompilerServices;

namespace Bangazon_BE.API;

public class OrdersAPI
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/api/orders", (Bangazon_BEDbContext db) =>
        {
            return db.Orders.Include(o => o.User).Include(o => o.Products);
        });

        app.MapGet("/api/order/{orderId}", (Bangazon_BEDbContext db, int orderId) =>
        {
            try
            {
                return Results.Ok(db.Orders.Single(order => order.Id == orderId));
            }
            catch (InvalidOperationException)
            {
                return Results.NotFound("This order does not exist");
            }
        });

        app.MapPost("/api/order", (Bangazon_BEDbContext db, Orders order) =>
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return Results.Created($"/api/order/{order.Id}", order);
        });
    }
}


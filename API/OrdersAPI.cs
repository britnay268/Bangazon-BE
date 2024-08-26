using Microsoft.EntityFrameworkCore;
using Bangazon_BE.Models;
using Bangazon_BE.DTOs;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Builder;

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

        // Add Product to an Order
        app.MapPost("/api/order/add/{productId}", (Bangazon_BEDbContext db, int productId, int userId) =>
        {
            var cart = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.UserId == userId && o.Completed == false);

            if (cart == null)
            {
                cart = new Orders { UserId = userId, Completed = false };
                cart.Products = new List<Products>();

                db.Orders.Add(cart);
            }

            Products product = db.Products.SingleOrDefault(p => p.Id == productId);

            cart.Products.Add(product);
            db.SaveChanges();

            Results.Ok(cart);
        });
    }
}


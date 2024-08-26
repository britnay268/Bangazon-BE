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
        // GET all Orders
        app.MapGet("/api/orders", (Bangazon_BEDbContext db) =>
        {
            return db.Orders.Include(o => o.User).Include(o => o.Products);
        });

        // GET Order Details
        app.MapGet("/api/order/{orderId}", (Bangazon_BEDbContext db, int orderId) =>
        {
            try
            {
                return Results.Ok(db.Orders.Include(o => o.Products).Include(o => o.User).Single(order => order.Id == orderId)); ;
            }
            catch (InvalidOperationException)
            {
                return Results.NotFound("This order does not exist");
            }
        });

        // POST Create an Order
        app.MapPost("/api/order", (Bangazon_BEDbContext db, Orders order) =>
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return Results.Created($"/api/order/{order.Id}", order);
        });

        // POST Add Product to an Order
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

        // PUT Update the Order with OrderNum, DatePlaced, PaymentTypeId, and Completion
        app.MapPut("/api/order/{orderId}", (Bangazon_BEDbContext db, int orderId, Orders orderUpdate) =>
        {
            Orders orderToUpdate = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == orderId);

            if (orderToUpdate == null)
            {
                return Results.NotFound("The odrder does not exist.");
            }

            orderToUpdate.Completed = orderUpdate.Completed;
            orderToUpdate.PaymentTypeId = orderUpdate.PaymentTypeId;
            orderToUpdate.DatePlaced = orderUpdate.DatePlaced;
            orderToUpdate.OrderNum = orderUpdate.OrderNum;

            db.SaveChanges();

            return Results.NoContent();
        });

        // DELETE Product from an Order
        app.MapDelete("/api/orddr/{orderid}/product/{productId}", (Bangazon_BEDbContext db, int orderId, int productId) =>
        {
            Orders order = db.Orders.Include(o => o.Products).FirstOrDefault(o => o.Id == orderId);

            if (order == null)
            {
                return Results.NotFound("Order not found.");
            }

            var productToDelete = order.Products.FirstOrDefault(p => p.Id == productId);

            if (productToDelete == null)
            {
                return Results.NotFound("Product not found in the order.");
            }

            order.Products.Remove(productToDelete);
            db.SaveChanges();

            return Results.Ok($"Product {productId} has been deleted");
        });
    }
}


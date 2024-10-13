using Bangazon_BE.Models;
using Bangazon_BE.Data;
using Microsoft.EntityFrameworkCore;
using Bangazon_BE.DTOs;

namespace Bangazon_BE.API;

public class UsersAPI
{
	public static void Map(WebApplication app)
	{
		// GET all User
		app.MapGet("/api/users", (Bangazon_BEDbContext db) =>
		{
            return db.Users;
		});


    // GET User's Orders
    app.MapGet("/api/user/{userId}/orders", (Bangazon_BEDbContext db, int userId) =>
		{
			try
			{
                // var usersOrders = db.Orders.Include(order => order.User).Include(order => order.Products).FirstOrDefault(order => order.UserId == userId && order.Completed == false);

                var usersOrders = db.Orders
                    .Select(order => new
					{
						Id = order.Id,
						OrderNum = order.OrderNum,
						DatePlaced = order.DatePlaced,
						Completed = order.Completed,
						UserId = order.UserId,
						Products = order.Products.Select(product => new
						{
							Id = product.Id,
							Name = product.Name,
							Price = product.Price,
							Description = product.Description,
							Quantity= product.Quantity,
                            CartQuantity = product.CartQuantity,
							ImageUrl = product.ImageUrl,
							UserId = product.UserId,
							User = product.User,
							CategoryId = product.CategoryId,
							Category = product.Category
						}),
						TotalPrice = order.Products.Sum(p => p.CartQuantity > 0 ? p.Price * p.CartQuantity : 0),
					}).FirstOrDefault(order => order.UserId == userId && order.Completed == false);


				if (usersOrders == null)
				{
                    var newOrder = new Orders { Id = db.Orders.Max(o => o.Id) + 1, UserId = userId, Completed = false };
					newOrder.Products = new List<Products>();

					db.Orders.Add(newOrder);
					db.SaveChanges();

					return Results.Ok(newOrder);
				}

				return Results.Ok(usersOrders);

				
			}
			catch (InvalidOperationException)
			{
				return Results.NotFound("The user does not exist!");
			}
			catch (ArgumentException)
			{
				return Results.BadRequest("Please select a user!");
			}
        });

		// GET User details
		app.MapGet("/api/user/{userId}", (Bangazon_BEDbContext db, int userId) =>
		{
            try
            {
                return Results.Ok(db.Users.SingleOrDefault(user => user.Id == userId));
            }
            catch (InvalidOperationException)
            {
                return Results.NotFound("This user does not exist!");
            }
        });

		// GET Seller's Products
		app.MapGet("/api/sellers/{sellerId}/products", (Bangazon_BEDbContext db, int sellerid) =>
		{
			try
			{
				return Results.Ok(db.Products.Select(product => new
				{
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Quantity = product.Quantity,
                    ImageUrl = product.ImageUrl,
                    UserId = product.UserId,
                    User = product.User,
                    CategoryId = product.CategoryId,
                    Category = product.Category
                }).Where(p => p.UserId == sellerid).ToList());
			}
			catch
			{
				return Results.NotFound("This user does not exist!");
			}
		});

		// Check User
		app.MapPost("/checkuser", (Bangazon_BEDbContext db, string uid) =>
		{

            try
            {
                var user = db.Users.SingleOrDefault(u => u.Uid == uid);

                if (user != null)
                {
                    return Results.Ok(new { User = user, Message = "User found successfully" });
                }
                else
                {
                    return Results.NotFound("User not found");
                }
            }
            catch (InvalidOperationException)
            {
                return Results.NotFound("This user does not exist!");
            }
            catch (ArgumentNullException)
            {
                return Results.NotFound();
            }

        });

        // Create User
        app.MapPost("/api/user", (Bangazon_BEDbContext db, Users user) =>
        {
            db.Users.Add(user);
            db.SaveChanges();
            return Results.Created($"/api/user/{user.Id}", user);
        });

		app.MapGet("/api/user/{userId}/orders/completed", (Bangazon_BEDbContext db, int userId) =>
		{
            try
            {
                var completedOrders = db.Orders
                    .Select(order => new
                    {
                        Id = order.Id,
                        OrderNum = order.OrderNum,
                        DatePlaced = order.DatePlaced,
                        Completed = order.Completed,
                        UserId = order.UserId,
                        Products = order.Products.Select(product => new
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            Description = product.Description,
                            Quantity = product.Quantity,
                            ImageUrl = product.ImageUrl,
                            UserId = product.UserId,
                            User = product.User,
                            CategoryId = product.CategoryId,
                            Category = product.Category
                        })
                    }).Where(order => order.UserId == userId && order.Completed == true).OrderBy(order => order.DatePlaced);

				return Results.Ok(completedOrders);
            }
            catch (InvalidOperationException)
            {
                return Results.NotFound("The user does not exist!");
            }
            catch (ArgumentException)
            {
                return Results.BadRequest("Please select a user!");
            }
        });
    }
}

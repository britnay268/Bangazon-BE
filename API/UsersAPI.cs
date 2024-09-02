using Bangazon_BE.Models;
using Bangazon_BE.Data;
using Microsoft.EntityFrameworkCore;
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
				var usersOrders = db.Orders.Include(order => order.User).Include(order => order.Products).FirstOrDefault(order => order.UserId == userId && order.Completed == false);

				if (usersOrders == null)
				{
					usersOrders = new Orders {Id = db.Orders.Max(o =>o.Id) + 1, UserId = userId, Completed = false };
					usersOrders.Products = new List<Products>();

					db.Orders.Add(usersOrders);
					db.SaveChanges();

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
				return Results.Ok(db.Products.Where(p => p.UserId == sellerid).ToList());
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
    }
}

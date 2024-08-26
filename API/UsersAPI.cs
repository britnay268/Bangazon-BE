using Bangazon_BE.Models;
using Bangazon_BE.Data;
using Microsoft.EntityFrameworkCore;
namespace Bangazon_BE.API;

public class UsersAPI
{
	public static void Map(WebApplication app)
	{
		app.MapGet("/api/users", (Bangazon_BEDbContext db) =>
		{
			return db.Users;
		});

		app.MapGet("/api/user/{userId}/orders", (Bangazon_BEDbContext db, int userId) =>
		{
			try
			{
				return Results.Ok(db.Orders.Include(order => order.User).Include(order => order.Products).FirstOrDefault(order => order.UserId == userId));
			}
			catch (InvalidOperationException)
			{
				return Results.NotFound("The user does not exist");
			}
			catch (ArgumentException)
			{
				return Results.BadRequest("Please select a user");
			}
        });

		app.MapGet("/api/user/{userId}", (Bangazon_BEDbContext db, int userId) =>
		{
            try
            {
                return Results.Ok(db.Users.Single(user => user.Id == userId));
            }
            catch (InvalidOperationException)
            {
                return Results.NotFound("This user does not exist");
            }
        });

		app.MapGet("/api/sellers/{sellerId}/products", (Bangazon_BEDbContext db, int sellerid) =>
		{
			return db.Users.Include(user => user.Products).Single(user => user.Id == sellerid);
		});
	}
}

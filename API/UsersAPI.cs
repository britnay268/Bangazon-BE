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
				return Results.Ok(db.Orders.Include(order => order.User).Include(order => order.Products).Single(user => user.Id == userId));
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
	}
}

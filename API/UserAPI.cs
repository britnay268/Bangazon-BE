using Bangazon_BE.Models;
using Bangazon_BE.Data;
using Microsoft.EntityFrameworkCore;

namespace Bangazon_BE.API;

public class UserAPI
{
	public static void Map(WebApplication app)
	{
		app.MapGet("/api/users", (Bangazon_BEDbContext db) =>
		{
			return db.Users;
		});

		app.MapGet("/api/user/{userId}/orders", (Bangazon_BEDbContext db, int userId) =>
		{
            return db.Orders.Include(order => order.User).Include(order => order.Products).Where(user => user.Id == userId);
        });
	}
}


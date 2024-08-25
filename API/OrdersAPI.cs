using Microsoft.EntityFrameworkCore;
namespace Bangazon_BE.API;

public class OrdersAPI
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/api/orders", (Bangazon_BEDbContext db) =>
        {
            return db.Orders.Include(o => o.User).Include(o => o.Products);
        });
	}
}


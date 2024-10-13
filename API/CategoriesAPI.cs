using System;
using Bangazon_BE.Models;
namespace Bangazon_BE.API;

public class CategoriesAPI
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/api/categories", (Bangazon_BEDbContext db) => {
            return db.Categories;
        });

        app.MapGet("/api/categories/{id}", (Bangazon_BEDbContext db, int id) =>
        {
            try
            {
                return Results.Ok(db.Categories.Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,
                    Products = c.Products,
                }).SingleOrDefault(category => category.Id == id));
            }
            catch (InvalidOperationException)
            {
                return Results.NotFound("This user does not exist!");
            }
        });
	}
}

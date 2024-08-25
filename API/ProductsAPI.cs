﻿using Bangazon_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace Bangazon_BE.API;

public class ProductsAPI
{
    public static void Map(WebApplication app)
    {
        // GET all Products
        app.MapGet("/api/products", (Bangazon_BEDbContext db) =>
        {
            return db.Products.Include(product => product.User).Include(product => product.Category).Select(product => new
            {
                product.Id,
                product.Name,
                product.Price,
                product.Description,
                product.Quantity,
                product.ImageUrl,
                product.User,
                product.Category
            }).OrderBy(product => product.Id);
        });

        // GET product details
        app.MapGet("/api/products/{productId}", (Bangazon_BEDbContext db, int productId) =>
        {
            try
            {
                return Results.Ok(db.Products.Include(product => product.User).Include(product => product.Category).Single(product => product.Id == productId));
            }
            catch (InvalidOperationException)
            {
                return Results.NotFound("This product does not exist");
            }
        });

        app.MapGet("/api/product/search", (Bangazon_BEDbContext db, string searchInput) =>
        {
            searchInput = searchInput.ToLower();

            var searchResults = db.Products
        .Where(p => p.Name.ToLower().StartsWith(searchInput) ||
                    p.Name.ToLower().Contains(searchInput)).ToList();

            // If search results is empty based on the searchInput, it will throw a not found error
            if (!searchResults.Any())
            {
                return Results.NotFound("No products found matching your search term.");
            }

            return Results.Ok(searchResults);
        });
    }
}

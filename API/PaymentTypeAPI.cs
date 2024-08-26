using System;
using Microsoft.EntityFrameworkCore;

namespace Bangazon_BE.API;

public class PaymentTypeAPI
{
    public static void Map(WebApplication app)
    {
        // Gets all Payment types
        app.MapGet("/api/paymentTypes", (Bangazon_BEDbContext db) =>
        {
            return db.PaymentTypes;
        });
    }
}


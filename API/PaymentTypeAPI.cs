using System;
using Microsoft.EntityFrameworkCore;

namespace Bangazon_BE.API;

public class PaymentTypeAPI
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/api/paymentTypes", (Bangazon_BEDbContext db) =>
        {
            return db.PaymentTypes;
        });
    }
}


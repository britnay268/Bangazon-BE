using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using Bangazon_BE;
using Bangazon_BE.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<Bangazon_BEDbContext>(builder.Configuration["Bangazon_BEConnectionString"]);

// Set the JSON serializer options
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

//  This configures how the backend handles requests from the frontend
// It's essentially giving permission to other applications to access your backend.
// It will only handle requests from the address in the WithOrgins function
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3000")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

UsersAPI.Map(app);
ProductsAPI.Map(app);
OrdersAPI.Map(app);
PaymentTypeAPI.Map(app);
CategoriesAPI.Map(app);

app.Run();

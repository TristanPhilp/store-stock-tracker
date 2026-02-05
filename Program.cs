
using Microsoft.EntityFrameworkCore;
using store_stock_tracker.Data;
//imports the Entity Framework Core and data context

var builder = WebApplication.CreateBuilder(args);

//Configures SQLite
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

//If using a development environment, the app uses swagger for testing purposes
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Run();

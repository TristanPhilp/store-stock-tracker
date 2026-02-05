
using Microsoft.EntityFrameworkCore;
using store_stock_tracker.Data;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.MapGet("/", () => "Hello World!");
app.Run();

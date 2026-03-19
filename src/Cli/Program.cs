
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_stock_tracker.Data;
using store_stock_tracker.src.Cli.Utils;
//imports the Entity Framework Core and data context

public partial class Program : ControllerBase
{
    public static int Main(string[] args)
    {
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
        ProductAccessor instance = ProductAccessor.GetInstance();

        List<Product> products = instance.Query("SELECT * FROM Products");

        app.MapGet("/products", () =>  products);
        app.Run();


        return Controller.RunCli();
    }
}



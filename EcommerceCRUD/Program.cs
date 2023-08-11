using EcommerceCRUD.Database;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

string connString = builder.Configuration.GetConnectionString("DefaultConnection");

Console.WriteLine(connString);

builder.Services.AddDbContext<EcommerceCRUDContext>(opts =>
{
    opts.UseMySql(connString, new MySqlServerVersion(new Version(8, 0, 33)),
        mySqlOpts =>
        {
            mySqlOpts.EnableRetryOnFailure();
        });
});

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();


// Map 
app.MapControllers();

app.Run();

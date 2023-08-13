using EcommerceCRUD.Database;
using EcommerceCRUD.Repositories;
using EcommerceCRUD.Repositories.Interfaces;
using EcommerceCRUD.Services;
using EcommerceCRUD.Services.Interfaces;
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

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();


// Map 
app.MapControllers();

app.Run();

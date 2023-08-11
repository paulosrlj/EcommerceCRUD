var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

var app = builder.Build();


// Map 
app.MapControllers();

app.Run();

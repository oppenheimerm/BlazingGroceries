using BG.Products.API.Data;
using BG.Products.API.Services;
using BG.Shared.Middleware;
using BG.Shared;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ProductDataContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
  sqlServerOptionsAction: sqlOptions =>
  {
      // Configure connection resiliency:
      sqlOptions.EnableRetryOnFailure(maxRetryCount: 5,
          maxRetryDelay: TimeSpan.FromSeconds(30),
          errorNumbersToAdd: null);
  }));


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureService(builder.Configuration);


var app = builder.Build();

// Setup our middleware
//app.UseInfrastructurePolicy();

//  Testing / Developer random error
//app.UseMiddleware<RandomFailure>();




// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();


//  Initialize dtabase for testing
//  Create the database if it doesn't exist:
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ProductDataContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

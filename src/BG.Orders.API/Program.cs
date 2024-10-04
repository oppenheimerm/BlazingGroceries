using BG.Orders.API.Data;
using BG.Orders.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureService(builder.Configuration);


var app = builder.Build();

//  Hold off until API gateway
app.UseInfrastructurePolicy();



// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


//  Initialize dtabase for testing
//  Create the database if it doesn't exist:
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<OrderDataContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

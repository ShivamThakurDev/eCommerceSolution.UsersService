using eCommerce.Infrastructure;
using eCommerce.Core;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
//Add Infrastructure Services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers to the service collection 
builder.Services.AddControllers();
//Build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing 
app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes 
app.MapGet("/", () => "Hello World!");
app.Run();

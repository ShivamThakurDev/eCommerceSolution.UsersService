using eCommerce.Infrastructure;
using eCommerce.Core;
using Microsoft.Extensions.DependencyInjection;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//Add Infrastructure Services
builder.Services.AddInfrastructure();
builder.Services.AddCore();
// Add controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//FluentValidations
builder.Services.AddFluentValidationAutoValidation();
//Add API explorer services 
builder.Services.AddEndpointsApiExplorer();
//Add swagger services to configure the swagger document
builder.Services.AddSwaggerGen();
//Add cors services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
//Build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing 
app.UseRouting();
app.UseSwagger();//Adds endpoints that can serve the swagger.json
app.UseSwaggerUI();//Add swagger UI to the application
//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes 
app.MapControllers();
app.Run();

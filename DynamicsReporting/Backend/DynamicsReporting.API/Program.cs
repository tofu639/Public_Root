using DynamicsReporting.BusinessLogic.Service.Group.Interface;
using DynamicsReporting.BusinessLogic.Service.Report.Interface;
using DynamicsReporting.BusinessLogic.Service.User;
using DynamicsReporting.BusinessLogic.Service.User.Interface;
using DynamicsReporting.DataAccess.Repository.DatabaseConnection;
using DynamicsReporting.DataAccess.Repository.Logging;
using DynamicsReporting.ExternalService;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure DI
//builder.Services.AddTransient<IUserService, UserService>();

//builder.Services.AddCustomBusinessLogicServices();
//builder.Services.AddCustomDataAccessServices(builder.Configuration);

if (!builder.Environment.IsEnvironment("SwaggerOnly"))
{
    builder.Services.AddCustomBusinessLogicServices();
    builder.Services.AddCustomDataAccessServices(builder.Configuration);
}

 


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DynamicsReporting API",
        Version = "v1"
    });
});

var app = builder.Build();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "DynamicsReporting API v1");
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();
await app.RunAsync();
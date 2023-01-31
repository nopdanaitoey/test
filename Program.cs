using System.Reflection;
using Test_HarmonyX_API.Interfaces;
using Test_HarmonyX_API.Iservice;
using Test_HarmonyX_API.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "V1",
        Title = "Test HarmonyX",
        Description = "Nopdanai Khammueng For Test HarmonyX"
    });

});
builder.Services.AddScoped<IPromotionService, PromotionService>();
builder.Services.AddScoped<IExchangeService, ExchangeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test HarmonyX API");
    c.RoutePrefix = String.Empty;
});

// }

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

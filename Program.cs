using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
using WebApp.Net.Core.Api.EF.Core.Angular.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configurationService =  builder.Services.BuildServiceProvider().GetService<IConfiguration>();
builder.Services.AddDbContext<AppDbContext1>(options => options.UseSqlServer(configurationService.GetConnectionString("appSetttingsCon1")));
//builder.Services.AddControllers();//.AddFluentValidation
builder.Services.AddControllersWithViews();//No service for type 'Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionaryFactory' has been registered

builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.UseMvc(options => options.EnableEndpointRouting = false);

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MvcPersona}/{action=Index}/{id?}");

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=MvcPersona}/{action=Index}/{id?}"
        );
});*/

//http://localhost:5023/MvcPersona/Index
app.Run();

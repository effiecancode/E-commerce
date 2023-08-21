using DatabaseAccessLayer.BusinessLogic;
using DatabaseAccessLayer.EcommerceDBContext;
using DatabaseAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

//Register services
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<CategoryBusinessLogic>();
//Allows swagger to explore API end points that arein our projects
builder.Services.AddEndpointsApiExplorer();
//Register swagger documentation
builder.Services.AddSwaggerGen();
//Registering DbContext
var serverVersion = ServerVersion.AutoDetect(builder.Configuration["DbConnection"]);
builder.Services.AddDbContext<EcommerceContext>(options => options.UseMySql(builder.Configuration["DbConnection"], serverVersion));
var app = builder.Build();
#region Run all Pending Migrations
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<EcommerceContext>();
    var pendingMigrations = ctx.Database.GetPendingMigrations();
    var migrator = ctx.GetInfrastructure().GetService<IMigrator>();
    foreach (var migration in pendingMigrations)
    {
        migrator?.Migrate(migration);
    }
}
#endregion

app.MapGet("category/", (CategoryBusinessLogic CatBiz) => CatBiz.GetCategories());

app.MapPost("category", (Category category, CategoryBusinessLogic CatBiz) =>
{
    //CatBiz.AddCategory(category);
    //CatBiz.SaveChanges();
    return Results.Ok(CatBiz.AddCategory(category));
});
//Register swagger API middle wares
app.UseCors("corsapp"); //allow single page application to make a call successfully
                        //(cross origin) requst must be from same origin disables from different origin
app.UseSwagger();
app.UseSwaggerUI();
app.Run();

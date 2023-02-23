using FullStackApi.Context;
using FullStackApi.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var server = Environment.GetEnvironmentVariable("DatabaseServer");
var port = Environment.GetEnvironmentVariable("DatabasePort");
var user = Environment.GetEnvironmentVariable("DatabaseUser");
var password = Environment.GetEnvironmentVariable("DatabasePassword");
var database = Environment.GetEnvironmentVariable("DatabaseName");
var connectionstring = $"Server={server}, {port}; Initial Catalog= {database}; User ID= {user}; Password= {password}";
builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connectionstring));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProjectContext>();
    db.Database.Migrate();

    if (!db.Recourses.Any())
    {
        db.Recourses.AddRange(
            new Resource() { ResourceName = "Resource1" },
            new Resource() { ResourceName = "Resource2" }
        );
        db.SaveChanges();
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();

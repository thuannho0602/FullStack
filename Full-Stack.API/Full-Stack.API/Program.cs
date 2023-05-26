using Full_Stack.DataAccess;//1

using Full_Stack.Entity;//1

using Microsoft.AspNetCore.Identity;//1
using Microsoft.EntityFrameworkCore;//1
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;//1
using System.Reflection;
using Full_Stack.Repository;
using Full_Stack.Repository.Implementations;
using Full_Stack.Services;
using Full_Stack.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

//Add Database 

builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Full-Stack.API")));




//Add Services

// Add Menu

builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IMenuServices, MenuServices>();

//// ChildRentMenu

//builder.Services.AddTransient<IChildRentMenuRepository, ChildRentMenuRepository>();
//builder.Services.AddScoped<IChildRentMenuServices, ChildRentMenuServices>();
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

app.UseHttpsRedirection();


//app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IServiceFlight,ServiceFlight>();
builder.Services.AddScoped<IServiceFlight, ServiceFlight>();
builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
builder.Services.AddDbContext<DbContext, AMContext>();
builder.Services.AddSingleton<Type>(T => typeof(GenericRepository<>));
//builder.Services.AddTransient<IServiceFlight, ServiceFlight>(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

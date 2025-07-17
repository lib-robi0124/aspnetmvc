using MovieRentalApp.Services.Implementation;
using MovieRentalApp.Services.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// 👇 Required for sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// 👇 Register your services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IRentalService, RentalService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// 👇 Enable session before accessing HttpContext.Session
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();

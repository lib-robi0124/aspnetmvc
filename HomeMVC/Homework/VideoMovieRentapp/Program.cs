using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using VideoMovieRent.DataAccess;
using VideoMovieRent.DataAccess.Implementation;
using VideoMovieRent.DataAccess.Interfaces;
using VideoMovieRent.Domain;
using VideoMovieRent.Services.Interfaces;
using VideoMovieRent.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<FormOptions>(options => {
    options.MultipartBodyLengthLimit = 104857600; // 100 MB
});

builder.Services.AddDbContext<VideoMovieRentDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnString")));

builder.Services.AddScoped<IRepository<Movie>, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();

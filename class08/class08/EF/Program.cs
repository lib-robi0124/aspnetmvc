using EF.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Register your DbContext with the connection string from appsettings.json
builder.Services.AddDbContext<AcademyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AcademyDbConnString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

// Add the connection string to appsettings.json
/*
"ConnectionStrings": {
  "AcademyDbConnString": "Server=.;Database=AvengaDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
*/

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using CarRentalACC.Areas.Identity;
using CarRentalACC.Data;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("RentApi"));
builder.Services.AddTransient<ICarsService, CarsService>();
builder.Services.AddTransient<IReservationsService, ReservationsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

static void AddCustomerData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetService<DataContext>();

    var car1 = new Car
    {
        Id = 1,
        Model = "BMW 3",
        Description = "Szybkie auto i dynamiczne",
        Price = 100
    };

    var car2 = new Car
    {
        Id = 2,
        Model = "BMW 5",
        Description = "Szybkie auto i dynamiczne",
        Price = 200
    };

    var car3 = new Car
    {
        Id = 3,
        Model = "BMW 7",
        Description = "Szybkie auto i dynamiczne",
        Price = 500
    };

    db.Cars.Add(car1);
    db.Cars.Add(car2);
    db.Cars.Add(car3);

    db.SaveChanges();
}
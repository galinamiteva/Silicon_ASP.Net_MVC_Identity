using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options => options.LowercaseUrls = true);



// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<FeatureItemRepository>();
builder.Services.AddScoped<FeatureRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<FeatureService>();
builder.Services.AddScoped<AddressManager>();





//builder.Services.ConfigureApplicationCookie(x =>
//{
//    x.Cookie.HttpOnly = true;
//    x.LoginPath = "/signin";
//    x.LogoutPath = "/signout";
//    x.AccessDeniedPath = "/denied";

//    x.Cookie.HttpOnly= true;
//    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
//    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
//    x.SlidingExpiration=true;
//});


var app = builder.Build();

app.UseHsts();
app.UseStatusCodePagesWithReExecute("/error", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
//app.UseUserSessionValidation();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

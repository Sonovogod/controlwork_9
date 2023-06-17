using controlWork_9.Extensions;
using controlWork_9.Models;
using controlWork_9.Services.FilesServices;
using controlWork_9.Services.FilesServices.Abstracts;
using controlWork_9.Services.UsersServices;
using controlWork_9.Services.UsersServices.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WalletDbContext>(options => options.UseNpgsql(connection))
    .AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 5;
        options.Password.RequireLowercase = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;

        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<WalletDbContext>();


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IImageProfile, ImageProfile>();


var app = builder.Build();

var serviceProvider = app.Services;
using var scope = serviceProvider.CreateScope();
try
{
    UserManager<User> userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    await DataSeed.SeedAdminUser(userManager);
}
catch (Exception e)
{
    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    logger.LogCritical(e, "Не удалось создать тестового юзера");
}

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
    pattern: "{controller=HomePages}/{action=Main}/{id?}");

app.Run();
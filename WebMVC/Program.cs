using Album.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using WebMVC.Core.Context;
using WebMVC.Core.Infrastructure;
using WebMVC.Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionStrings = builder.Configuration.GetConnectionString("MyCnn");

builder.Services.AddDbContext<MySchoolContext>(opts =>
{
    opts.UseSqlServer(connectionStrings);
});

//builder.Services.AddDefaultIdentity<IdentityUser, IdentityRole>()
//                .AddEntityFrameworkStores<MySchoolContext>()
//                .AddDefaultTokenProviders();

builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<MySchoolContext>()
                .AddDefaultTokenProviders();
builder.Services.AddInfrastructureServices();

// Truy cập IdentityOptions
builder.Services.ConfigIdentity();
// Cấu hình Cookie
builder.Services.ConfigCookie();

builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    // Trên 5 giây truy cập lại sẽ nạp lại thông tin User (Role)
    // SecurityStamp trong bảng User đổi -> nạp lại thông tinn Security
    options.ValidationInterval = TimeSpan.FromSeconds(5);
});

builder.Services.AddOptions();                                        // Kích hoạt Options
var mailsettings = builder.Configuration.GetSection("MailSettings");  // đọc config
builder.Services.Configure<MailSettings>(mailsettings);               // đăng ký để Inject

builder.Services.AddTransient<IEmailSender, SendMailService>();        // Đăng ký dịch vụ Mail
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

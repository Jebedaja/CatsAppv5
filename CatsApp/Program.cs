using CatsApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CatsConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddHttpClient(); 

builder.Services.ConfigureApplicationCookie(options =>          // sesja przechowywana w ciasteczkach
{
    options.ExpireTimeSpan = TimeSpan.FromSeconds(600); // czas wygaśnięcia ciasteczka  10 minut
    options.Events.OnRedirectToLogin = context =>
    {
        
        context.Response.ContentType = "text/html";                                             // Skrpyt JS dodający pop up o wygaśnięciu sesji
        var script = @"    
            <script>
                alert('You are not logged in or your session has expired');
                window.location.href = '/Identity/Account/Login';
            </script>";
        return context.Response.WriteAsync(script);
    };
});

var app = builder.Build();  


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();           
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");         

app.Run();


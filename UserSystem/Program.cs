using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserSystem.Areas.Identity.Data;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

//! configuring the dbcontext for identity database context
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("DB URL HERE"));





builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>();;


// Add services to the container.
builder.Services.AddControllersWithViews();

//! editing password requirements
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//! to disable some identity pages, redirects you to /Identity/Account/Manage instead
app.Map("/Identity/Account/ForgotPassword", HandleRequest);
app.Map("/Identity/Account/ResendEmailConfirmation", HandleRequest);
app.Map("/Identity/Account/Manage/Email", HandleRequest);
app.Map("/Identity/Account/Manage/TwoFactorAuthentication", HandleRequest);

static void HandleRequest(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        context.Response.Redirect("/Identity/Account/Manage");
    });
}

//! 404 pages handler
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/Error404";
        await next();
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();
//! for area routes
app.MapAreaControllerRoute(
    name: "myIdentity",
    areaName: "Identity",
    pattern: "Identity/{controller=Home}/{action=Index}/{id?}");
//! for controller routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//! to enable razor pages mapping
app.MapRazorPages();

app.Run();

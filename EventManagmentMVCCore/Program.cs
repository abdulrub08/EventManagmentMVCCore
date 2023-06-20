using Event.DAL.Repositories;
using Event.DAL.Repository;
using Event.DOM;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Text;
using EventManagmentMVCCore.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
//});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<AppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
//Register dapper in scope    
//builder.Services.AddScoped<IDapperRepositry, DapperRepositry>();
builder.Services.AddTransient<IDropdownCommonRepository, DropdownCommonRepository>();
builder.Services.AddTransient<ILoginRepository, LoginRepository>();
builder.Services.AddTransient<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddTransient<IFileUploadServices, FileUploadServices>();
builder.Services.AddTransient<IVenueRepository, VenueRepository>();
builder.Services.AddTransient<ICommonRepository, CommonRepository>();

builder.Services.AddAntiforgery(options => { options.SuppressXFrameOptionsHeader = true; });
//builder.Services.Configure<StripeOptions>(Configuration.GetSection("StripeSettings"));
//builder.Services.Configure<StripeOptions>(builder.Configuration.GetSection("StripeSettings"));

builder.Services.AddSession(options =>
{

    // default session time out is 20 minutes 
    // but we can set it to any time span 
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    // allows to use the session cookie 
    // even if the user hasn't consented 
    options.Cookie.IsEssential = true;

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowMyOrigin");
app.UseCookiePolicy();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();

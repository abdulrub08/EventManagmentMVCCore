using Event.DAL.Repositories;
using Event.DAL.Repository;
using EventManagmentMVCCore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Dependency;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EventManagmentMVCCore.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("EventDBContextConnection") ?? throw new InvalidOperationException("Connection string 'EventDBContextConnection' not found.");

builder.Services.AddDbContext<EventDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<EventManagmentUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<EventDBContext>();

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
builder.Services.AddTransient<IVenueRepository, VenueRepository>();
builder.Services.AddTransient<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddTransient<IFileUploadServices, FileUploadServices>();
builder.Services.AddTransient<ICommonRepository, CommonRepository>();
builder.Services.AddMediatR(x=> x.RegisterServicesFromAssemblies(typeof(Program).Assembly));
builder.Services.AddAntiforgery(options => { options.SuppressXFrameOptionsHeader = true; });
//builder.Services.Configure<StripeOptions>(Configuration.GetSection("StripeSettings"));
//builder.Services.Configure<StripeOptions>(builder.Configuration.GetSection("StripeSettings"));

builder.Services.AddSession( opt => 
{

    // default session time out is 20 minutes 
    // but we can set it to any time span 
    opt.IdleTimeout = TimeSpan.FromMinutes(30);
    // allows to use the session cookie 
    // even if the user hasn't consented 
    opt.Cookie.IsEssential = true;

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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();

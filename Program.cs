using Microsoft.EntityFrameworkCore; // place this line at the beginning of file.
using zuiderzorg.Models;
using zuiderzorg.Auth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using zuiderzorg.Services;
using zuiderzorg.RouteModelConventions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<AuthChecker>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddRazorPages().AddViewLocalization();
builder.Services.AddRazorPages(options => {
        options.Conventions.Add(new CultureTemplatePageRouteModelConvention());
    });
 builder.Services.Configure<RequestLocalizationOptions>(
    opt => {
        var supportCulteres = new List<CultureInfo>
        {
            new CultureInfo("en"),
            new CultureInfo("nl")
        };
            opt.DefaultRequestCulture = new RequestCulture("nl");
            opt.SupportedCultures = supportCulteres;
            opt.SupportedUICultures = supportCulteres;
            opt.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider { Options = opt });
         });
        // services.AddRazorPages();
builder.Services.AddSingleton<CommonLocalizationService>();
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);
app.UseAuthorization();

app.MapRazorPages();

app.Run();


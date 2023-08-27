using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using OpencartShop.Domain;
using OpencartShop.Helpers;
using OpencartShop.Service.Repository.Auth.LoginService;
using OpencartShop.Service.Repository.Auth.RegistrationService;
using OpencartShop.Service.Repository.Catalog;
using OpencartShop.Service.Repository.Catalog.CatalogService;
using OpencartShop.Service.Repository.Catalog.CategoryService;
using OpencartShop.Service.Repository.Catalog.SubCatalogServices;
using OpencartShop.Service.Repository.Products.ProductColors;
using OpencartShop.Service.Repository.Products.ProductService;
using OpencartShop.Service.Repository.Products.ProductSizes;
using OpencartShop.Controllers;
using OpencartShop.Service.Repository.OrderService;
using OpencartShop.Service.Repository.ReturnProductService;
using OpencartShop.Service.UserDataService;
using OpencartShop.Service.Repository.FavoriteProductsService;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.Bind("Project", new Config());
builder.Configuration.Bind("AuthOptions", new AuthConfigs());

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthConfigs.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthConfigs.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthConfigs.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };
                });


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(b=>b.UseSqlite(Config.ConnectionString));

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<ICatalogManager, CatalogManager>();
builder.Services.AddTransient<ICatalogService, CatalogService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ISubCatalogService, SubCatalogService>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IRegistrationService, RegistrationService>();
builder.Services.AddTransient<IProductColorsService, ProductColorsService>();
builder.Services.AddTransient<IProductSizesService, ProductSizesService>();
builder.Services.AddTransient<IProductService , ProductService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IReturnProductService, ReturnProductService>();
builder.Services.AddTransient<IUserDataService, UserDataService>();
builder.Services.AddTransient<IFavoriteProductService, FavoriteProductsService>();

builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};


//On time created new cart by anonymous customer, need to get id (this cart) and 
//put on cookie (ex: cart:<id>)
//Next time need to check cookie for availability it cart

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

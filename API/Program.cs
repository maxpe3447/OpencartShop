using Api.Storage;
using Api.Storage.Entities;
using API.Domain.Extensions;
using API.Extensions;
using API.Middlewares;
using API.Storage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();


// Add services to the container.
builder.Services
    .AddControllers()
    .AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<AppDbContext>(b => b.UseSqlite(builder.Configuration.GetConnectionString("db"),
                                                             b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

builder.Services.AddDomain();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"]!)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

builder.Services.AddSwaggerGen();
builder.Services
           .AddIdentityCore<User>(opt => opt.Password.RequireNonAlphanumeric = false)
           .AddRoles<Role>()
           .AddUserManager<UserManager<User>>()
           .AddEntityFrameworkStores<AppDbContext>();


var app = builder.Build();

app.Map("/", async context =>
{
    context.Response.Redirect("swagger");
});

app.UseCors(builder => builder.AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials());

app.UseErrorHandler();
app.UseSwagger();
app.UseSwaggerUI();

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseUserInfoHandler();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    await dbContext.Database.MigrateAsync();
    await DataSeed.Load(userManager, dbContext);
};


app.Run();

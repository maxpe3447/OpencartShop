using Api.Service.Repository.Auth.LoginService;
using Api.Service.Repository.Auth.RegistrationService;
using Api.Service.Repository.Catalog.CategoryService;
using Api.Service.Repository.OrderService;
using Api.Service.Repository.Products.ProductService;
using Api.Service.Repository.ReturnProductService;
using Api.Service.UserDataService;

namespace API.Domain.Extensions;

public static class RegistrationDependencies
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services
            .AddScoped<ICategoryService, CategoryService>()
            .AddScoped<ILoginService, LoginService>()
            .AddScoped<IRegistrationService, RegistrationService>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IOrderService, OrderService>()
            .AddScoped<IReturnProductService, ReturnProductService>()
            .AddScoped<IUserDataService, UserDataService>();


        return services;
    }
}

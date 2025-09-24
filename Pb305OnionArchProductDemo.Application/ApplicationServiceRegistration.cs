using Microsoft.Extensions.DependencyInjection;
using Pb305OnionArchProductDemo.Application.Interfaces;
using Pb305OnionArchProductDemo.Application.Services;

namespace Pb305OnionArchProductDemo.Application;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
    }
}

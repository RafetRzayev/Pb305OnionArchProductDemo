using Microsoft.Extensions.DependencyInjection;
using Pb305OnionArchProductDemo.Application.AutoMapping;
using Pb305OnionArchProductDemo.Application.Interfaces;
using Pb305OnionArchProductDemo.Application.Services;
using Pb305OnionArchTagDemo.Application.Interfaces;
using Pb305OnionArchTagDemo.Application.Services;

namespace Pb305OnionArchProductDemo.Application;

public static class ApplicationServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudService<,,,>));

        services.AddAutoMapper(x => x.AddProfile<MappingProfile>());
    }
}

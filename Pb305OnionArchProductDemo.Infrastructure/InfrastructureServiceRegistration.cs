using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pb305OnionArchProductDemo.Domain.Interfaces;
using Pb305OnionArchProductDemo.Infrastructure.DataContext;
using Pb305OnionArchProductDemo.Infrastructure.Repositories;
using Pb305OnionArchTagDemo.Domain.Interfaces;
using Pb305OnionArchTagDemo.Infrastructure.Repositories;

namespace Pb305OnionArchProductDemo.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
    }
}

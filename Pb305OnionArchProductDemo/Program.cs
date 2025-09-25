using Pb305OnionArchProductDemo.Infrastructure;
using Pb305OnionArchProductDemo.Infrastructure.DataContext;
using Pb305OnionArchProductDemo.Application;
using Microsoft.EntityFrameworkCore;

namespace Pb305OnionArchProductDemo
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            using (var scope = app.Services.CreateScope())
            {
                //var dataInitializer = scope.ServiceProvider.GetRequiredService<DataInitializer>();
                var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                await appDbContext.Database.MigrateAsync();
                //await dataInitializer.Initialize();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            await app.RunAsync();
        }
    }
}

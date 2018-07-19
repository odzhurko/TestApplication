using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestApp.Library.Dao;
using TestApp.Library.Dao.Interfaces;
using TestApp.Library.DataBase;
using TestApp.Library.Services;
using TestApp.Library.Services.Interfaces;

namespace TestApp.Library
{
    public static class Installers
    {
        public static void AddLibraryServices(this IServiceCollection services)
        {
            //services.AddDbContext<FabricContext>(options => options.UseInMemoryDatabase("TestApp.DataBase"));

            var connection = @"Server=(localdb)\mssqllocaldb;Database=TestApp.DataBase;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<FabricContext>(options => options.UseSqlServer(connection));

            services.AddScoped<IFabricDao, FabricDao>();
            services.AddScoped<IFabricService, FabricService>();
            services.AddScoped<IMigrationService, MigrationService>();
        }
    }
}

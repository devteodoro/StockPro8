using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockPro.Domain.Interfaces;
using StockPro.Infrastructure.Data;


namespace StockPro.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services
                .AddDbContext<StockProDataContext>(options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(StockProDataContext).Assembly.FullName));
                });

            //services
            //    .AddScoped<ITokenService, TokenService>();

            //services
            //    .AddScoped<IUserRepository, UserRepository>();

            //services
            //    .AddScoped<IPersonRepository, PersonRepository>();

            //services
            //    .AddScoped<IPhotoRepository, PhotoRepository>();

            //services
            //    .AddScoped<IUserService, UserService>();

            //services
            //    .AddScoped<IPersonService, PersonService>();

            //services
            //    .AddScoped<IPhotoService, PhotoService>();

            //services
            //    .AddTransient<ICryptography, Cryptography>();

            return services;
        }
    }
}

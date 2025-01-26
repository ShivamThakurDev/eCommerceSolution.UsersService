using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
namespace eCommerce.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure  services to the dependency injection container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            //TO DO: Add Services to the IOC container 
            //Infrastructure services often include data access, caching and other low-level components.
            services.AddSingleton<IUsersRepository, UsersRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}

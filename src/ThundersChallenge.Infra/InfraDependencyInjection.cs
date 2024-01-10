

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ThundersChallenge.Infra.Context;
using ThundersChallenge.Infra.Repository;
using ThundersChallenge.Infra.Repository.Interface;

namespace ThundersChallenge.Infra;

public static  class InfraDependencyInjection
{
    public static IServiceCollection AddInfraServices(this IServiceCollection services)
    {
        
        services.AddDbContext<InMemoryDatabaseContext>(opt => opt.UseInMemoryDatabase("ThundersChallenge"));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}

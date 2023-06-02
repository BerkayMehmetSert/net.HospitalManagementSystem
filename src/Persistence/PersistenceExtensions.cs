using Application.Contacts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceExtensions
{
    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(option =>
        {
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!);
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
using Market.Domain.Abstractions;
using Market.Infrastructure.Context;
using Market.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Market.CrossCutting.AppDependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
    {
        var connectionString = configuration
                    .GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
        services.AddSingleton<IDbConnection>(provider =>
                {
                    var connection = new SqlConnection(connectionString);
                    connection.Open();
                    return connection;
                });
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();
        var myHandlers = AppDomain.CurrentDomain.Load("Market.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myHandlers));

        return services;
    }
}
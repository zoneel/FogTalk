﻿using FogTalk.Domain.Repositories;
using FogTalk.Infrastructure.Persistence;
using FogTalk.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace FogTalk.Infrastructure.ServicesConfiguration;

public static class ServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<FogTalkDbContext>(options =>
        {
            options.UseSqlServer(Environment.GetEnvironmentVariable("FOGTALK_CONNECTION_STRING"));
        });
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        return services;
    }
}

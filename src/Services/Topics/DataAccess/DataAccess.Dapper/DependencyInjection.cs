﻿using Microsoft.Extensions.Configuration;
using System.Data;
using Npgsql;
using Topics.DataAccess.Dapper.Contracts;
using Topics.DataAccess.Dapper.Postgres.Realizations;
using Topics.DataAccess.Dapper.Postgres;

namespace Microsoft.Extensions.DependencyInjection;
public static partial class DependencyInjection
{
    public static IServiceCollection AddPostgresDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>
        (
            (serviceProvider) => new NpgsqlConnection(configuration["ConnectionStrings:Dev:Topics"])
        );

        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<ITopicLevelRepository, TopicLevelRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>();
        services.AddScoped<ITopicStatisticsRepository, TopicStatisticsRepository>();
        services.AddScoped<ITopicStatisticsTypeRepository, TopicStatisticsTypeRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

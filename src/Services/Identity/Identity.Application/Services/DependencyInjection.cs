﻿using Identity.Application.Services.DataMigrator;
using Identity.Application.Services.UserActions;
using Identity.Application.Services.UserInfoActions;
using Identity.Application.Services.UserRoleActions;
using Identity.Domain.Contracts;

namespace Microsoft.Extensions.DependencyInjection.Actions;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserInfoService, UserInfoService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IUserStatisticsService, IUserStatisticsService>();
        services.AddTransient<IDataMigrator, DataMigrator>();

        return services;
    }
}

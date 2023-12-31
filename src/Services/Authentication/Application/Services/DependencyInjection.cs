﻿using Authentication.Application.Services.Authentication;
using Authentication.Application.Services.Confirm;
using Authentication.Application.Services.DataMigrator;
using Authentication.Application.Services.Jwt;
using Authentication.Domain.Contracts;

namespace Microsoft.Extensions.DependencyInjection.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IConfirmationService, ConfirmationService>();
        services.AddScoped<IDataMigrator, DataMigrator>();

        return services;
    }
}

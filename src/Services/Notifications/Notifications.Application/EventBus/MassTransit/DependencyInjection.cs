﻿using MassTransit;
using Microsoft.Extensions.Configuration;
using Notifications.Application.EventBus.MassTransit.Consumers;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();
            x.AddDelayedMessageScheduler();
            x.AddConsumer<DeleteUserConsumer>();
            x.AddConsumer<UpdateUserConsumer>();
            x.AddConsumer<CreateUserConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:Uri"]!, "/", h =>
                {
                    h.Username(configuration["RabbitMq:UserName"]);
                    h.Password(configuration["RabbitMq:Password"]);
                });

                cfg.ReceiveEndpoint("notifications_" + typeof(DeleteUserConsumer).Name.ToLower(), endpoint =>
                {
                    endpoint.ConfigureConsumer<DeleteUserConsumer>(context);
                });
                cfg.ReceiveEndpoint("notifications_" + typeof(UpdateUserConsumer).Name.ToLower(), endpoint =>
                {
                    endpoint.ConfigureConsumer<UpdateUserConsumer>(context);
                });
                cfg.ReceiveEndpoint("notifications_" + typeof(CreateUserConsumer).Name.ToLower(), endpoint =>
                {
                    endpoint.ConfigureConsumer<CreateUserConsumer>(context);
                });
                cfg.ClearSerialization();
                cfg.UseRawJsonSerializer();
                cfg.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}

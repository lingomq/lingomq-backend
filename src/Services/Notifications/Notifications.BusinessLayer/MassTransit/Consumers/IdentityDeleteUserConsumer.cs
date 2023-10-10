using EventBus.Entities.Identity.User;
using MassTransit;
using Microsoft.Extensions.Logging;
using Notifications.BusinessLayer.Contracts;
using Notifications.DomainLayer.Entities;

namespace Notifications.BusinessLayer.MassTransit.Consumers;

public class IdentityDeleteUserConsumer : IConsumer<IdentityModelDeleteUser>
{
    private readonly ILogger<IdentityDeleteUserConsumer> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public IdentityDeleteUserConsumer(ILogger<IdentityDeleteUserConsumer> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }
    public async Task Consume(ConsumeContext<IdentityModelDeleteUser> context)
    {
        Guid id = context.Message.Id;
        User? user = await _unitOfWork.Users.GetAsync(id);

        if (user is null)
            _logger.LogError("[-] [Topics UserDelete Consumer] " +
                             "Failed: User not found");

        await _unitOfWork.Users.DeleteAsync(id);

        _logger.LogInformation("[+] [Topics UserDelete Consumer] " +
                               "Success: User has been deleted");
    }
}


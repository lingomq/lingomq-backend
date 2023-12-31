﻿using Achievements.DataAccess.Dapper.Contracts;
using Achievements.Domain.Entities;
using EventBus.Entities.Identity.User;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Achievements.BusinessLayer.MassTransit.Consumers
{
    public class DeleteUserConsumer : IConsumer<IdentityModelDeleteUser>
    {
        private readonly ILogger<DeleteUserConsumer> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUserConsumer(ILogger<DeleteUserConsumer> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task Consume(ConsumeContext<IdentityModelDeleteUser> context)
        {
            Guid id = context.Message.Id;
            User? user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user is null)
                _logger.LogError("[-] [Achievements UserDelete Consumer] " +
                                 "Failed: User not found");

            await _unitOfWork.Users.DeleteAsync(id);

            _logger.LogInformation("[+] [Achievements UserDelete Consumer] " +
                                   "Success: User has been deleted");
        }
    }
}

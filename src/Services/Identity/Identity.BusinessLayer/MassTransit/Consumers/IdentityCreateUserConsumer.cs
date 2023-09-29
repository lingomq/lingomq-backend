﻿using EventBus.Entities.Identity;
using Identity.BusinessLayer.Contracts;
using Identity.DomainLayer.Entities;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Identity.BusinessLayer.MassTransit.Consumers
{
    public class IdentityCreateUserConsumer : IConsumer<IdentityModelCreateUser>
    {
        private readonly ILogger<IdentityCreateUserConsumer> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public IdentityCreateUserConsumer(ILogger<IdentityCreateUserConsumer> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task Consume(ConsumeContext<IdentityModelCreateUser> context)
        {
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Email = context.Message.Email,
                Phone = context.Message.Phone,
                PasswordHash = context.Message.PasswordHash,
                PasswordSalt = context.Message.PasswordSalt
            };

            await _unitOfWork.Users.AddAsync(user);

            UserInfo userInfo = new UserInfo()
            {
                Id = Guid.NewGuid(),
                Nickname = context.Message.Nickname,
                RoleId = context.Message.RoleId,
                Additional = "",
                IsRemoved = false,
                CreationalDate = DateTime.Now,
                UserId = user.Id
            };

            await _unitOfWork.UserInfos.AddAsync(userInfo);

            _logger.LogInformation("[+] [Identity Create Consumer] Succesfully get message." +
                "{0}:{1}:{2} has been added", user.Id, user.Email, userInfo.Nickname);
        }
    }
}
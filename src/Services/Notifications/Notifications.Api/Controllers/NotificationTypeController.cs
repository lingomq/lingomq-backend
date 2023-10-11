﻿using LingoMq.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notifications.Api.Common;
using Notifications.BusinessLayer.Contracts;
using Notifications.BusinessLayer.Exceptions.ClientExceptions;
using Notifications.DomainLayer.Entities;

namespace Notifications.Api.Controllers;

[Route("api/v0/notifications/type")]
[ApiController]
public class NotificationTypeController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public NotificationTypeController(IUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    [HttpGet("all/{range}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(int range = int.MaxValue)
    {
        List<NotificationType> types = await _unitOfWork.NotificationTypes.GetAsync(range);
        return LingoMqResponse.OkResult(types);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get(Guid id)
    {
        NotificationType? type = await _unitOfWork.NotificationTypes.GetAsync(id);
        if (type is null)
            throw new NotFoundException<NotificationType>();

        return LingoMqResponse.OkResult(type);
    }

    [HttpPost]
    [Authorize(Roles = AccessRoles.Admin)]
    public async Task<IActionResult> Create(NotificationType type)
    {
        await _unitOfWork.NotificationTypes.CreateAsync(type);
        return LingoMqResponse.AcceptedResult(type);
    }

    [HttpPut]
    [Authorize(Roles = AccessRoles.Admin)]
    public async Task<IActionResult> Update(NotificationType type)
    {
        if (await _unitOfWork.NotificationTypes.GetAsync(type.Id) is null)
            throw new InvalidDataException<NotificationType>(new[] { "id" });

        await _unitOfWork.NotificationTypes.UpdateAsync(type);
        return LingoMqResponse.AcceptedResult(type);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = AccessRoles.Admin)]
    public async Task<IActionResult> Delete(Guid id)
    {
        if (await _unitOfWork.NotificationTypes.GetAsync(id) is null)
            throw new InvalidDataException<NotificationType>(new[] { "id" });

        await _unitOfWork.NotificationTypes.DeleteAsync(id);
        return LingoMqResponse.AcceptedResult();
    }
}
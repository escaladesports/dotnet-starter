﻿using CleanArchitecture.Application.Common.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly IUser _user;

    public LoggingBehaviour(ILogger<TRequest> logger, IUser user)
    {
        _logger = logger;
        _user = user;
    }

    public async Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _user.Id ?? string.Empty;
        // string? userName = string.Empty;

        // if (!string.IsNullOrEmpty(userId))
        // {
        //     userName = await _identityService.GetUserNameAsync(userId);
        // }
        await Task.Run(() => _logger.LogInformation("CleanArchitecture Request: {Name} {@UserId} {@Request}",
            requestName, userId, request), cancellationToken);
        ;
    }
}

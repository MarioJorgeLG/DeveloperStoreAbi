using MediatR;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;

public class SaleCreatedHandler : INotificationHandler<SaleCreatedEvent>
{
    private readonly ILogger<SaleCreatedHandler> _logger;

    public SaleCreatedHandler(ILogger<SaleCreatedHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(SaleCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Sale Created: {notification.SaleId}");
        return Task.CompletedTask;
    }
}

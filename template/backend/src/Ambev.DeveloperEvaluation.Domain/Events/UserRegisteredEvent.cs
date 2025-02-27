using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class UserRegisteredEvent
    {
        public User User { get; }

        public UserRegisteredEvent(User user)
        {
            User = user;
        }
    }

    public record SaleCreatedEvent(Guid SaleId) : INotification;

    public record SaleModifiedEvent(Guid SaleId) : INotification;

    public record SaleCancelledEvent(Guid SaleId) : INotification;
}

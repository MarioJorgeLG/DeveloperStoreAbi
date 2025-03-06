using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class UserRegisteredEvent : INotification
    {
        public Guid UserId { get; }
        public string UserName { get; }

        public UserRegisteredEvent(Guid userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}

